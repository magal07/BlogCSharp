using BlogCSharp.Models;
using Dapper.Contrib.Extensions;

using Microsoft.Data.SqlClient;

namespace BlogCSharp {
    
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;User=sa;Password=1q2w3e4r@#$;Encrypt=False";
        static void Main(string[] args)
        {
            ReadUsers();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine(user.Name);
                }
            }
        }
    }
}