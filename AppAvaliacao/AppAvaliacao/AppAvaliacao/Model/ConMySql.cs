using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace AppAvaliacao.Model
{
    public class ConMySql
    {
        private MySqlConnectionStringBuilder Builder = new MySqlConnectionStringBuilder();
        private MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader rdr;
        private string server = "sql10.freemysqlhosting.net";
        private int port = 3306;
        private string dataBase = "sql10198781";
        private string userId = "sql10198781";
        private string password = "TV4aNJ9RFb";


        public bool TryConnection(out string Error)
        {
            Builder.Server = server;
            Builder.Database = dataBase;
            Builder.UserID = userId;
            Builder.Password = password;
            
                try
                {
                    conexao = new MySqlConnection(Builder.ToString());
                    conexao.Open();
                    Error = "";
                    return true;

                }
                catch (Exception ex)
                {
                    Error = ex.ToString();
                    throw ex;
                }
        
        }

        public bool InsereUsuario(string nome, int matricula, string email, string senha, string tipo)
        {
            if(conexao.State == ConnectionState.Open)
            {
                try
                {
                    comando = new MySqlCommand("INSERT INTO usuario(id, nome, matricula, email, senha, tipo) VALUES(NULL, @nome, @matricula, @email, @senha, @tipo)", conexao);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@matricula", matricula);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);
                    comando.Parameters.AddWithValue("@tipo", tipo);
                    comando.ExecuteNonQuery();
                    
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool Logar(string email, string senha)
        {
            string nome;

            if (conexao.State == ConnectionState.Open)
            {
                try
                {
                    comando = new MySqlCommand("SELECT nome FROM usuario WHERE email = @email AND senha = @senha", conexao);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);
                    rdr = comando.ExecuteReader();
                    nome = rdr["nome"].ToString();
                    if (nome != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }

            }

            return false;
        }

    }
}
