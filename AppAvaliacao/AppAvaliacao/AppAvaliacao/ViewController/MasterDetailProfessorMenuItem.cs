using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvaliacao
{

    public class MasterDetailProfessorMenuItem
    {
        public MasterDetailProfessorMenuItem()
        {
            TargetType = typeof(MasterDetailProfessorDetail);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}