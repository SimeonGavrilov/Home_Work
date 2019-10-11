using Entities;
using Notes.DAL.Interfaces;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class UserDao : IUserDao
    {
        private string _connectionString = @"Data Source=DESKTOP-3C735T8\SQLEXPRESS;Initial Catalog=ArtistDB;Integrated Security=True";
        private List<Art> Arts;
        private List<Art_4_Favorits> Arts_F;
        private Art Art;

        public bool AddBallToArt(int userID, int artID)
        {
            if (Check4Like(artID, userID))
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandText = "DoLike";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@User_ID",
                        Value = userID,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "Art_ID",
                        Value = artID,
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input
                    });
                    connection.Open();
                    command.ExecuteNonQuery();
                }

                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"update Art"
                                    + " set Points = Points + 1"
                                    + " where Art.ID = '" + artID + "'";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                using (var connection = new SqlConnection(_connectionString))
                {
                    var command = connection.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"insert into[Artist's Favorite]	(ID_Artist, ID_Favorite_Art)"
                                            + "values(" + userID +","+ artID +")";
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                return true;
            }
            else return false;
        }

        public bool Check4Like(int Art_ID, int User_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "RowsForLikes";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Art_ID",
                    Value = Art_ID,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });

                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@User_ID",
                    Value = User_ID,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                var rows = new SqlParameter
                {
                    ParameterName = "@rows",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                command.Parameters.Add(rows);
                connection.Open();
                command.ExecuteNonQuery();
                if ((int)rows.Value == 0)
                {
                    return true;
                }
                else return false;
            }
        }

        public void CrewateNewAcc(User user)
        {
            using (var connection = new SqlConnection(_connectionString) )
            {
                var command = connection.CreateCommand();
                command.CommandText = "CreateAcc";
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
                    ParameterName = "Pass",
                    Value = user.pass,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
            }
        }


        public void DateOfImg()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select ID_Artist, Name,Art_Name, ID_Art,Path from Artists"
                                      + " left join Artist_Art on id = Artist_Art.ID_Artist"
                                      + " left join Art on Art.ID = Artist_Art.ID_Art";

                //+" left join Artists on Artists.Name = '" + Name + "'";
                connection.Open();
                var reader = command.ExecuteReader();

                Arts = new List<Art>();
                while (reader.Read())
                {
                    Arts.Add(new Art()
                    {
                        //Art_ID = (int)reader["ID_Art"],
                        Art_Name = (string)reader["Art_Name"],
                        Art_Path = (string)reader["Path"],
                        Art_Artist = (string)reader["Name"]
                    });
                }
            }
        }

        public IEnumerable<Art> GetAllArtsOfArtist(string artist)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select * from Art where artist = '" + artist + "'";

                                        //+" left join Artists on Artists.Name = '" + Name + "'";
                connection.Open();
                var reader = command.ExecuteReader();

                Arts = new List<Art>();
                while (reader.Read())
                {
                    Arts.Add(new Art()
                    {
                        Art_ID = (int)reader["ID"],
                        Art_Name = (string)reader["Art_Name"],
                        Art_Path = (string)reader["Path"],
                        Art_Artist = artist
                    });
                }
            }
            return Arts;
        }

        public IEnumerable<Art_4_Favorits> GetAllFavoritsOfArtist()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select art.Art_Name, Art.Artist, Artists.Name, art.Path, Art.ID from Art"
                                        + " left join [Artist's Favorite] on ID = [Artist's Favorite].ID_Favorite_Art"
                                        + " left join Artists on Artists.ID = [Artist's Favorite].ID_Artist";
                connection.Open();
                var reader = command.ExecuteReader();

                Arts_F = new List<Art_4_Favorits>();
                while (reader.Read())
                {
                    Arts_F.Add(new Art_4_Favorits()
                    {
                        Art_ID = (int)reader["ID"],
                        Art_Name = (string)reader["Art_Name"],
                        Art_Path = (string)reader["Path"],
                        Art_Artist = string.IsNullOrEmpty(reader["Artist"]?.ToString()) ? "" : (string)reader["Artist"],
                        Artist_who_Favorit = string.IsNullOrEmpty(reader["Name"]?.ToString()) ? "" : (string)reader["Name"],
                    });
                }
            }
            return Arts_F;
        }

        public int GetUserByName(string username, string pass)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetRows";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = username,
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

        public int GetIDByName(string username)
        {
            int ID_user=0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select id from Artists"
                                        + " where Artists.Name = '" + username + "'";
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ID_user = (int)reader["id"];
                }
            }
            return ID_user;
        }

        public int LastIDofArt()
        {
            int LastID = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select MAX(ID) as ID from Art";

                connection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    LastID = (int)reader["ID"];
                }
                return LastID;
            }
        }

        public IEnumerable<Art> LatestUpdate()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select top 10 ID, Path, Art_Name, Artist from Art"
                                        + " ORDER BY art.ID DESC";

                connection.Open();
                var reader = command.ExecuteReader();

                Arts = new List<Art>();
                while (reader.Read())
                {
                    Arts.Add(new Art()
                    {
                        Art_ID = (int)reader["ID"],
                        Art_Name = (string)reader["Art_Name"],
                        Art_Path = (string)reader["Path"],
                        Art_Artist = (string)reader["Artist"],
                    });
                }
            }
            return Arts;
        }

        public void UploadImg(string imageFullPath, string Art_name, string username, int ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandText = "UploadImg";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@imageFullPath",
                    Value = imageFullPath,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@Art_name",
                    Value = Art_name,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@username",
                    Value = username,
                    SqlDbType = SqlDbType.NVarChar,
                    Direction = ParameterDirection.Input
                });
                command.Parameters.Add(new SqlParameter
                {
                    ParameterName = "@point",
                    Value = 0,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Input
                });
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Art GetArtById(int Art_ID)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select * from Art where ID = '" + Art_ID + "'";

                //+" left join Artists on Artists.Name = '" + Name + "'";
                connection.Open();
                var reader = command.ExecuteReader();

                Art = new Art();
                while (reader.Read())
                {
                    Art.Art_ID = (int)reader["ID"];
                    Art.Art_Name = (string)reader["Art_name"];
                    Art.Art_Path = (string)reader["Path"];
                    Art.Art_Artist = (string)reader["Artist"];
                    Art.Point = (int)reader["Points"];
                }
            }
            return Art;
        }

        public IEnumerable<Art> Searcher(string Artist_name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = connection.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = @"select * from Art where art.Artist =  '" + Artist_name + "'";

                //+" left join Artists on Artists.Name = '" + Name + "'";
                connection.Open();
                var reader = command.ExecuteReader();

                Arts = new List<Art>();
                while (reader.Read())
                {
                    Arts.Add(new Art()
                    {
                        Art_ID = (int)reader["ID"],
                        Art_Name = (string)reader["Art_Name"],
                        Art_Path = (string)reader["Path"],
                        Art_Artist = string.IsNullOrEmpty(reader["Artist"]?.ToString()) ? "" : (string)reader["Artist"],
                        Point = (int)reader["Points"],
                    });
                }
                return Arts;
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
