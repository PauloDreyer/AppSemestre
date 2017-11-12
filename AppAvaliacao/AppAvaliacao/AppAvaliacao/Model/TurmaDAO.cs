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


        public Turma GetTurmaByIdIsncricao(int idInscricao)
        {
            Turma turma = Turma.Instancia;

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT id, nome, id_professor FROM turma WHERE id_inscricao = @id_inscricao", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_inscricao", idInscricao);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        turma.Id = Convert.ToInt32(conexao.Rdr["id"].ToString());
                        turma.Nome = conexao.Rdr["nome"].ToString();
                        turma.Id_professor = Convert.ToInt32(conexao.Rdr["id_professor"].ToString());
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
            return turma;
        }

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

        //Método para vincular um aluno a uma turma
        public bool InserirAlunoTurma(int idInscricao, int idAluno)
        {

            int idTurma = GetTurmaByIdIsncricao(idInscricao).Id;

            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("INSERT INTO turma_aluno(id_turma, id_aluno) VALUES(@id_turma, @id_aluno)", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", idTurma);
                    conexao.Comando.Parameters.AddWithValue("@id_aluno", idAluno);
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
                    if (usuario.Tipo.Equals("P"))
                    {
                        conexao.Comando = new MySqlCommand("SELECT id, nome, id_inscricao FROM turma WHERE id_professor = @id", conexao.Conexao);
                    }
                    else
                    {
                        conexao.Comando = new MySqlCommand("SELECT id, nome, id_inscricao FROM turma t, turma_aluno ta WHERE t.id = ta.id_turma AND ta.id_aluno = @id", conexao.Conexao);
                    }
                    conexao.Comando.Parameters.AddWithValue("@id", usuario.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaTurmas turma = new ListaTurmas();
                        turma.Id = conexao.Rdr["id"].ToString();
                        turma.Nome = conexao.Rdr["nome"].ToString();
                        turma.IdInscricao = conexao.Rdr["id_inscricao"].ToString();
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
        //

        //Carrega lista de alunos de uma turma
        public ObservableCollection<ListaAlunos> CarregaAlunos()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();
            Turma turma = Turma.Instancia;
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT u.id, u.nome aluno, u.matricula FROM turma_aluno ta, usuario u WHERE u.id = ta.id_aluno AND ta.id_turma = @id", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id", turma.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaAlunos listaAlunos = new ListaAlunos();
                        listaAlunos.Id = Convert.ToInt32(conexao.Rdr["id"].ToString());
                        listaAlunos.Nome = conexao.Rdr["aluno"].ToString();
                        listaAlunos.Matricula = Convert.ToInt32(conexao.Rdr["matricula"].ToString());
                        listaAlunos.Selecionado = false;
                        ListaAlunos.Add(listaAlunos);
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
        public ObservableCollection<ListaAlunos> CarregaNotasTurma()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();
            Turma turma = Turma.Instancia;
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT  u.id, u.nome aluno, SUM(nt.nota) nota FROM notas_tarefas nt, tarefa t, usuario u WHERE nt.id_tarefa = t.id AND u.id = nt.id_aluno AND t.id_turma = @id_turma GROUP BY u.id, u.nome", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaAlunos listaAlunos = new ListaAlunos();
                        listaAlunos.Nome = conexao.Rdr["aluno"].ToString();
                        listaAlunos.Nota = conexao.Rdr["nota"].ToString();
                        ListaAlunos.Add(listaAlunos);
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
        public ObservableCollection<ListaAlunos> CarregaNotasAluno()
        {
            ObservableCollection<ListaAlunos> ListaAlunos = new ObservableCollection<ListaAlunos>();
            Turma turma = Turma.Instancia;
            if (conexao.getConexao())
            {
                try
                {
                    conexao.Comando = new MySqlCommand("SELECT SUM(nt.nota) nota FROM notas_tarefas nt, tarefa t WHERE nt.id_tarefa = t.id AND t.id_turma = @id_turma  AND nt.id_aluno = @id_aluno", conexao.Conexao);
                    conexao.Comando.Parameters.AddWithValue("@id_turma", turma.Id);
                    conexao.Comando.Parameters.AddWithValue("@id_aluno", usuario.Id);
                    conexao.Rdr = conexao.Comando.ExecuteReader();

                    while (conexao.Rdr.Read())
                    {
                        ListaAlunos listaAlunos = new ListaAlunos();
                        listaAlunos.Nome = "";
                        listaAlunos.Nota = conexao.Rdr["nota"].ToString();
                        ListaAlunos.Add(listaAlunos);
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
        //SELECT id_aluno, SUM(nota) FROM `notas_tarefas` WHERE id_tarefa = 1 GROUP BY id_aluno
    }
}
