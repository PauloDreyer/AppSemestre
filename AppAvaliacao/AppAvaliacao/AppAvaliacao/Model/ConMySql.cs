using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private Usuario usuario = Usuario.Instancia;
        private string server = "sql10.freemysqlhosting.net";
        private string dataBase = "sql10200357";
        private string userId = "sql10200357";
        private string password = "b5xGJnTu3g";


        //Método para estabelecer uma conexão.
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

        //Método para inserir um usuário
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
        //

        //Método para inserção de uma turma
        public bool InserirTurma(string nome, int professor)
        {
            Random numRand = new Random();
            int numeroTurma = numRand.Next(1000, 10000);
            if (conexao.State == ConnectionState.Open)
            {
                try
                {
                    comando = new MySqlCommand("INSERT INTO turmas(id, nome, id_professor, numero_turma) VALUES(NULL, @nome, @id_professor, @numero_turma)", conexao);
                    comando.Parameters.AddWithValue("@nome", nome);
                    comando.Parameters.AddWithValue("@id_professor", professor);
                    comando.Parameters.AddWithValue("@numero_turma", numeroTurma);
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        //

        //Método de Login 
        public bool Logar(string email, string senha, out string tipo)
        {
            tipo = "";
            if (conexao.State == ConnectionState.Open)
            {
                try
                {
                    Console.WriteLine(email);
                    comando = new MySqlCommand("SELECT id, tipo FROM usuario WHERE email = @email AND senha = @senha", conexao);
                    comando.Parameters.AddWithValue("@email", email);
                    comando.Parameters.AddWithValue("@senha", senha);
                    rdr = comando.ExecuteReader();
                    while (rdr.Read())
                    {
                        tipo = rdr["tipo"].ToString();
                        usuario.Id = rdr["id"].ToString();
                        usuario.Email = email;
                        usuario.Tipo = tipo;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw ex;
                }
                finally
                {
                    conexao.Close();
                }

            }
            return false;
        }
        //

        //Carrega lista de turmas do professor, na página inicial do professor
        public ObservableCollection<ListaTurmas> CarregaTurmas()
        {
            ObservableCollection<ListaTurmas> ListaTurmas = new ObservableCollection<ListaTurmas>();

            if (conexao.State == ConnectionState.Open)
            {
                try
                {
                    comando = new MySqlCommand("SELECT id, nome FROM turmas WHERE id_professor = @id_professor", conexao);
                    comando.Parameters.AddWithValue("@id_professor", usuario.Id);
                    rdr = comando.ExecuteReader();

                    while (rdr.Read())
                    {
                        ListaTurmas turma = new ListaTurmas();
                        turma.Id = rdr["id"].ToString();
                        turma.Nome = rdr["nome"].ToString();
                        ListaTurmas.Add(turma);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    conexao.Close();
                }
            }

            return ListaTurmas;
        }
        //

    }
}
