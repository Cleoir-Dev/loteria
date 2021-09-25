using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace softlotery.DAL
{
    public class SqliteDAL
    {
        private static SQLiteConnection sqliteConnection;
        public SqliteDAL()
        { }
        public static SQLiteConnection DbConnection()
        {
            sqliteConnection = new SQLiteConnection("Data Source=c:\\Loteria.sqlite; Version=3;");
            sqliteConnection.Open();
            return sqliteConnection;
        }

        public static void CriarBancoSQLite()
        {
            try
            {
                string path = @"c:\Loteria.sqlite";

                if (!File.Exists(path))
                    SQLiteConnection.CreateFile(path);
            }
            catch
            {
                throw;
            }
        }
        public static void CriarTabelaSQlite()
        {
            try
            {
                using (var cmd = DbConnection().CreateCommand())
                {
                    var query = string.Format(@"CREATE TABLE IF NOT EXISTS Jogos(
                                                Id          INTEGER PRIMARY KEY,
                                                Numero      TEXT NOT NULL,
                                                TipoJogo    INTEGER NOT NULL,
                                                QtdaJogada  TEXT NOT NULL,
                                                Concurso    TEXT NOT NULL,
                                                DataCriacao DATETIME NULL
                    );");
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }

                using (var cmd = DbConnection().CreateCommand())
                {


                    var query = string.Format(@"CREATE TABLE IF NOT EXISTS Login(
                                                Id       INTEGER PRIMARY KEY,
                                                Username TEXT NOT NULL,
                                                Password TEXT NOT NULL
                    );");
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
