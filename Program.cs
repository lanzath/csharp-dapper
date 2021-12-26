using System;
using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
        static void Main(string[] args)
        {
            // ReadUsers();
            // ReadUser();
            // CreateUser();
            // UpdateUser();
            // DeleteUser();
        }

        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();
                foreach (var user in users)
                {
                    Console.WriteLine($"Id: {user.Id} name: {user.Name} email: {user.Email}");
                }
            }
        }

        public static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                Console.WriteLine(user.Bio);
            }
        }

        public static void CreateUser()
        {
            var user = new User()
            {
                Name = "Jhonny Sins",
                Bio = "O Careca da Brazzers | Pau para toda obra",
                Email = "sins@brazzers.com",
                Password = "$2y$10$XxReFmCyYHKwkJyZGSsDtuRqj2hgYt56pPCVIGSv6xgVJTiTivs8G",
                Image = "https://i1.sndcdn.com/artworks-000562525653-v1wh6h-t500x500.jpg",
                Slug = "careca-da-brazzers"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Insert<User>(user); // Retorna quantidade de linhas afetadas
            }
        }

        public static void UpdateUser()
        {
            var user = new User()
            {
                Id = 3,
                Name = "Jhonny Sins",
                Bio = "O Careca da Brazzers | Pau para toda obra",
                Email = "jhonny.sins@brazzers.com",
                Password = "$2y$10$XxReFmCyYHKwkJyZGSsDtuRqj2hgYt56pPCVIGSv6xgVJTiTivs8G",
                Image = "https://i1.sndcdn.com/artworks-000562525653-v1wh6h-t500x500.jpg",
                Slug = "careca-da-brazzers"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                connection.Update<User>(user);
            }
        }

        public static void DeleteUser()
        {

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(2);
                connection.Delete<User>(user);
            }
        }
    }
}
