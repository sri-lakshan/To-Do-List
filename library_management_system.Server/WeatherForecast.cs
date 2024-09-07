using System.Diagnostics;
using Microsoft.Data.SqlClient;


namespace ToDoList.Server
{
    public class WeatherForecast
    {
        private const string connectionString = "Data Source=LAPTOP-KH5U492M;Initial Catalog=testdb;Integrated Security=True;Trust Server Certificate=True";
        public string getData(){
            string queryResult = "";

            using (var cursor = new SqlConnection(connectionString))
            {
                cursor.Open();

                var command = new SqlCommand("SELECT tasks FROM tasks WHERE Status='In Progress'", cursor);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string task = reader.GetString(0);
                    queryResult += task + ",";
                }
            }
            
            
            return queryResult;

            
        }

        public void deleteData(string task)
        {

            using (var cursor = new SqlConnection(connectionString)) {
                cursor.Open();
                string query = "UPDATE tasks SET status='Completed' WHERE tasks='" + task + "'";
                using var command = new SqlCommand(query, cursor);
                var reader = command.ExecuteReader();
            }
        }

        public void insertData(string task) {

            using (var cursor = new SqlConnection(connectionString))
            {
                cursor.Open();
                string query = "INSERT INTO tasks VALUES('" + task + "', 'In Progress')";
                using var command = new SqlCommand(query, cursor);
                var reader = command.ExecuteReader();
            }

        }     
    }
}
