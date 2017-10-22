using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppAvaliacao.Model
{
    class TurmaDAO
    {
        private ConMySql conexao = ConMySql.Instancia;
        private Usuario usuario = Usuario.Instancia;

        //Método para inserção de uma turma
        public bool Inserir(string nome, int professor)
        {
            Random numRand = new Random();
            int idInscricao = numRand.Next(1000, 10000);

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO turma(id, nome, id_professor, id_inscricao) VALUES(NULL, @nome, @id_professor, @id_inscricao)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@id_professor", professor);
                    conexao.Comando.Parameters.AddWithValue("@id_inscricao", idInscricao);
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

        //Carrega lista de turmas do professor, na página inicial do professor
        public ObservableCollection<ListaTurmas> CarregaTurmas()
        {
            ObservableCollection<ListaTurmas> ListaTurmas = new ObservableCollection<ListaTurmas>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, nome FROM turma WHERE id_professor = @id_professor", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_professor", usuario.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaTurmas turma = new ListaTurmas();
                        turma.Id = conexao.Rdr["id"].ToString();
                        turma.Nome = conexao.Rdr["nome"].ToString();
                        ListaTurmas.Add(turma);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    conexao.CloseConnection();
                }
            }
            return ListaTurmas;
        }
    }
}
