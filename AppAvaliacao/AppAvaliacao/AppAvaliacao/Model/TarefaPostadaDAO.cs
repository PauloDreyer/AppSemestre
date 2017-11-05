using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace AppAvaliacao.Model
{
    class TarefaPostadaDAO
    {
        private ConMySql conexao = ConMySql.Instancia;
        private TarefaPostada taferaPostada = TarefaPostada.Instancia;

        // Retorna o conteúdo da Tarefa Postada
        public string ExibirTarefa()
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT tarefa, id_tarefa FROM tarefa_postada WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", taferaPostada.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        taferaPostada.Tarefa = conexao.Rdr["tarefa"].ToString();
                        taferaPostada.IdTarefa = Convert.ToInt32(conexao.Rdr["id_tarefa"].ToString());
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

            return taferaPostada.Tarefa;
        }
        //

        // Retorna os Alunos de uma Tarefa
        public ObservableCollection<ListaAlunos> CarregaAlunos()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT u.id, u.nome, u.matricula FROM tarefa_postada tp, tarefas_alunos ta, usuario u WHERE ta.id_tarefa_postada = tp.id AND u.id = ta.id_aluno AND tp.id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", taferaPostada.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {

                        ListaAlunos alunos = new ListaAlunos();
                        alunos.Id = Convert.ToInt32(conexao.Rdr["id"].ToString());
                        alunos.Nome = conexao.Rdr["nome"].ToString();
                        alunos.Matricula = Convert.ToInt32(conexao.Rdr["matricula"].ToString());
                        ListaAlunos.Add(alunos);
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
            return ListaAlunos;
        }
        //

        //
        public void PostarComentario(string comentario)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("UPDATE tarefa_postada SET comentario = @comentario WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", taferaPostada.Id);
                    conexao.Comando.Parameters.AddWithValue("@comentario", comentario);
                    conexao.Comando.ExecuteNonQuery();

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
        }
        //

        //Insere a nota da tarefa para cada aluno
        public void PostarNotas(decimal nota)
        {
            ObservableCollection<ListaTarefasAlunos> ListarTarefasAlunos = new ObservableCollection<ListaTarefasAlunos>();
            int p_count = 0;

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT tp.id_tarefa, ta.id_aluno FROM tarefa_postada tp, tarefas_alunos ta WHERE ta.id_tarefa_postada = tp.id AND tp.id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", taferaPostada.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaTarefasAlunos tarefasAlunos = new ListaTarefasAlunos();
                        tarefasAlunos.IdAluno = Convert.ToInt32(conexao.Rdr["id_aluno"].ToString());
                        tarefasAlunos.IdTarefa = Convert.ToInt32(conexao.Rdr["id_tarefa"].ToString());
                        ListarTarefasAlunos.Add(tarefasAlunos);
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

            while (ListarTarefasAlunos.Count > p_count)
            {
                if (conexao.getConexao())
                {
                    try
                    {
                        conexao.Comando = new MySqlCommand("INSERT INTO notas_tarefas(id, nota, id_tarefa, id_aluno) VALUES(NULL, @nota, @idTarefa, @idAluno)", conexao.Conexao);
                        conexao.Comando.Parameters.AddWithValue("@nota", nota);
                        conexao.Comando.Parameters.AddWithValue("@idTarefa", ListarTarefasAlunos[p_count].IdTarefa);
                        conexao.Comando.Parameters.AddWithValue("@idAluno", ListarTarefasAlunos[p_count].IdAluno);
                        conexao.Comando.ExecuteNonQuery();
                        p_count = p_count + 1;
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
            }
        }
        //
    }
}
