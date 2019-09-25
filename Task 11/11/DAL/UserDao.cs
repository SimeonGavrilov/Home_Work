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
                    ParameterName = "@Image",
                    Value = user.Image,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Role",
                    Value = user.Role,
                    SqlDbType = SqlDbType.Int,
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
                command.CommandText = @"select id, Role, name, Age, DateOfBirth, [Award's name],[Award's description], [id_a], image from Users"
                                        + " left join Users_Award on id = Users_Award.Id_user "
                                        + " left join Awards on id_a = Users_Award.id_award";
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
                    if (reader["Award's name"].ToString().Length == 0)
                    {
                        Users.Add(new User()
                        {
                            ID = (int)reader["id"],
                            Name = (string)reader["name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            age = (int)reader["Age"],
                            Image = (string)reader["Image"],
                            Role = (int)reader["Role"],
                            NameA = null,
                            DescriptionA = null
                        });
                    }
                    else
                    {
                        Users.Add(new User()
                        {
                            ID = (int)reader["id"],
                            Name = (string)reader["name"],
                            DateOfBirth = (DateTime)reader["DateOfBirth"],
                            age = (int)reader["Age"],
                            Image = (string)reader["Image"],
                            Role = (int)reader["Role"],
                            NameA = (string)reader["Award's name"],
                            DescriptionA = (string)reader["Award's description"]
                        });
                    }
                }
            }
            return Users;
        }

        public int GetUserByName(string name, string pass)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetRows";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = name,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pass",
                    Value = pass,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                var Rows = new SqlParameter
                {
                    ParameterName = "@Rows",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                connection.Open();
                command.Parameters.Add(Rows);
                command.ExecuteNonQuery();
                return (int)Rows.Value;
            }
        }
        public int GetRoleByName(string name, string pass)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetRole";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = name,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@pass",
                    Value = pass,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                var Role = new SqlParameter
                {
                    ParameterName = "@Role",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                connection.Open();
                command.Parameters.Add(Role);
                command.ExecuteNonQuery();
                return (int)Role.Value;
            }
        }

        public void SwitchRole(int ID, int Role)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "SwitchRole";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Id",
                    Value = ID,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Role",
                    Value = Role,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
            }
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
