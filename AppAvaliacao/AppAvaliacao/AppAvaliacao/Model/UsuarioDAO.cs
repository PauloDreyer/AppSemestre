using MySql.Data.MySqlClient;
using System;
using AppAvaliacao.Model;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Security.Cryptography;

namespace AppAvaliacao.Model
{
    class UsuarioDAO
    {
        private ConMySql conexao = ConMySql.Instancia;
        private Usuario usuario = Usuario.Instancia;
        private string hash = "appAvaliacao";

        // Encriptografa a senha
        private string EncryptSenha(string p_senha)
        {
            byte[] data = UTF8Encoding.UTF8.GetBytes(p_senha);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateEncryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return  Convert.ToBase64String(results, 0, results.Length);
                }
            }
        }
        //

        // Decriptografa a senha
        private string DescryptSenha(string p_senha)
        {
            byte[] data = Convert.FromBase64String(p_senha);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return UTF8Encoding.UTF8.GetString(results);
                }
            }
        }
        //

        //
        public bool ValidarSenha(string p_senha, string p_contraSenha)
        {
            if (!p_senha.Equals(p_contraSenha))
            {
                return false;
            }
            return true;
        }
        //

        //Método de Login 
        public bool Logar(string email, string senha, out string tipo)
        {
            tipo = "";
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, nome, matricula, email, senha, tipo FROM usuario WHERE email = @email AND senha = @senha", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@email", email);
                    conexao.Comando.Parameters.AddWithValue("@senha", EncryptSenha(senha));
                    conexao.Rdr = conexao.Comando.ExecuteReader();
                    while (conexao.Rdr.Read())
                    {
                        tipo = conexao.Rdr["tipo"].ToString();
                        usuario.Id = conexao.Rdr["id"].ToString();
                        usuario.Nome = conexao.Rdr["nome"].ToString();
                        usuario.Email = conexao.Rdr["email"].ToString();
                        usuario.Matricula = conexao.Rdr["matricula"].ToString();
                        usuario.Senha = DescryptSenha(conexao.Rdr["senha"].ToString());
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
                    conexao.Comando.Parameters.AddWithValue("@senha", EncryptSenha(senha));
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

        //
        public bool Alterar(string nome, int matricula, string email, string senha)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("UPDATE usuario SET nome = @nome, matricula = @matricula, email = @email, senha = @senha WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", usuario.Id);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@matricula", matricula);
                    conexao.Comando.Parameters.AddWithValue("@email", email);
                    conexao.Comando.Parameters.AddWithValue("@senha", EncryptSenha(senha));
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
