using Dapper;
using System.Data.SqlClient;
using Lab15._2CreatingRestAPI.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab15._2CreatingRestAPI.Services
{
    public class DALSqlServer : IDAL
    {
        private string connectionString;
        public DALSqlServer(IConfiguration config)
        {
            connectionString = config.GetConnectionString("movieDB");
        }

        public string[] GetMoviesCategories()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movies> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movies>(queryString);
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }

            if (Movies == null)
            {
                return null;
            }
            else
            {
                string[] categories = new string[Movies.Count()];
                int count = 0;

                foreach (Movies p in Movies)
                {
                    categories[count] = p.Category;
                    count++;
                }

                return categories;
            }

        }

        public int CreateMovie(Movies m)
        {
            SqlConnection connection = null;
            string queryString = "INSERT INTO Movies (Title, Category)";
            queryString += "VALUES (@Title,  @Category);";
            queryString += "SELECT SCOPE_IDENTITY();";
            int newId;

            try
            {
                connection = new SqlConnection(connectionString);
                newId = connection.ExecuteScalar<int>(queryString, m);
            }
            catch (Exception e)
            {
                newId = -1;
            }
            finally 
            {
                if (connection != null)
                {
                    connection.Close(); 
                }
            }
            return newId;
        }

        public int DeleteMovieById(int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string deleteCommand = "DELETE FROM Movies WHERE ID = @id";

            int rows = connection.Execute(deleteCommand, new { id = id });

            return rows;
        }

        public Movies GetMovieById(int id)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies WHERE Id = @id";
            Movies movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                movies = connection.QueryFirstOrDefault<Movies>(queryString, new { id = id });
            }
            catch (Exception e)
            {
               
            }
            finally 
            {
                if (connection != null)
                {
                    connection.Close(); 
                }
            }

            return movies;
        }

        public IEnumerable<Movies> GetMoviesAll()
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies";
            IEnumerable<Movies> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movies>(queryString);
            }
            catch (Exception e)
            {
                Console.WriteLine();
                
            }
            finally 
            {
                if (connection != null)
                {
                    connection.Close(); 
                }
            }

            return Movies;
        }

        public IEnumerable<Movies> GetMoviesByCategory(string category)
        {
            SqlConnection connection = null;
            string queryString = "SELECT * FROM Movies WHERE Category = @cat";
            IEnumerable<Movies> Movies = null;

            try
            {
                connection = new SqlConnection(connectionString);
                Movies = connection.Query<Movies>(queryString, new { cat = category });
            }
            catch (Exception e)
            {
               
            }
            finally 
            {
                if (connection != null)
                {
                    connection.Close(); 
                }
            }

            return Movies;
        }
    }
}
