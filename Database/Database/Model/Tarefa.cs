using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Model
{
    /// <summary>
    /// Classe que representa a estrutura de uma Tarefa
    /// </summary>
    class Tarefa
    {
        private int id;
        private string user;
        private string nome;
        private string corpo;
        private DateTime data;

        [Key]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public string Corpo
        {
            get
            {
                return corpo;
            }

            set
            {
                corpo = value;
            }
        }

        public DateTime Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }


        public string User
        {
            get
            {
                return user;
            }

            set
            {
                user = value;
            }
        }
    }
}
