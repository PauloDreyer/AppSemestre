using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class Turma
    {
        private int id;
        private string nome;
        private int id_professor;
        private int id_inscricao;
        private static Turma instancia;

        private Turma() { }

        public static Turma Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new Turma();
                }
                return instancia;
            }
        }

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Id_professor { get => id_professor; set => id_professor = value; }
        public int Id_inscricao { get => id_inscricao; set => id_inscricao = value; }
    }
}
