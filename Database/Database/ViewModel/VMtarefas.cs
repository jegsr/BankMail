using Database.Model;
using Database.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Database.ViewModel
{
    /// <summary>
    /// Classe representa o Modelo da View Tarefas
    /// </summary>
    class VMtarefas : BaseModel
    {
        private HttpClient client = new HttpClient();
        private string username;
        private Tarefa selectedTarefa;
        private const string caminho = "api/Tarefas";
        private const string url = "http://localhost:55856/";
        private const string aceptsTypes = "application/json";
        private const int timeOutSecond = 3;

        private string pesquisa;

        public VMtarefas(string username)
        {
            this.username = username;
            SelectedTarefa = null;
            Pesquisa = "";
            client.BaseAddress = new Uri(url);
            client.Timeout = TimeSpan.FromSeconds(timeOutSecond);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(aceptsTypes));
            this.initCommand();
        }

        /// <summary>
        /// Metodo para inicialização dos comandos
        /// </summary>
        private void initCommand()
        {
            this.DelTarefa = new RelayCommand(DeleteTarefa, param => condicaoEliminar);
            this.SeeTarefa = new ConditionCommand(param => condicaoEliminar);
        }

        /// <summary>
        /// Responsavél por só permitir eliminar uma Tarefa caso o Utilizador tenha Selecionado uma Tarefa para Eliminar
        /// </summary>
        internal bool condicaoEliminar
        {
            get { return (SelectedTarefa != null); }
        }

        /// <summary>
        /// Responsavél pela instânciação do comando DelTarefa
        /// </summary>
        public RelayCommand DelTarefa
        {
            get;
            internal set;
        }

        /// <summary>
        /// Responsavél pela instânciação do comando VerTarefa
        /// </summary>
        public ConditionCommand SeeTarefa
        {
            get;
            internal set;
        }

        /// <summary>
        /// Metodo Responsavél pela obtenção das Tarefas do Utilizador
        /// </summary>
        /// <returns>IEnumerable tarefas</returns>
        private async Task<IEnumerable<Tarefa>> GetTarefasAsync(String pesquisa)
        {
            IEnumerable<Tarefa> tarefas = null;
            HttpResponseMessage response = await client.GetAsync(caminho + "?pesquisa=" + pesquisa + "&user=" + username);
            if (response.IsSuccessStatusCode)
            {
                tarefas = await response.Content.ReadAsAsync<IEnumerable<Tarefa>>();
            }
            return tarefas;
        }

        /// <summary>
        /// Metodo Responsavél por adicionar uma nova Tarefa
        /// </summary>
        /// <param name="nome">Nome da Tarefa</param>
        /// <param name="corpo">Corpo da Tarefa</param>
        /// <param name="date">Data da Tarefa</param>
        /// <returns>Bool que representa o sucesso ou inssucesso da operação</returns>
        internal async Task<bool> AddTarefa(string nome, string corpo, DateTime date)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Nome = nome;
            tarefa.Data = date;
            tarefa.Corpo = corpo;
            tarefa.User = username;
            HttpResponseMessage response = await client.PostAsJsonAsync(caminho, tarefa);
            onPropertyChanged("ListTarefas");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo responsavél pela edição de uma Tarefa
        /// </summary>
        /// <returns>Bool que representa o sucesso ou inssucesso da operação</returns>
        internal async Task<bool> EditTarefa()
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(caminho + "/" + SelectedTarefa.Id, SelectedTarefa);
            onPropertyChanged("ListTarefas");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Metodo responsavél pela eliminação de uma Tarefa
        /// </summary>
        internal async void DeleteTarefa()
        {

            HttpResponseMessage response = await client.DeleteAsync(caminho + "/" + SelectedTarefa.Id);
            onPropertyChanged("ListTarefas");
        }

        /// <summary>
        /// Metodo responsavél pela eliminação de todas as Tarefas de um Utilizador
        /// </summary>
        /// <returns>Bool que representa o sucesso ou inssucesso da operação</returns>
        internal async Task<bool> DeleteTarefas()
        {

            HttpResponseMessage response = await client.DeleteAsync(caminho + "?user=" + this.username);
            onPropertyChanged("ListTarefas");
            return response.IsSuccessStatusCode;
        }

        /// <summary>
        /// Obtenção das tarefas de um Utilizador
        /// </summary>
        public List<Tarefa> ListTarefas
        {
            get
            {
                return GetTarefasAsync(Pesquisa).Result.ToList();
            }
        }

        /// <summary>
        /// Instânciação e obtenção da Tarefa actualmente selecionada
        /// </summary>
        public Tarefa SelectedTarefa
        {
            get
            {
                return this.selectedTarefa;
            }
            set
            {
                this.selectedTarefa = value;
                onPropertyChanged("SelectedTarefa");
            }
        }
        /// <summary>
        /// Instânciação e obtenção da pesquisa actualmente realizada
        /// </summary>
        public string Pesquisa
        {
            get
            {
                return pesquisa;
            }

            set
            {
                pesquisa = value;
                onPropertyChanged("ListTarefas");
            }
        }
    }
}
