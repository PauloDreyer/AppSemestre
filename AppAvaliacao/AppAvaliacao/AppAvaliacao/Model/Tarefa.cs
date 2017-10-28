using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class Tarefa
    {
        private int id;
        private string nome;
        private String descricao;
        private DateTime dataEntrega;
        private int id_aluno;
        private string arquivo;
        private static Tarefa instancia;

        private Tarefa() { }

        public static Tarefa Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Tarefa();
                }
                return instancia;
            }
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public int Id_aluno { get => id_aluno; set => id_aluno = value; }
        public string Arquivo { get => arquivo; set => arquivo = value; }
        public string Descricao { get => descricao; set => descricao = value; }
    }
}
