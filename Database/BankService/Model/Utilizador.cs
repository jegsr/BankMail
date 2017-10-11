using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankService.Model
{
    public class Utilizador
    {
        /// <summary>
        /// Classe que representa a estrutura de um Utilizador
        /// </summary>
        private string username;
        private string password;
        private string nome;
        private string email;
        private string telemovel;
        private string morada;
        private DateTime dataRegisto;

        [Key]
        public string Username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
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

        public string Telemovel
        {
            get
            {
                return telemovel;
            }

            set
            {
                telemovel = value;
            }
        }

        public string Morada
        {
            get
            {
                return morada;
            }

            set
            {
                morada = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public DateTime DataRegisto
        {
            get
            {
                return dataRegisto;
            }

            set
            {
                dataRegisto = value;
            }
        }
    }
}