using Entities;
using Notes.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-3C735T8\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True";
        private List<User> Users;
        private List<Awards> Awards;
        public int Add(User user)
        {
            using (var connection = new SqlConnection(_connectionString) )
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddUser";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = user.Name,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@DateOfBirth",
                    Value = user.DateOfBirth,
                    SqlDbType = SqlDbType.DateTime,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Age",
                    Value = user.age,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input 
                });

                var id = new SqlParameter
                {
                    ParameterName = "@id",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(id);

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pass",
                    Value = user.pass,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@ImageData",
                    Value = user.Image,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
                return (int)id.Value;
            }
        }

        public void AddAward(int user_id, int award_id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddAw";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@id_user",
                    Value = user_id,
                    SqlDbType=SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@id_award",
                    Value = award_id,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteByID(int ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "delete from UsersDB.dbo.Users where id = '" + ID + "'";
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = "SELECT [id]"
                                        + ",[Name]"
                                        + ",[Age]"
                                        + ",[Image]"
                                        + " FROM[UsersDB].[dbo].[Users]";
                connection.Open();
                var reader = command.ExecuteReader();

                Users = new List<User>();
                while (reader.Read())
                {
                    //yield return new User
                    //{
                    //    ID = (int)reader["id"],
                    //    Name = (string)reader["Name"],
                    //    DateOfBirth = (DateTime)reader["DateOfBirth"],
                    //};
                    Users.Add(new User()
                    {
                        ID = (int)reader["id"],
                        Name = (string)reader["name"],
                        age = (int)reader["Age"],
                        Image = (string)reader["Image"]
                    }) ;

                    //if id = id_user
                    //Users.Award = awards
                }
            }
            return Users;
        }

        //public List<string> GetHashPass(string Login)
        //{
        //    using (var connection = new SqlConnection(_connectionString))
        //    {
        //        var command = connection.CreateCommand();
        //        command.CommandType = CommandType.Text;
        //        command.CommandText = "select name, [Password] from UsersDB.dbo.Users where Name = '" + Login + "'";
        //        connection.Open();
        //        var reader = command.ExecuteReader();
        //        command.ExecuteNonQuery();
        //        List<string> list = new List<string>();
        //        while (reader.Read())
        //        {
        //            list.Add(new string()
        //            {

        //            });
        //        }
        //    }
        //}
    }
}
