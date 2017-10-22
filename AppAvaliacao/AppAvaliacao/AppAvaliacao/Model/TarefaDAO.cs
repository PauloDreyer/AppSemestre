using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class TarefaDAO
    {
        private ConMySql conexao = ConMySql.Instancia;

        //Método para inserção de uma turma
        public bool Inserir(string nome, /*DateTime dataEntrega,*/ int turma)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO tarefa(id, nome, data_entrega, id_turma) VALUES(NULL, @nome, NULL, @id_turma)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                  //  conexao.Comando.Parameters.AddWithValue("@data_entrega", dataEntrega);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma);
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
        /*
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
        */
    }
}
