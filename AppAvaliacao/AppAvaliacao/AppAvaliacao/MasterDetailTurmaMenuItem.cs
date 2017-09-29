﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppAvaliacao
{

    public class MasterDetailTurmaMenuItem
    {
        public MasterDetailTurmaMenuItem()
        {
            TargetType = typeof(MasterDetailTurmaDetail);
        }
        public int Id { get; set; }
        public string Icon { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}