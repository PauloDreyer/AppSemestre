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
        private Tarefa tarefa = Tarefa.Instancia;

        //Método para inserção de uma turma
        public bool Inserir(string nome, /*DateTime dataEntrega,*/ int turma)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO tarefa(id, nome, descricao, data_entrega, id_turma) VALUES(NULL, @nome, @descricao, NULL, @id_turma)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@decricao", nome);
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
        public ObservableCollection<ListaTarefas> CarregaTarefas()
        {
            ObservableCollection<ListaTarefas> ListaTarefas = new ObservableCollection<ListaTarefas>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, nome, descricao,'Aberta' status FROM tarefa WHERE id_turma = @id_turma", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        
                        ListaTarefas tarefas = new ListaTarefas();
                        tarefas.Id = conexao.Rdr["id"].ToString();
                        tarefas.Nome = conexao.Rdr["nome"].ToString();
                        tarefas.Descricao = conexao.Rdr["descricao"].ToString();
                        ListaTarefas.Add(tarefas);
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
            return ListaTarefas;
        }
        //

        //
        public string getDescricaoTarefa()
        {
            if (conexao.getConexao())
            {
                try{
                    conexao.Comando = new MySqlCommand("SELECT nome, descricao,'Aberta' status FROM tarefa WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();
                    
                    while (conexao.Rdr.Read())
                    {
                        tarefa.Nome = conexao.Rdr["nome"].ToString();
                        tarefa.Descricao = conexao.Rdr["descricao"].ToString();
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

            return tarefa.Descricao;
        }
        //

        //Carrega lista de tarefas postadas da turma, na página inicial da tarefa
        public ObservableCollection<ListaTarefas> CarregaTarefasPostadas()
        {
            ObservableCollection<ListaTarefas> ListaTarefasPostadas = new ObservableCollection<ListaTarefas>();
            ListaTarefas tarefasPostadas = new ListaTarefas();
            int v_id_tafefa_postada_aux = 0;
            int add_lista = 0;
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT t.id id_tarefa,t.nome tarefa, tp.id id_tarefa_postada, u.nome aluno FROM tarefa t, tarefa_postada tp, tarefas_alunos ta, usuario u WHERE tp.id_tarefa = t.id AND ta.id_tarefa_postada = tp.id AND u.id = ta.id_aluno AND t.id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        if (v_id_tafefa_postada_aux == 0)
                        {
                            v_id_tafefa_postada_aux = Convert.ToInt32(conexao.Rdr["id_tarefa_postada"].ToString());
                        }
                        else if (v_id_tafefa_postada_aux != Convert.ToInt32(conexao.Rdr["id_tarefa_postada"].ToString()))
                        {
                            ListaTarefasPostadas.Add(tarefasPostadas);
                            tarefasPostadas = new ListaTarefas();
                            add_lista = 0;
                        }

                        if (tarefasPostadas.Alunos != null)
                        {
                            tarefasPostadas.Alunos = tarefasPostadas.Alunos + ", ";
                        }
                        tarefasPostadas.Id = conexao.Rdr["id_tarefa"].ToString();
                        tarefasPostadas.Alunos = tarefasPostadas.Alunos + conexao.Rdr["aluno"].ToString();
                        tarefasPostadas.Nome = conexao.Rdr["tarefa"].ToString();
                        add_lista = 1;
                    }

                    if (add_lista.Equals(1))
                    {
                        ListaTarefasPostadas.Add(tarefasPostadas);
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
            return ListaTarefasPostadas;
        }
        //
    }
}
