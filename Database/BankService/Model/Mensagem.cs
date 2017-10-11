using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankService.Model
{
    /// <summary>
    /// Classe que representa a estrutura de uma Mensagem
    /// </summary>
    public class Mensagem
    {
        private int id;
        private string userOrigem;
        private string userDestino;
        private DateTime data;
        private string titulo;
        private string corpo;
        private int flag; // 0-Lida :: 1-Não Lida :: 2-Rascunhos :: 3-Eliminadas :: 4-Enviadas


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

        public string UserOrigem
        {
            get
            {
                return userOrigem;
            }

            set
            {
                userOrigem = value;
            }
        }


        public string UserDestino
        {
            get
            {
                return userDestino;
            }

            set
            {
                userDestino = value;
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

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
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

        public int Flag
        {
            get
            {
                return flag;
            }

            set
            {
                flag = value;
            }
        }
    }
}