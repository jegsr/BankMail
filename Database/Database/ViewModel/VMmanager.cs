using BankService.Model;
using Database.MVVM;
using Database.ServiceReference;
using Database.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;

namespace Database.ViewModel
{
    /// <summary>
    /// Classe que representa o Modelo de todas as Views excepto a de Registo, Login e Tarefas
    /// </summary>
    class VMmanager : BaseModel
    {
        private BankServiceClient serv;

        private Mensagem selectedMail;

        private Utilizador selectedUtilizadorAdicionar ;
        private Utilizador selectedContacto;
        private Utilizador userLogged;

        private String pesquisaContactos;
        private String pesquisaMensagensNaoLidas;
        private String pesquisaMensagensLidas;
        private String pesquisaMensagensEnviadas;
        private String pesquisaMensagensRascunhos;
        private String pesquisaMensagensEliminados;

        public VMmanager(Utilizador logged)
        {
            this.serv = new BankServiceClient();
            SelectedMail = null;
            SelectedContacto = null;
            SelectedUtilizadorAdicionar = null;
            UserLogged = logged;

            PesquisaContactos = "";
            PesquisaMensagensNaoLidas = "";
            PesquisaMensagensLidas = "";
            PesquisaMensagensEnviadas = "";
            PesquisaMensagensRascunhos = "";
            PesquisaMensagensEliminados = "";
            initCommand();
        }

        /// <summary>
        /// Metodo para inicialização dos comandos
        /// </summary>
        internal void initCommand()
        {         
            this.DelContato = new RelayCommand(delContato, param => condicaoApagar);
            this.AddContato = new RelayCommand(addContato, param => condicaoAddContato);
            this.DelMail = new RelayCommand(delMail, param => condicaoEliminar);
            this.VerMail = new RelayCommand(verMail, param => condicaoVer);
            this.SeePerfil = new ConditionCommand(param => condicaoApagar);
        }

        /// <summary>
        /// Responsavél pela instânciação do comando SeePerfil
        /// </summary>
        public ConditionCommand SeePerfil
        {
            get;
            internal set;
        }

        /// <summary>
        /// Responsavél por só permitir adicionar um contacto caso o  SelectedUtilizadorAdicionar não seja nulo
        /// </summary>
        internal bool condicaoAddContato {
            get { return (SelectedUtilizadorAdicionar != null); }
        }

        /// <summary>
        /// Responsavél por só permitir eliminar uma Mensagem caso o  SelectedMail não seja nulo e a Flag do mesmo não seja 3
        /// </summary> 
        internal bool condicaoEliminar
        {
            get { return (SelectedMail != null && SelectedMail.Flag != 3); }
        }

        /// <summary>
        /// Responsavél por só permitir visualizar uma Mensagem caso o  SelectedMail não seja nulo
        /// </summary>
        internal bool condicaoVer
        {
            get { return (SelectedMail != null); }
        }

        /// <summary>
        /// Responsavél por só permitir apagar uma Mensagem caso o  SelectedMail não seja nulo
        /// </summary>
        internal bool condicaoApagar
        {
            get { return (SelectedContacto != null); }
        }

        /// <summary>
        /// Responsavél pela instânciação do comando DelContato
        /// </summary>
        public RelayCommand DelContato {
            get;
            internal set;
        }

        /// <summary>
        /// Responsavél pela instânciação do comando AddContato
        /// </summary>
        public RelayCommand AddContato {
            get;
            internal set;
        }

        /// <summary>
        /// Responsavél pela instânciação do comando DelMail
        /// </summary>
        public RelayCommand DelMail
        {
            get;
            internal set;
        }

        /// <summary>
        /// Responsavél pela instânciação do comando VerMail
        /// </summary>
        public RelayCommand VerMail
        {
            get;
            internal set;
        }

        /// <summary>
        /// Obtenção da Lista de Mensagens Não Lidas do Utilizador loggado
        /// </summary>
        public List<Mensagem> MailBoxReceber
        {
            get
            {
                return serv.SearchMensagensNaoLidas(PesquisaMensagensNaoLidas, UserLogged.Email).ToList();
            }
        }

        /// <summary>
        /// Obtenção da String que indica o Número de Mensagens Não Lidas
        /// </summary>
        public string CountMensagemNaoLida
        {
            get
            {
                return "( " + serv.CountMailBoxReceber(UserLogged.Email).ToString() + " )";
            }

        }

        /// <summary>
        /// Obtenção da Lista de Mensagens Lidas do Utilizador loggado
        /// </summary>
        public List<Mensagem> MailBoxReceberLidas
        {
            get
            {
                return serv.SearchMensagensLidas(PesquisaMensagensLidas, UserLogged.Email).ToList();
            }
        }

        /// <summary>
        /// Obtenção da String que indica o Número de Mensagens Lidas
        /// </summary>
        public string CountMensagemLida
        {
            get
            {
                return "( " + serv.CountMailBoxLidas(UserLogged.Email).ToString() + " )";
            }

        }

        /// <summary>
        /// Metodo responsavél pela Visualização de um email e notificação das alterações que ocorram.
        /// </summary>
        public void verMail()
        {

            SelectedMail = serv.VerMail(SelectedMail.Id, UserLogged.Email);

            if (SelectedMail != null)
            {
                onPropertyChanged("MailBoxReceber");
                onPropertyChanged("MailBoxReceberLidas");
                onPropertyChanged("CountMensagemNaoLida");
                onPropertyChanged("CountMensagemLida");

            }

        }

        /// <summary>
        /// Obtenção da Lista de Mensagens Enviadas do Utilizador loggado
        /// </summary>
        public List<Mensagem> MailBoxEnviadas
        {
            get
            {
                return serv.SearchMensagensEnviadas(PesquisaMensagensEnviadas, UserLogged.Email).ToList();
            }
        }

         /// <summary>
        /// Obtenção da String que indica o Número de Mensagens Enviadas
        /// </summary>
        public string CountMensagemEnviada
        {
            get
            {
                return "( " + serv.CountMailBoxEnviadas(UserLogged.Email).ToString() + " )";
            }

        }

        /// <summary>
        /// Obtenção da Lista de Mensagens em Rascunhos do Utilizador loggado
        /// </summary>
        public List<Mensagem> MailBoxRascunhos
        {
            get
            {
                return serv.SearchMensagensRascunhos(PesquisaMensagensRascunhos, UserLogged.Email).ToList();
            }
        }

        /// <summary>
        /// Obtenção da String que indica o Número de Mensagens em Rascunhos
        /// </summary>
        public string CountMensagemRascunho
        {
            get
            {
                return "( " + serv.CountMailBoxRascunhos(UserLogged.Email).ToString() + " )";
            }

        }

        /// <summary>
        /// Obtenção da Lista de Mensagens Eliminadas do Utilizador loggado
        /// </summary>
        public List<Mensagem> MailBoxEliminados
        {
            get
            {
                return serv.SearchMensagensEliminados(PesquisaMensagensEliminados, UserLogged.Email).ToList();
            }
        }

        /// <summary>
        /// Obtenção da String que indica o Número de Mensagens Eliminadas
        /// </summary>
        public string CountMensagemEliminada
        {
            get
            {
                return "( " + serv.CountMailBoxEliminados(UserLogged.Email).ToString() + " )";
            }

        }

        /// <summary>
        /// Instânciação e obtenção da Mensagem actualmente selecionada
        /// </summary>
        public Mensagem SelectedMail
        {
            get
            {
                return selectedMail;
            }

            set
            {
                selectedMail = value;
                onPropertyChanged("SelectedMail");
            }
        }

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
                onPropertyChanged("UserLogged");
            }
        }


        /// <summary>
        /// Metodo Responsavél pelo envio de uma Mensagem
        /// </summary>
        /// <param name="titulo">Titulo da Mensagem</param>
        /// <param name="corpo">Corpo da Mensagem</param>
        /// <param name="destino">Destino e/ou Destinos da Mensagem</param>
        internal void addMail(string titulo, string corpo, string destino)
        {
            this.serv.AddMail(titulo, corpo, destino, UserLogged.Email);
            onPropertyChanged("MailBoxReceber");
            onPropertyChanged("MailBoxEnviadas");
            onPropertyChanged("CountMensagemNaoLida");
            onPropertyChanged("CountMensagemEnviada");
        }

        /// <summary>
        /// Metodo Responsavél por eliminar uma Mensagem Selecionada de um dado Utilizador loggado
        /// </summary>
        internal void delMail()
        {

            if (this.serv.DelMail(SelectedMail.Id, UserLogged.Email))
            {
                onPropertyChanged("MailBoxEnviadas");
                onPropertyChanged("MailBoxReceber");
                onPropertyChanged("MailBoxRascunhos");
                onPropertyChanged("MailBoxEliminados");
                onPropertyChanged("MailBoxReceberLidas");
                onPropertyChanged("CountMensagemNaoLida");
                onPropertyChanged("CountMensagemLida");
                onPropertyChanged("CountMensagemEnviada");
                onPropertyChanged("CountMensagemRascunho");
                onPropertyChanged("CountMensagemEliminada");
            }

        }

        /// <summary>
        /// Metodo responsavel por guardar uma Mensagem nos Rascunhos
        /// </summary>
        /// <param name="titulo">Titulo da Mensagem</param>
        /// <param name="corpo">Corpo da Mensagem</param>
        /// <param name="destino">Destino e/ou Destinos da Mensagem</param>
        internal void saveMail(string titulo, string corpo, string destino)
        {
            this.serv.SaveMail(titulo, corpo, destino, UserLogged.Email);

            onPropertyChanged("MailBoxRascunhos");
            onPropertyChanged("CountMensagemRascunho");
        }

        /// <summary>
        /// Instânciação e obtenção do Contacto actualmente selecionado
        /// </summary>
        public Utilizador SelectedContacto
        {
            get
            {
                return selectedContacto;
            }

            set
            {
                selectedContacto = value;
                onPropertyChanged("SelectedContacto");
            }
        }

        /// <summary>
        /// Metodo responsavel por eliminar um Contacto Selecionado da lista de Contactos
        /// </summary>
        internal void delContato()
        {
            if (this.serv.DelContato(UserLogged.Username,SelectedContacto.Username))
            {
                onPropertyChanged("ContactosAdicionados");
            }
        }

        /// <summary>
        /// Metodo responsavel por adicionar um Utilizador Selecionado á lista de Contactos
        /// </summary>
        internal void addContato()
        {
            this.serv.AddContato(UserLogged.Username, SelectedUtilizadorAdicionar.Username);
            onPropertyChanged("ContactosAdicionados");

        }

        /// <summary>
        /// Responsavél pela obtenção da Lista dos meus contatos
        /// </summary>
        public List<Utilizador> ContactosAdicionados
        {
            get
            {
                return serv.SearchMeusContatos(PesquisaContactos,UserLogged.Username).ToList();
            }
        }

        /// <summary>
        /// Responsavél pela obtenção da Lista dos meus contatos para aparecer na autoCompleteBox das novas mensagens
        /// </summary>
        public List<Utilizador> GetUserContactos
        {
            get
            {
                return serv.SearchMeusContatos("", UserLogged.Username).ToList();
            }
        }

        /// <summary>
        /// Responsavél pel obtenção da Lista de todos os Utilizadores actualmente guardados na base de dados
        /// </summary>
        public List<Utilizador> ListUtilizadores
        {
            get
            {
                return this.serv.GetUtilizadores(UserLogged.Username).ToList();
            }
        }


        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Contactos para adicionados
        /// </summary>
        public string PesquisaContactos
        {
            get
            {
                return pesquisaContactos;
            }

            set
            {
                pesquisaContactos = value;
                onPropertyChanged("ContactosAdicionados");
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Mensagens Não Lidas
        /// </summary>
        public string PesquisaMensagensNaoLidas
        {
            get
            {
                return pesquisaMensagensNaoLidas;
            }

            set
            {
                pesquisaMensagensNaoLidas = value;
                onPropertyChanged("MailBoxReceber");
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Mensagens Lidas
        /// </summary>
        public string PesquisaMensagensLidas
        {
            get
            {
                return pesquisaMensagensLidas;
            }

            set
            {
                pesquisaMensagensLidas = value;
                onPropertyChanged("MailBoxReceberLidas");
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Mensagens Enviadas
        /// </summary>
        public string PesquisaMensagensEnviadas
        {
            get
            {
                return pesquisaMensagensEnviadas;
            }

            set
            {
                pesquisaMensagensEnviadas = value;
                onPropertyChanged("MailBoxEnviadas");
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Mensagens em Rascunhos
        /// </summary>
        public string PesquisaMensagensRascunhos
        {
            get
            {
                return pesquisaMensagensRascunhos;
            }

            set
            {
                pesquisaMensagensRascunhos = value;
                onPropertyChanged("MailBoxRascunhos");
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Pesquisa de Mensagens Eliminadas
        /// </summary>
        public string PesquisaMensagensEliminados
        {
            get
            {
                return pesquisaMensagensEliminados;
            }

            set
            {
                pesquisaMensagensEliminados = value;
                onPropertyChanged("MailBoxEliminados");
            }
        }        

        /// <summary>
        /// Instânciação e obtenção do Utilizador Selecionado
        /// </summary>
        public Utilizador SelectedUtilizadorAdicionar
        {
            get
            {
                return selectedUtilizadorAdicionar;
            }

            set
            {
                selectedUtilizadorAdicionar = value;
            }
        }

        /// <summary>
        /// Metodo responsavel pela filtragem de dados para a AutoCompleteBox
        /// </summary>
        public AutoCompleteFilterPredicate<Object> UtilizadorFilter
        {
            get
            {
                return (searchText, obj) =>
                    (obj as Utilizador).Email.Contains(searchText)
                    || (obj as Utilizador).Nome.Contains(searchText);
            }
        }

        /// <summary>
        /// Metodo responsavél por possibilitar a edição dos dados do Utilizador loggado
        /// </summary>
        internal void editarUtilizador(string password)
        {
            Utilizador tmpUser = this.serv.EditarUtilizador(UserLogged.Username, password, UserLogged.Nome, UserLogged.Morada, UserLogged.Telemovel);

            UserLogged = tmpUser;
            onPropertyChanged("UserLogged");
        }

        /// <summary>
        /// Metodo responsavél por possibilitar a eliminação do Utilizador loggado
        /// </summary>
        internal bool delUtilizador()
        {
            if (this.serv.DelUtilizador(UserLogged.Username))
            {
                return true;
            }
            return false;
        }
    }
}
