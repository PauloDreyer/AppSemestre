﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class TarefaPostada
    {
        private int id;
        private string tarefa;
        private int idTarefa;
        private string comentario;
        private static TarefaPostada instancia;

        public TarefaPostada() { }

        public static TarefaPostada Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new TarefaPostada();
                }
                return instancia;
            }
        }

        public int Id { get => id; set => id = value; }
        public string Tarefa { get => tarefa; set => tarefa = value; }
        public int IdTarefa { get => idTarefa; set => idTarefa = value; }
        public string Comentario { get => comentario; set => comentario = value; }
    }
}
