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
        private static MySqlConnection conexao;
        private MySqlCommand comando;
        private MySqlDataReader rdr;
        private static ConMySql instancia;
        private Usuario usuario = Usuario.Instancia;
        private string server = "sql10.freemysqlhosting.net";
        private UInt32 porta = 3306;
        private string dataBase = "sql10201607";
        private string userId = "sql10201607";
        private string password = "V29vyeRzhX";

        public MySqlCommand Comando { get => comando; set => comando = value; }
        public MySqlDataReader Rdr { get => rdr; set => rdr = value; }
        public MySqlConnection Conexao { get => conexao; set => conexao = value; }

        /*
private string server = "fit.faccat.br";
private UInt32 porta = 3306;
private string dataBase = "a1140740";
private string userId = "a1140740";
private string password = "ELHj6825BE";
*/


        public static ConMySql Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ConMySql();
                }
                return instancia;
            }
        }
        //Método para estabelecer uma conexão.

        public bool getConexao()
        {
            if (conexao == null)
            {
                if (TryConnection(out string erro))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (conexao.State == ConnectionState.Open){

                return true;
            }
            else
            {
                conexao.Open();
                return true;
            }

        }
        public void CloseConnection()
        {
            conexao.Close();
        }


        public bool TryConnection(out string Error)
        {
            Builder.Server = server;
            Builder.Database = dataBase;
            Builder.UserID = userId;
            Builder.Password = password;
            Builder.Port = porta;
            
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
    }
}
