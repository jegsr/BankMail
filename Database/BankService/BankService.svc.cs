using BankService.Framework;
using BankService.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{

    public class BankService : IBankService
    {
        private ProjectContext projectContext = new ProjectContext();

        /// <summary>
        /// Metodo responsavel por adicionar um novo Utilizador na Base de Dados
        /// </summary> 
        /// <param name="nome">Nome do Utilizador</param>
        /// <param name="username">Username do Utilizador</param>
        /// <param name="password">Password do Utilizador</param>
        /// <returns>Retorna um bool indicando o sucesso ou insucesso da operacao</returns>
        public bool AddRegisto(string nome, string username, string password, string morada, string telemovel)
        {


            try
            {


                Utilizador tmp = new Utilizador();

                tmp.Email = username + "@bank.pt";


                tmp.Nome = nome;
                tmp.Username = username;
                tmp.Password = password;
                tmp.DataRegisto = DateTime.Now;

                tmp.Morada = morada;
                tmp.Telemovel = telemovel;


                //Adiciona na DB
                projectContext.Utilizadores.Add(tmp);
                projectContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo responsavel por verificar se os dados de login inseridos se encontram corretos
        /// </summary>
        /// <param name="username">Username do Utilizador</param>
        /// <param name="password">Password do Utilizador</param>
        /// <returns>Retorna o Utilizador em questao caso esteja correto, retorna null caso nao esteja</returns>
        public Utilizador CheckLogin(string username, string password)
        {
            try
            {
                List<Utilizador> listUtilizadores = (from utilizador in projectContext.Utilizadores.ToList() where utilizador.Username.Equals(username) && utilizador.Password.Equals(password) select utilizador).ToList();

                if (listUtilizadores.Any())
                {
                    return listUtilizadores.ElementAt(0);
                }
            }
            catch (EntityException) { }

            return null;
        }

        /// <summary>
        /// Metodo responsavel pela edicao dos dados de um Utilizador, só é possivel editar o Nome e a Password
        /// </summary>
        /// <param name="username">Username do Utilizador</param>
        /// <param name="password">Nova Password do Utilizador</param>
        /// <param name="nome">Novo Nome do Utilizador</param>
        /// <returns></returns>
        public Utilizador EditarUtilizador(string username, string password, string nome, string morada, string telemovel)
        {

            Utilizador Utilizador = projectContext.Utilizadores.Find(username);


            if (password != "" && !Utilizador.Password.Equals(password))
            {
                Utilizador.Password = password;
            }

            if (nome != "" && !Utilizador.Nome.Equals(nome))
            {
                Utilizador.Nome = nome;
            }

            if (morada != "" && !Utilizador.Morada.Equals(morada))
            {
                Utilizador.Morada = morada;
            }

            if (telemovel != "" && !Utilizador.Telemovel.Equals(telemovel))
            {
                Utilizador.Telemovel = telemovel;
            }

            projectContext.SaveChanges();
            return Utilizador;
        }

        /// <summary>
        /// Metodo responsavél pela contagem de emails presentes na caixa de email de mensagens não lidas de um dado Utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador Loggado</param>
        /// <returns>Retorna um int correspondente ao número de mensagens existentes</returns>
        public int CountMailBoxReceber(string email)
        {
            return projectContext.Mensagens.Count(c => (c.UserDestino == email) && c.Flag == 1);
        }

        /// <summary>
        /// Metodo responsavél pela contagem de emails presentes na caixa de email de mensagens lidas de um dado Utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador Loggado</param>
        /// <returns>Retorna um int correspondente ao número de mensagens existentes</returns>
        public int CountMailBoxLidas(string email)
        {
            return projectContext.Mensagens.Count(c => c.UserDestino == email && c.Flag == 0);
        }

        /// <summary>
        /// Metodo responsavél pela contagem de emails presentes na caixa de email de mensagens enviadas de um dado Utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador Loggado</param>
        /// <returns>Retorna um int correspondente ao número de mensagens existentes</returns>
        public int CountMailBoxEnviadas(string email)
        {
            return projectContext.Mensagens.Count(c => c.UserOrigem == email && (c.Flag == 4));
        }

        /// <summary>
        /// Metodo responsavél pela contagem de emails presentes na caixa de email de mensagens em rascunhos de um dado Utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador Loggado</param>
        /// <returns>Retorna um int correspondente ao número de mensagens existentes</returns>
        public int CountMailBoxRascunhos(string email)
        {
            return projectContext.Mensagens.Count(c => c.UserOrigem == email && c.Flag == 2);
        }

        /// <summary>
        /// Metodo responsavél pela contagem de emails presentes na caixa de email de mensagens eliminadas de um dado Utilizador
        /// </summary>
        /// <param name="email">Email do Utilizador Loggado</param>
        /// <returns>Retorna um int correspondente ao número de mensagens existentes</returns>
        public int CountMailBoxEliminados(string email)
        {
            return projectContext.Mensagens.Count(c => c.UserOrigem == email && c.Flag == 3);
        }

        /// <summary>
        /// Metodo responsavel pelo envio de uma mensagem para um ou vários destinatários
        /// </summary>
        /// <param name="titulo">Título da Mensagem</param>
        /// <param name="corpo">Corpo da Mensagem</param>
        /// <param name="destino">Destino e/ou Destinos da mensagem</param>
        /// <param name="emailOrigem">Email do Utilizador que envia a Mensagem</param>
        public void AddMail(string titulo, string corpo, string destino, string emailOrigem)
        {
            List<String> tmpDestino = new List<string>();

            tmpDestino = destino.Split(';').ToList();


            int i = 0;
            while (i < tmpDestino.Count)
            {
                Mensagem tmp = new Mensagem();

                tmp.UserDestino = tmpDestino.ElementAt(i++);


                if (projectContext.Utilizadores.Count(c => c.Email.Equals(tmp.UserDestino)) > 0)
                {
                    tmp.Data = DateTime.Now;
                    tmp.Corpo = corpo;
                    tmp.Titulo = titulo;
                    tmp.UserOrigem = emailOrigem;
                    tmp.Flag = 1;

                    projectContext.Mensagens.Add(tmp);
                    projectContext.SaveChanges();

                    tmp.Flag = 4;
                    projectContext.Mensagens.Add(tmp);
                }
            }

            projectContext.SaveChanges();
        }

        /// <summary>
        /// Metodo responsavel pela eliminacao de uma dada mensagem
        /// </summary>
        /// <param name="mailId">Id da Mensagem</param>
        /// <param name="emailOrigem">Utilizador que enviou a Mensagem em questao</param>
        /// <returns>Retorna um bool que indica o sucesso ou incusso da operação</returns>
        public bool DelMail(int mailId, string emailOrigem)
        {
            Mensagem selectedMail = projectContext.Mensagens.Find(mailId);

            if (selectedMail != null && selectedMail.UserOrigem.Equals(emailOrigem))
            {
                if (selectedMail.Flag != 2 && selectedMail.Flag != 4)
                {
                    Mensagem tmp = selectedMail;
                    tmp.Flag = 3;
                    projectContext.Entry(selectedMail).CurrentValues.SetValues(tmp);
                }
                else
                {
                    projectContext.Mensagens.Remove(selectedMail);
                }

                projectContext.SaveChanges();
                return true;
            }
            return false;

        }


        /// <summary>
        /// Metodo responsavel pela visualização de uma dada Mensagem de um Utilizador
        /// </summary>
        /// <param name="mailId">Id da Mensagem</param>
        /// <param name="emailOrigem">Email do Destinatario</param>
        /// <returns>Retorna um objecto do tipo Mensagem caso exista,senão retorna null</returns>
        public Mensagem VerMail(int mailId, string emailOrigem)
        {
            Mensagem selectedMail = projectContext.Mensagens.Find(mailId);

            if (selectedMail != null && selectedMail.UserDestino.Equals(emailOrigem))
            {

                if (selectedMail.Flag == 1)
                {
                    selectedMail.Flag = 0;
                }

                projectContext.SaveChanges();

                return selectedMail;
            }

            return null;
        }

        /// <summary>
        /// Metodo responsavel por guardar uma mensagem nos rascunhos
        /// </summary>
        /// <param name="titulo">Titulo da Mensagem</param>
        /// <param name="corpo">Corpo da Mensagem</param>
        /// <param name="destino">Destinatário e/ou Destinatários da Mensagem</param>
        /// <param name="emailOrigem">Email do Utilizador que pretende enviar a Mensagem</param>
        public void SaveMail(string titulo, string corpo, string destino, string emailOrigem)
        {

            Mensagem tmp = new Mensagem();
            tmp.Data = DateTime.Now;
            tmp.Corpo = corpo;
            tmp.Titulo = titulo;
            tmp.UserDestino = destino;
            tmp.UserOrigem = emailOrigem;
            tmp.Flag = 2;

            projectContext.Mensagens.Add(tmp);

            projectContext.SaveChanges();


        }

        /// <summary>
        /// Metodo responsavel pela eliminação de um dado Contacto presente na lista de contactos de um dado Utilizador
        /// </summary>
        /// <param name="contact">Contacto a ser eliminado</param>
        /// <returns>Retorna um bool que indica o sucesso ou incusso da operação</returns>
        public bool DelContato(string UsernameOrigem, string UsernameDestino)
        {

            try
            {
                projectContext.Contactos.Remove(projectContext.Contactos.Find(UsernameOrigem, UsernameDestino));
                projectContext.SaveChanges();
                return true;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <summary>
        /// Metodo responsavel por adicionar um dado Contacto na lista de contactos de um dado Utilizador
        /// </summary>
        /// <param name="usernameOrigem">Username do Utilizador que adiciona</param>
        /// <param name="usernameDestino">Username do Utilizador que é adicionado</param>
        /// <returns>Retorna um bool que indica o sucesso ou incusso da operação</returns>
        public bool AddContato(string usernameOrigem, string usernameDestino)
        {
            try
            {
                if (projectContext.Utilizadores.Count(c => c.Username.Equals(usernameDestino)) == 0)
                {
                    throw new DbUpdateException();
                }
                var contacto = new Contato();

                contacto.UsernameOrigem = usernameOrigem;
                contacto.UsernameDestino = usernameDestino;
                projectContext.Contactos.Add(contacto);
                projectContext.SaveChanges();
                return true;
            }
            catch (DbUpdateException)
            {
                return false;
            }

        }

        /// <summary>
        /// Metodo responsavel por enviar todos Utilizadores que estejam guardados na Base de Dados
        /// </summary>
        /// <param name="loggedUser">Username do Utilizador loggado</param>
        /// <returns>Retorna uma lista de todos os Utilizadores existentes na Base de Dados</returns>
        public List<Utilizador> GetUtilizadores(string loggedUser)
        {
            return projectContext.Utilizadores.Where(c => !c.Username.Equals(loggedUser)).ToList();
        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de Utilizadores que estejam adicionados á lista de Contactos de um Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="loggedUser">Username do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Contactos que vão de encontro com a pesquisa, ou uma lista de todos os Contactos
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Utilizador> SearchMeusContatos(string pesquisa, string loggedUser)
        {
            List<Utilizador> meuContactos = GetUserContactos(loggedUser).ToList();
            if (pesquisa != "")
            {


                meuContactos = meuContactos.Where(c => c.Username.ToLower().Contains(pesquisa.ToLower()) || c.Nome.ToLower().Contains(pesquisa.ToLower()) || c.Email.ToLower().Contains(pesquisa.ToLower())
                 || c.Morada.ToLower().Contains(pesquisa.ToLower()) || c.Telemovel.ToLower().Contains(pesquisa.ToLower()) || (c.DataRegisto.Day.ToString()).Equals(pesquisa) || (c.DataRegisto.Year.ToString()).Equals(pesquisa) ||
                 (c.DataRegisto.Month.ToString()).Equals(pesquisa) || (c.DataRegisto.Date.ToString()).Contains(pesquisa)).ToList();



            }

            return meuContactos.OrderBy(c => c.Nome).ToList();

        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de mensagens na caixa de mensagens não lidas de um dado Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="email">Email do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Mensagens Não Lidas que vão de encontro com a pesquisa, ou uma lista de todas as Mensagem Não Lidas
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Mensagem> SearchMensagensNaoLidas(string pesquisa, string email)
        {
            List<Mensagem> Mensagens = projectContext.Mensagens.Where(c => (c.UserDestino == email) && c.Flag == 1).ToList();

            if ((pesquisa = pesquisa.ToLower()) != "")
            {

                Mensagens = (from Mensagem in Mensagens.ToList()
                             where (Mensagem.UserOrigem.ToLower().Contains(pesquisa) || Mensagem.Titulo.ToLower().Contains(pesquisa)
                             || (Mensagem.Data.Day.ToString()).Equals(pesquisa) || (Mensagem.Data.Year.ToString()).Equals(pesquisa) ||
                             (Mensagem.Data.Month.ToString()).Equals(pesquisa) || (Mensagem.Data.Date.ToString()).Contains(pesquisa))
                             select Mensagem
                ).ToList();

            }

            return Mensagens.OrderByDescending(c => c.Data).ToList();

        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de mensagens na caixa de mensagens lidas de um dado Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="email">Email do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Mensagens Não Lidas que vão de encontro com a pesquisa, ou uma lista de todas as Mensagem Não Lidas
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Mensagem> SearchMensagensLidas(string pesquisa, string email)
        {

            List<Mensagem> Mensagens = projectContext.Mensagens.Where(c => (c.UserDestino == email) && c.Flag == 0).ToList();
            // Estamos a apresentar a Data como <Mes>/<Dia>/<Ano>
            if ((pesquisa = pesquisa.ToLower()) != "")
            {
                Mensagens =
                (from Mensagem in Mensagens.ToList()
                 where (Mensagem.UserOrigem.ToLower().Contains(pesquisa) || Mensagem.Titulo.ToLower().Contains(pesquisa)
                 || (Mensagem.Data.Day.ToString()).Equals(pesquisa) || (Mensagem.Data.Year.ToString()).Equals(pesquisa) ||
                 (Mensagem.Data.Month.ToString()).Equals(pesquisa) || (Mensagem.Data.Date.ToString()).Contains(pesquisa))
                 select Mensagem
                ).ToList();


            }

            return Mensagens.OrderByDescending(c => c.Data).ToList();
        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de mensagens na caixa de mensagens enviadas de um dado Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="email">Email do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Mensagens Enviadas que vão de encontro com a pesquisa, ou uma lista de todas as Mensagem Enviadas
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Mensagem> SearchMensagensEnviadas(string pesquisa, string email)
        {
            List<Mensagem> Mensagens = projectContext.Mensagens.Where(c => c.UserOrigem == email && (c.Flag == 4)).ToList();

            if ((pesquisa = pesquisa.ToLower()) != "")
            {
                Mensagens =
                (from Mensagem in Mensagens.ToList()
                 where Mensagem.UserOrigem.Equals(email) && Mensagem.Flag.Equals(4) && (Mensagem.UserDestino.ToLower().Contains(pesquisa) || Mensagem.Titulo.ToLower().Contains(pesquisa)
                 || (Mensagem.Data.Day.ToString()).Equals(pesquisa) || (Mensagem.Data.Year.ToString()).Equals(pesquisa) ||
                 (Mensagem.Data.Month.ToString()).Equals(pesquisa) || (Mensagem.Data.Date.ToString()).Contains(pesquisa))
                 select Mensagem
                ).ToList();


            }
            return Mensagens.OrderByDescending(c => c.Data).ToList();
        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de mensagens na caixa de mensagens de rascunhos de um dado Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="email">Email do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Mensagens de Rascunhos que vão de encontro com a pesquisa, ou uma lista de todas as Mensagem Rascunhos
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Mensagem> SearchMensagensRascunhos(string pesquisa, string email)
        {
            List<Mensagem> Mensagens = projectContext.Mensagens.Where(c => c.UserOrigem == email && c.Flag == 2).ToList();
            if ((pesquisa = pesquisa.ToLower()) != "")
            {
                Mensagens =
                 (from Mensagem in Mensagens.ToList()
                  where Mensagem.UserDestino.Equals(email) && Mensagem.Flag.Equals(2) && (Mensagem.UserOrigem.ToLower().Contains(pesquisa) || Mensagem.Titulo.ToLower().Contains(pesquisa)
                  || (Mensagem.Data.Day.ToString()).Equals(pesquisa) || (Mensagem.Data.Year.ToString()).Equals(pesquisa) ||
                  (Mensagem.Data.Month.ToString()).Equals(pesquisa) || (Mensagem.Data.Date.ToString()).Contains(pesquisa))
                  select Mensagem
                 ).ToList();


            }
            return Mensagens.OrderByDescending(c => c.Data).ToList();

        }

        /// <summary>
        /// Metodo responsavel pela pesquisa de mensagens na caixa de mensagens eliminadas de um dado Utilizador
        /// </summary>
        /// <param name="pesquisa">Parâmetro a ser pesquisado</param>
        /// <param name="email">Email do Utilizador loggado</param>
        /// <returns>Retorna uma lista de Mensagens Eliminadas que vão de encontro com a pesquisa, ou uma lista de todas as Mensagem Eliminadas
        /// de um Utilizador caso a pesquisa esteja em branco</returns>
        public List<Mensagem> SearchMensagensEliminados(string pesquisa, string email)
        {

            List<Mensagem> Mensagens = projectContext.Mensagens.Where(c => c.UserOrigem == email && c.Flag == 3).ToList();
            if ((pesquisa = pesquisa.ToLower()) != "")
            {
                Mensagens =
                (from Mensagem in Mensagens.ToList()
                 where Mensagem.UserDestino.Equals(email) && Mensagem.Flag.Equals(3) && (Mensagem.UserOrigem.ToLower().Contains(pesquisa) || Mensagem.Titulo.ToLower().Contains(pesquisa)
                 || (Mensagem.Data.Day.ToString()).Equals(pesquisa) || (Mensagem.Data.Year.ToString()).Equals(pesquisa) ||
                 (Mensagem.Data.Month.ToString()).Equals(pesquisa) || (Mensagem.Data.Date.ToString()).Contains(pesquisa))
                 select Mensagem
                ).ToList();


            }

            return Mensagens.OrderByDescending(c => c.Data).ToList();
        }


        /// <summary>
        /// Metodo responsavel pela obtenção de todos os Utilizadores que um dado Utilizador tem adicionados na sua Lista de Contactos
        /// </summary>
        /// <param name="loggedUser">Username do Utilizador loggado</param>
        /// <returns>Lista do Utilizadores</returns>
        private List<Utilizador> GetUserContactos(string loggedUser)
        {

            List<Contato> Contactos =
                (from Contacto in projectContext.Contactos.ToList()
                 where Contacto.UsernameOrigem.Equals(loggedUser)
                 select Contacto
                 ).ToList();

            List<Utilizador> meusContactos = new List<Utilizador>();

            foreach (var contacto in Contactos)
            {
                var tmpUtilizador = new Utilizador();

                if ((projectContext.Utilizadores.Count(c => c.Username.Equals(contacto.UsernameDestino))) > 0)
                {
                    tmpUtilizador = projectContext.Utilizadores.Where(c => c.Username.Equals(contacto.UsernameDestino)).First();

                    meusContactos.Add(tmpUtilizador);
                }
            }

            return meusContactos.ToList();

        }

        /// <summary>
        /// Metodo responsavel por eliminar Mensagens, Contactos e o registo do próprio Utilizador, bem como a eliminação deste Utilizador da lista
        /// de Contactos de outros Utilizadores.
        /// </summary>
        /// <param name="loggedUser">Username do Utilizador loggado</param>
        /// <returns>Retorna um bool que indica o sucesso ou incusso da operação</returns>
        public bool DelUtilizador(string loggedUser)
        {
            var tmpUtilizador = new Utilizador();

            tmpUtilizador = projectContext.Utilizadores.Where(c => c.Username.Equals(loggedUser)).First();

            if (tmpUtilizador != null)
            {
                List<Contato> Contactos =
                   (from Contacto in projectContext.Contactos.ToList()
                    where Contacto.UsernameOrigem.Equals(tmpUtilizador.Username) || Contacto.UsernameDestino.Equals(tmpUtilizador.Username)
                    select Contacto
                    ).ToList();

                //Apaga todos os Contactos do Utilizador
                foreach (var contacto in Contactos)
                {

                    DelContato(contacto.UsernameOrigem, contacto.UsernameDestino);
                }

                //Todas as Mensagens que sejam para este user
                List<Mensagem> Mensagens =
               (from Mensagem in projectContext.Mensagens.ToList()
                where Mensagem.UserOrigem.Equals(tmpUtilizador.Email)
                select Mensagem
                ).ToList();

                foreach (var mensagem in Mensagens)
                {

                    projectContext.Mensagens.Remove(mensagem);
                }

                projectContext.Utilizadores.Remove(tmpUtilizador);
                projectContext.SaveChanges();

                return true;
            }

            return false;

        }

        /// <summary>
        /// Metodo responsavel pela obtenção dos emails pertencentes ao Contactos que um Utilizador tem adicionados nos seus Contactos
        /// </summary>
        /// <param name="loggedUser">Username do Utilizador Loggado</param>
        /// <returns>Lista de Strings contendo os emails</returns>
        public List<String> GetEmailContactos(string loggedUser)
        {

            List<Utilizador> UtilizadoresContactos = GetUserContactos(loggedUser);

            List<String> EmailContactos = new List<String>();

            foreach (var contacto in UtilizadoresContactos)
            {
                EmailContactos.Add(contacto.Email);
            }

            return EmailContactos.ToList();
        }
    }
}
