using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppAvaliacao.Model
{
    class TarefaDAO
    {
        private ConMySql conexao = ConMySql.Instancia;
        private Turma turma = Turma.Instancia;

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
        
        //Carrega lista de tarefas da turma, na página inicial da turma
        public ObservableCollection<ListaTarefas> CarregaTurmas()
        {
            ObservableCollection<ListaTarefas> ListaTurmas = new ObservableCollection<ListaTarefas>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, nome FROM tarefa WHERE id_turma = @id_turma", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaTarefas tarefas = new ListaTarefas();
                        tarefas.Id = conexao.Rdr["id"].ToString();
                        tarefas.Nome = conexao.Rdr["nome"].ToString();
                        ListaTurmas.Add(tarefas);
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
