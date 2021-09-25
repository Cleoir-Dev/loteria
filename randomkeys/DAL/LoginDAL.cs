using softlotery.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace softlotery.DAL
{
    public class LoginDAL : IDisposable
    {
        public static DataTable GetLogin()
        {
            //SqlDataAdapter da = null;
            SQLiteDataAdapter da = null;

            DataTable dt = new DataTable();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Login";
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static DataTable GetLoginTabela(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Login Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Login GetLoginUsuario(string username, string password)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            Login login = new Login();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM Login Where Username='{0}' and Password='{1}' LIMIT 1;", username, password);
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    login.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    login.Username = dt.Rows[0]["Username"].ToString();
                    login.Password = dt.Rows[0]["Password"].ToString();
                    return login;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Login GetLogin(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            Login login = new Login();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Login Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);
                    login.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    login.Username = dt.Rows[0]["Username"].ToString();
                    login.Password = dt.Rows[0]["Password"].ToString();
                    return login;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Add(Login login)
        {
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Login(Username, Password) values (@username, @password)";
                    cmd.Parameters.AddWithValue("@username", login.Username);
                    cmd.Parameters.AddWithValue("@password", login.Password);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Login login)
        {
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    if (login != null)
                    {
                        cmd.CommandText = "UPDATE Login SET Username=@Username,Password=@Password WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", login.Id);
                        cmd.Parameters.AddWithValue("@Username", login.Username);
                        cmd.Parameters.AddWithValue("@Password", login.Password);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Delete(int Id)
        {
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "DELETE FROM Login Where Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", Id);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
