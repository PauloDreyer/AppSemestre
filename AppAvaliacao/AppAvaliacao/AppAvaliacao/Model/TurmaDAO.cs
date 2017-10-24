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
    }
}
