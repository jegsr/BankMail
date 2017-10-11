using BankService.Model;
using Database.MVVM;
using Database.ServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModel
{
    /// <summary>
    /// Classe que representa o Modelo da View de Login e Registo
    /// </summary>
    class VMlogin : BaseModel
    {
        private BankServiceClient serv = new BankServiceClient();
        private Utilizador userLogged;

        /// <summary>
        /// Instânciação e obtenção do Utilizador actualmente loggado
        /// </summary>
        public Utilizador UserLogged
        {
            get
            {
                return userLogged;
            }

            set
            {
                userLogged = value;
            }
        }

        /// <summary>
        /// Metodo responsavél pelo login
        /// </summary>
        /// <param name="username">Username do Utilizador</param>
        /// <param name="password">Password do Utilizador</param>
        /// <returns>Bool que indica o sucesso ou insucesso</returns>
        internal bool processLogin(string username, string password)
        {
            if ((UserLogged = serv.CheckLogin(username, password)) != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo responsavél pelo registo de um novo Utilizador
        /// </summary>
        /// <param name="nome">Nome de Utilizador</param>
        /// <param name="username">Username do Utilizador</param>
        /// <param name="password">Password do Utilizador</param>
        /// <returns></returns>
        internal bool addRegisto(string nome, string username, string password, string morada, string telemovel)
        {
            return this.serv.AddRegisto(nome, username, password, morada, telemovel);
        }

        
    }
}
