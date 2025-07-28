﻿using BlogCSharp.Models;
using BlogCSharp.Repositories;
using Dapper.Contrib.Extensions;

using Microsoft.Data.SqlClient;

namespace BlogCSharp {
    
    static class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost;Database=Blog;User=sa;Password=1q2w3e4r@#$;Encrypt=False";
        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            ReadUsers(connection);
            ReadRoles(connection);
            
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();

            connection.Close();
        }

        public static void ReadUsers(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.Get();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        } 
        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new RoleRepository(connection);
            var roles = repository.Get();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }   
    }
}