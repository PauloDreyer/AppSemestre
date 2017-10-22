using MySql.Data.MySqlClient;
using System;
using AppAvaliacao.Model;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace AppAvaliacao.Model
{
    class UsuarioDAO
    {
        private ConMySql conexao = ConMySql.Instancia;
        private Usuario usuario = Usuario.Instancia;
        
        //Método de Login 
        public bool Logar(string email, string senha, out string tipo)
        {
            tipo = "";
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, tipo FROM usuario WHERE email = @email AND senha = @senha", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@email", email);
                    conexao.Comando.Parameters.AddWithValue("@senha", senha);
                    conexao.Rdr = conexao.Comando.ExecuteReader();
                    while (conexao.Rdr.Read())
                    {
                        tipo = conexao.Rdr["tipo"].ToString();
                        usuario.Id = conexao.Rdr["id"].ToString();
                        usuario.Email = email;
                        usuario.Tipo = tipo;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conexao.CloseConnection();
                }
                
            }
            return false;
        }

        //Método para inserir um usuário
        public bool Inserir(string nome, int matricula, string email, string senha, string tipo)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO usuario(id, nome, matricula, email, senha, tipo) VALUES(NULL, @nome, @matricula, @email, @senha, @tipo)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@matricula", matricula);
                    conexao.Comando.Parameters.AddWithValue("@email", email);
                    conexao.Comando.Parameters.AddWithValue("@senha", senha);
                    conexao.Comando.Parameters.AddWithValue("@tipo", tipo);
                    conexao.Comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    return false;
                }
                finally
                {
                    conexao.CloseConnection();
                }

            }
            return true;
        }
        //
    }

}
