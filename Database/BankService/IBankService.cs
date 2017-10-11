using BankService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BankService
{
   
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        bool AddRegisto(string nome, string username, string password, string morada, string telemovel);

        [OperationContract]
        Utilizador CheckLogin(string username, string password);

        [OperationContract]
        Utilizador EditarUtilizador(string username, string password, string nome, string morada, string telemovel);

        [OperationContract]
        int CountMailBoxReceber(string email);

        [OperationContract]
        int CountMailBoxLidas(string email);

        [OperationContract]
        int CountMailBoxEnviadas(string email);

        [OperationContract]
        int CountMailBoxRascunhos(string email);

        [OperationContract]
        int CountMailBoxEliminados(string email);

        [OperationContract]
        void AddMail(string titulo, string corpo, string destino, string emailOrigem);

        [OperationContract]
        bool DelMail(int mailId, string emailOrigem);

        [OperationContract]
        Mensagem VerMail(int mailId, string emailOrigem);

        [OperationContract]
        void SaveMail(string titulo, string corpo, string destino, string emailOrigem);

        [OperationContract]
        bool DelContato(string UsernameOrigem, string UsernameDestino);

        [OperationContract]
        bool AddContato(string usernameOrigem, string usernameDestino);

        [OperationContract]
        List<Utilizador> GetUtilizadores(string loggedUser);

        [OperationContract]
        List<Utilizador> SearchMeusContatos(string pesquisa, string loggedUser);

        [OperationContract]
        List<Mensagem> SearchMensagensNaoLidas(string pesquisa, string email);

        [OperationContract]
        List<Mensagem> SearchMensagensLidas(string pesquisa, string email);

        [OperationContract]
        List<Mensagem> SearchMensagensEnviadas(string pesquisa, string email);

        [OperationContract]
        List<Mensagem> SearchMensagensRascunhos(string pesquisa, string email);

        [OperationContract]
        List<Mensagem> SearchMensagensEliminados(string pesquisa, string email);

        [OperationContract]
        bool DelUtilizador(string loggedUser);

        [OperationContract]
        List<String> GetEmailContactos(String loggedUser);
    }
}
