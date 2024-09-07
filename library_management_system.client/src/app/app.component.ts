import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  
  public tasklist: string[] = [];
  public completedTasks: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<string[]>('/weatherforecast').subscribe(
      (result) => {
        this.tasklist = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  markAsDone(task: string) {
    this.http.post('/weatherforecast/mark-as-done', JSON.stringify(task), { headers: { 'Content-Type': 'application/json' } }).subscribe(
      () => {
        this.completedTasks.push(task);
        this.tasklist = this.tasklist.filter(t => t !== task);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  newElement(newTask: string) {
    this.http.post('weatherforecast/add-task', JSON.stringify(newTask), { headers: { 'Content-Type': 'application/json' } }).subscribe(
      () => {
        this.tasklist.push(newTask);
      },
      (error) => {
        console.error(error);
      }
    );
    
  }

  title = 'library_management_system.client';
}
