using System;
using System.Collections.Generic;
using System.Text;

namespace AppAvaliacao.Model
{
    class Usuario
    {
        private string id;
        private string email;
        private string tipo;
        private static Usuario instancia;

        private Usuario() { }

        public static Usuario Instancia
        {
            get
            {
                if(instancia == null)
                {
                    instancia = new Usuario();
                }
                return instancia;
            }
        }

        public string Id { get => id; set => id = value; }
        public string Email { get => email; set => email = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        
    }
}
