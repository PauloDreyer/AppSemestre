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
        private Tarefa tarefa = Tarefa.Instancia;
        private Usuario usuario = Usuario.Instancia;

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
        public void PostarTarefa(string conteudo)
        {
            int v_id_tarefa_postada = 0;

            if (conteudo != null)
            {
                if (conexao.getConexao())
                {
                    try
                    {
                        conexao.Comando = new MySqlCommand("INSERT INTO tarefa_postada(id, tarefa, id_tarefa) VALUES(NULL, @tarefa, @id_tarefa)", conexao.Conexao);
                        conexao.Comando.Parameters.AddWithValue("@tarefa", conteudo);
                        conexao.Comando.Parameters.AddWithValue("@id_tarefa", tarefa.Id);
                        conexao.Comando.ExecuteNonQuery();
                        v_id_tarefa_postada = Convert.ToInt32(conexao.Comando.LastInsertedId);

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

                if (v_id_tarefa_postada > 0)
                {
                    if (conexao.getConexao())
                    {
                        try
                        {
                            conexao.Comando = new MySqlCommand("INSERT INTO tarefas_alunos(id_tarefa_postada, id_aluno) VALUES(@id_tarefa_postada, @id_aluno)", conexao.Conexao);
                            conexao.Comando.Parameters.AddWithValue("@id_tarefa_postada", v_id_tarefa_postada);
                            conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);
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
            }
        }
        //

        //
        public bool ExisteTarefaPostada()
        {
            bool v_existe = false;

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT tp.id_tarefa, ta.id_aluno FROM tarefa_postada tp, tarefas_alunos ta WHERE ta.id_tarefa_postada = tp.id AND tp.id_tarefa = @id_tarefa AND ta.id_aluno = @id_aluno", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_tarefa", tarefa.Id);
                    conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read() & !v_existe)
                    {
                        v_existe = true;
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

            if (v_existe)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        //
        public TarefaPostada GetTarefaPostada()
        {

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT tp.id, tp.tarefa, tp.id_tarefa FROM tarefa_postada tp, tarefas_alunos ta WHERE ta.id_tarefa_postada = tp.id AND tp.id_tarefa = @id_tarefa AND ta.id_aluno = @id_aluno", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_tarefa", tarefa.Id);
                    conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        taferaPostada.Id = Convert.ToInt32(conexao.Rdr["id"].ToString());
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

            return taferaPostada;
        }
        //

        //
        //
        public void AtualizarTarefaPostada(string tarefa)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("UPDATE tarefa_postada SET tarefa = @tarefa WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", taferaPostada.Id);
                    conexao.Comando.Parameters.AddWithValue("@tarefa", tarefa);
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
