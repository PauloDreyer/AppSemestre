using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    public class ListaTurmas
    {

        private string id;
        private string nome;
        private string id_professor;
        private string idInscricao;
        private string status;

        public string Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Id_professor { get => id_professor; set => id_professor = value; }
        public string IdInscricao { get => idInscricao; set => idInscricao = value; }
        public string Status { get => status; set => status = value; }
    }
}
