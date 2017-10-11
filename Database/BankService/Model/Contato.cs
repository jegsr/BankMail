using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BankService.Model
{
    /// <summary>
    /// Classe que representa a estrutura de um Contato
    /// </summary>
    public class Contato
    {
        private string usernameOrigem;
        private string usernameDestino;

        [Key, Column(Order = 0)]
        public string UsernameOrigem
        {
            get
            {
                return usernameOrigem;
            }

            set
            {
                usernameOrigem = value;
            }
        }
        [Key, Column(Order = 1)]
        public string UsernameDestino
        {
            get
            {
                return usernameDestino;
            }

            set
            {
                usernameDestino = value;
            }
        }
    }
}