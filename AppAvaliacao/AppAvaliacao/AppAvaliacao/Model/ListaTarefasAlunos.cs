using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class ListaTarefasAlunos
    {
        private int idAluno;
        private int idTarefa;

        public int IdAluno { get => idAluno; set => idAluno = value; }
        public int IdTarefa { get => idTarefa; set => idTarefa = value; }
    }
}
