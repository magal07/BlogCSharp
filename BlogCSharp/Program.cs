using System.ComponentModel.DataAnnotations;
using BlogCSharp.Models;
using BlogCSharp.Repositories;
using Dapper;
using Dapper.Contrib.Extensions;

using Microsoft.Data.SqlClient;

namespace BlogCSharp {

    static class Program
    {
        private const string CONNECTION_STRING =
            @"Server=localhost;Database=Blog;User=sa;Password=1q2w3e4r@#$;Encrypt=False";

        static void Main(string[] args)
        {
            var connection = new SqlConnection(CONNECTION_STRING);
            connection.Open();
            
            ReadUsersWithRoles(connection);
            // CreateUsers(connection);
            // ReadUsers(connection);
            // ReadRoles(connection);
            // ReadTags(connection);

            connection.Close();
        }

    public static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Get();
            repository.Get();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                
                foreach (var role in items)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }
        public static void CreateUsers(SqlConnection connection)
        {
            var user = new User()
            {
                Email = "tchu@tchu.tcha",
                Bio = "Sertanejo",
                Image = "telo",
                Name = "Michel Teló",
                PasswordHash = "HASH",
                Slug = "slug"
            };
            var repository = new Repository<User>(connection);
            repository.Create(user);
            Console.WriteLine($"User created: {user.Name}");
        }

        public static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.GetWithRoles();
            
            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }
        }

        public static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Get();
            repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        } 
        public static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Get();
            repository.Get();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        // public static void CreateUsers(SqlConnection connection)
        // {
        //     var repository = new Repository<User>(connection);
        //     var user = new User();
        //     user.Name = "John Doe";
        //     user.Email = "teste@teste.com";
        //     user.PasswordHash = "123qwe";
        //     user.Bio = "biograph";
        //     user.Image = "http";
        //     user.Slug = "image-url";
        //     
        //     var insertSql = @"INSERT INTO 
        //     [User] 
        //         VALUES(
        //         @Name,
        //         @Email,
        //         @PasswordHash,
        //         @Bio,
        //         @Image,
        //         @Slug
        //         )";
        //
        //     var rows = connection.Execute(insertSql, new
        //     {
        //         user.Name,
        //         user.Email,
        //         user.PasswordHash,
        //         user.Bio,
        //         user.Image,
        //         user.Slug,
        //     });
        //     Console.WriteLine($"{rows} linhas inseridas");
        }
    }
    