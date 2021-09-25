using softlotery.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;

namespace softlotery.DAL
{
    class JogoDAL : IDisposable
    {
        public static List<Jogo> GetAllJogos()
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            var jogos = new List<Jogo>();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Jogos";
                    //da = new SqlDataAdapter(cmd.CommandText, SqliteDAL.DbConnectionString());
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jogos.Add(new Jogo
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                            Numero = dt.Rows[i]["Numero"].ToString(),
                            TipoJogo = Convert.ToInt32(dt.Rows[i]["TipoJogo"]),
                            QtdaJogada = dt.Rows[i]["QtdaJogada"].ToString(),
                            Concurso = dt.Rows[i]["Concurso"].ToString(),
                            DataCriacao = (DateTime)dt.Rows[i]["DataCriacao"]
                        });
                    }

                    return jogos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Jogo GetJogoById(int id)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Jogos Where Id=" + id;
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    return new Jogo {
                            Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                            Numero = dt.Rows[0]["Numero"].ToString(),
                            TipoJogo = Convert.ToInt32(dt.Rows[0]["TipoJogo"]),
                            QtdaJogada = dt.Rows[0]["QtdaJogada"].ToString(),
                            Concurso = dt.Rows[0]["Concurso"].ToString(),
                            DataCriacao = (DateTime)dt.Rows[0]["DataCriacao"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Jogo GetJogoByConcurso(string concurso, int tipoJogo)
        {
            SQLiteDataAdapter da = null;
            //SqlDataAdapter da = null;
            DataTable dt = new DataTable();

            try
            {
                if (string.IsNullOrWhiteSpace(concurso) || tipoJogo == 0)
                    return null;

                if (!string.IsNullOrWhiteSpace(concurso))
                    concurso = concurso.Trim();

                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Jogos Where Concurso=" + concurso + " and TipoJogo=" + tipoJogo;
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    return new Jogo
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        Numero = dt.Rows[0]["Numero"].ToString(),
                        TipoJogo = Convert.ToInt32(dt.Rows[0]["TipoJogo"]),
                        QtdaJogada = dt.Rows[0]["QtdaJogada"].ToString(),
                        Concurso = dt.Rows[0]["Concurso"].ToString(),
                        DataCriacao = (DateTime)dt.Rows[0]["DataCriacao"]
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<Jogo> GetJogoByTipo(int tipoJogo)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            var jogos = new List<Jogo>();
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Jogos Where TipoJogo=" + tipoJogo;
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection());
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        jogos.Add(new Jogo
                        {
                            Id = Convert.ToInt32(dt.Rows[i]["Id"]),
                            Numero = dt.Rows[i]["Numero"].ToString(),
                            TipoJogo = Convert.ToInt32(dt.Rows[i]["TipoJogo"]),
                            QtdaJogada = dt.Rows[i]["QtdaJogada"].ToString(),
                            Concurso = dt.Rows[i]["Concurso"].ToString(),
                            DataCriacao = (DateTime)dt.Rows[i]["DataCriacao"]
                        });
                    }

                    return jogos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Jogo GetJogoByNumber(string numero)
        {
            SQLiteDataAdapter da = null;
            DataTable dt = new DataTable();
            Jogo jogo = new Jogo();
            try
            {
                if (!string.IsNullOrWhiteSpace(numero))
                    numero = numero.Trim();

                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM Jogos Where Numero='{0}' LIMIT 1;", numero);
                    da = new SQLiteDataAdapter(cmd.CommandText, SqliteDAL.DbConnection().ConnectionString);
                    da.Fill(dt);

                    if (dt.Rows.Count == 0)
                        return null;

                    jogo.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    jogo.Numero = dt.Rows[0]["Numero"].ToString();
                    jogo.TipoJogo = Convert.ToInt32(dt.Rows[0]["TipoJogo"]);
                    jogo.QtdaJogada = dt.Rows[0]["QtdaJogada"].ToString();
                    jogo.Concurso = dt.Rows[0]["Concurso"].ToString();
                    jogo.DataCriacao = (DateTime)dt.Rows[0]["DataCriacao"];

                    return jogo;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Add(Jogo jogo)
        {
            try
            {
                if (jogo != null && !string.IsNullOrWhiteSpace(jogo.Numero))
                    jogo.Numero = jogo.Numero.Trim();

                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Jogos(Numero, TipoJogo, QtdaJogada, Concurso, DataCriacao) values (@numero, @tipoJogo, @qtdaJogada, @concurso, @dataCriacao)";
                    cmd.Parameters.AddWithValue("@numero", jogo.Numero);
                    cmd.Parameters.AddWithValue("@tipoJogo", jogo.TipoJogo);
                    cmd.Parameters.AddWithValue("@qtdaJogada", jogo.QtdaJogada);
                    cmd.Parameters.AddWithValue("@concurso", jogo.Concurso);
                    cmd.Parameters.AddWithValue("@dataCriacao", jogo.DataCriacao);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void Update(Jogo jogo)
        {
            try
            {
                using (var cmd = SqliteDAL.DbConnection().CreateCommand())
                {
                    if (jogo != null)
                    {
                        cmd.CommandText = "UPDATE Jogos SET Numero=@Numero,TipoJogo=@TipoJogo,QtdaJogada=@QtdaJogada,Concurso=@concurso,DataCriacao=@dataCriacao WHERE Id = @Id";
                        cmd.Parameters.AddWithValue("@Id", jogo.Id);
                        cmd.Parameters.AddWithValue("@Numero", jogo.Numero);
                        cmd.Parameters.AddWithValue("@TipoJogo", jogo.TipoJogo);
                        cmd.Parameters.AddWithValue("@QtdaJogada", jogo.QtdaJogada);
                        cmd.Parameters.AddWithValue("@concurso", jogo.Concurso);
                        cmd.Parameters.AddWithValue("@dataCriacao", jogo.DataCriacao);
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
                    cmd.CommandText = "DELETE FROM Jogos Where Id=@Id";
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
