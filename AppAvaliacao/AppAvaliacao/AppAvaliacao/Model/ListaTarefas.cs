using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class ListaTarefas
    {
        private string id;
        private string nome;
        private string descricao;
        private DateTime dataEntrega;
        private string idTurma;
        private string alunos;
        private int idTarefaPostada;
        private bool liberar;
        
        private static ListaTarefas instancia;

        public ListaTarefas() { }
     
        public static ListaTarefas Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ListaTarefas();
                }
                return instancia;
            }
        }
       

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public string IdTurma { get => idTurma; set => idTurma = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Alunos { get => alunos; set => alunos = value; }
        public int IdTarefaPostada { get => idTarefaPostada; set => idTarefaPostada = value; }
        public bool Liberar { get => liberar; set => liberar = value; }
    }
}
