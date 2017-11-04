using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvaliacao.ViewController.Tarefa
{

    public class MasterDetailTarefaProfessorMenuItem
    {
        public MasterDetailTarefaProfessorMenuItem()
        {
            TargetType = typeof(MasterDetailTarefaProfessorDetail);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}