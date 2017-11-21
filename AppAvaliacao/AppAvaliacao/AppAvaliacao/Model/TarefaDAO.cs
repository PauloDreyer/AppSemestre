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
        private Usuario usuario = Usuario.Instancia;

        //Método para inserção de uma turma
        public bool Inserir(string nome, string descricao /*DateTime dataEntrega,*/, int turma)
        {
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO tarefa(id, nome, descricao, data_entrega, id_turma, status) VALUES(NULL, @nome, @descricao, NULL, @id_turma, @status)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@descricao", descricao);
                    //  conexao.Comando.Parameters.AddWithValue("@data_entrega", dataEntrega);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma);
                    conexao.Comando.Parameters.AddWithValue("@status", "A");
                    conexao.Comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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
                    conexao.Comando = new MySqlCommand("SELECT id, nome, descricao, status FROM tarefa WHERE id_turma = @id_turma", conexao.Conexao);
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

        // Retorna a Descrição da Tarefa
        public string getDescricaoTarefa()
        {
            string status;

            if (conexao.getConexao())
            {
                try{
                    conexao.Comando = new MySqlCommand("SELECT nome, descricao, status FROM tarefa WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();
                    
                    while (conexao.Rdr.Read())
                    {
                        tarefa.Nome = conexao.Rdr["nome"].ToString();
                        tarefa.Descricao = conexao.Rdr["descricao"].ToString();
                        status = conexao.Rdr["status"].ToString();
                        if(status.Equals("A"))
                        {
                            tarefa.Status = "Aberta";
                        }
                        else
                        {
                            tarefa.Status = "Cancelada";
                        } 
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
                    if (usuario.Tipo.Equals("P"))
                    {
                        conexao.Comando = new MySqlCommand("SELECT t.id id_tarefa,t.nome tarefa, tp.id id_tarefa_postada, u.nome aluno FROM tarefa t, tarefa_postada tp, tarefas_alunos ta, usuario u WHERE tp.id_tarefa = t.id AND ta.id_tarefa_postada = tp.id AND u.id = ta.id_aluno AND t.id = @id ORDER BY tp.id", conexao.Conexao);
                        conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                        conexao.Rdr = conexao.Comando.ExecuteReader();
                    }
                    else
                    {
                        conexao.Comando = new MySqlCommand("SELECT t.id id_tarefa,t.nome tarefa, tp.id id_tarefa_postada, u.nome aluno FROM tarefa t, tarefa_postada tp, tarefas_alunos ta, usuario u WHERE tp.id_tarefa = t.id AND ta.id_tarefa_postada = tp.id AND u.id = ta.id_aluno AND t.id = @id AND NOT EXISTS(SELECT NULL FROM tarefas_alunos tal WHERE tal.id_aluno = @id_aluno AND tal.id_tarefa_postada = ta.id_tarefa_postada) ORDER BY tp.id", conexao.Conexao);
                        conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                        conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);
                        conexao.Rdr = conexao.Comando.ExecuteReader();
                    }
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
                            v_id_tafefa_postada_aux = Convert.ToInt32(conexao.Rdr["id_tarefa_postada"].ToString());
                        }

                        if (tarefasPostadas.Alunos != null)
                        {
                            tarefasPostadas.Alunos = tarefasPostadas.Alunos + ", ";
                        }
                        tarefasPostadas.Id = conexao.Rdr["id_tarefa"].ToString();
                        tarefasPostadas.Alunos = tarefasPostadas.Alunos + conexao.Rdr["aluno"].ToString();
                        tarefasPostadas.Nome = conexao.Rdr["tarefa"].ToString();
                        tarefasPostadas.IdTarefaPostada = Convert.ToInt32(conexao.Rdr["id_tarefa_postada"].ToString());
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

        //
        public bool GetStatusTarefa()
        {
            string v_status = "C";

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT status FROM tarefa WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        v_status = conexao.Rdr["status"].ToString();
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

            if (v_status.Equals("A"))
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
        public bool GetTarefaLiberada()
        {
            string v_liberada = "N";

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT lib_avaliacao FROM tarefa WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        v_liberada = conexao.Rdr["lib_avaliacao"].ToString();
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

            if (v_liberada.Equals("S"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //

        //Método para Liberar/Bloquear Avaliação
        public bool LibBloAvaliacao(bool opcao)
        {
            string p_opcao;

            if (conexao.getConexao())
            {

                if (opcao)
                {
                    p_opcao = "S";
                }
                else
                {
                    p_opcao = "N";
                }
                try
                {
                    conexao.Comando = new MySqlCommand("UPDATE tarefa SET lib_avaliacao = @opcao WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@opcao", p_opcao);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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
        public bool AlterarTarefa(string nome, string descricao, string status)
        {
            string p_status = status;

            if (conexao.getConexao())
            {
                if (p_status.Equals("Aberta"))
                {
                    p_status = "A";
                }
                else
                {
                    p_status = "C";
                }
                try
                {
                    conexao.Comando = new MySqlCommand("UPDATE tarefa SET nome = @nome, descricao = @descricao, status = @status WHERE id = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@nome", nome);
                    conexao.Comando.Parameters.AddWithValue("@descricao", descricao);
                    conexao.Comando.Parameters.AddWithValue("@status", p_status);
                    conexao.Comando.Parameters.AddWithValue("@id", tarefa.Id);
                    conexao.Comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
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

        // Retorna os Alunos de uma Tarefa
        public ObservableCollection<ListaAlunos> CarregaNotasTarefas()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT u.id, u.nome, SUM(nt.nota) nota FROM notas_tarefas nt, usuario u WHERE u.id = nt.id_aluno AND nt.id_tarefa = @id_tarefa GROUP BY u.id, u.nome", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_tarefa", tarefa.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {

                        ListaAlunos alunos = new ListaAlunos();
                        alunos.Nome = conexao.Rdr["nome"].ToString();
                        alunos.Nota = conexao.Rdr["nota"].ToString();
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

        // Retorna as Notas de uma Tarefa do Grupo ou do Aluno
        public ObservableCollection<ListaAlunos> CarregaNotasTarefasGrupo()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT u.id, u.nome, SUM(nt.nota) nota FROM notas_tarefas nt ,usuario u WHERE u.id = nt.id_aluno AND nt.id_tarefa = @id_tarefa AND u.id IN (SELECT ta.id_aluno FROM tarefas_alunos ta WHERE ta.id_tarefa_postada IN (SELECT tal.id_tarefa_postada FROM tarefas_alunos tal ,tarefa_postada tp WHERE tp.id_tarefa = nt.id_tarefa AND tal.id_tarefa_postada = tp.id AND tal.id_aluno = @id_aluno)) GROUP BY u.id, u.nome", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_tarefa", tarefa.Id);
                    conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);

                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {

                        ListaAlunos alunos = new ListaAlunos();
                        alunos.Nome = conexao.Rdr["nome"].ToString();
                        alunos.Nota = conexao.Rdr["nota"].ToString();
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
    }
}
