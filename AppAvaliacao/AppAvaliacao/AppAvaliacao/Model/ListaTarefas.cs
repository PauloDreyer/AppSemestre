using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class ListaTarefas
    {
        private string id;
        private string nome;
        private DateTime dataEntrega;
        private string idTurma;

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public DateTime DataEntrega { get => dataEntrega; set => dataEntrega = value; }
        public string IdTurma { get => idTurma; set => idTurma = value; }
    }
}
