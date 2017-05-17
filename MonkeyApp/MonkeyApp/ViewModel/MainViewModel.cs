using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Diagnostics;

namespace MonkeyApp.ViewModel {

    public class MainViewModel : BaseViewModel{

        private string _descricao;
        private string _searchTerm;
        
        //  Classe qua implementa um ICommand, usa no construtor
        //  Vai ser sempre ReadOnly, você nunca vai alterar a instância dessa variável
        public Command SearchCommand { get; }

        public string SearchTerm {
            get { return _searchTerm; }
            set { SetProperty(ref _searchTerm, value); }
        }


        public string Descricao {
            get { return _descricao; }
            set {
                //  Toda vez que eu fizer um set na minha propriedade, eu chamo o meu método de modificação
                //  _descricao = value;
                //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Descricao)));
                //  OnPropertyChanged();
                SetProperty(ref _descricao, value);
            }
        }

        //  propfull - Faz com o private
        //  prop     - Faz com o public
        //  ctor     - Criar construtor vazio

        public MainViewModel() {
            Descricao = "Olá mundo! Estou aqui.";

            Task.Delay(3000).ContinueWith(async t => {
                Descricao = "Texto mudou";

                for(int i = 1; i <= 10; i++) {
                    await Task.Delay(1000);
                    Descricao = $"Texto mudou {i}";
                }
                //  Vai notificar e atualizar o texto na tela para o usuário
                //  A ? (ElvisOperator) substitui o if(PropertyChanged != null){}
                //  O nameOf evita que eu coloque entre parênteses o nome da variável e venha a errar esse nome
                //  PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Descricao)));
            });

            //  O segundo construtor é opcional, retorna um bool, se for true o botão pode executar a ação, se for false o botão é desabilitado
            SearchCommand = new Command(ExecuteSearchCommand, CanExecuteSearchCommand);

        }

        //  Executa qualquer coisa que eu quiser ao clicar o botão
        void ExecuteSearchCommand() {
            Debug.WriteLine($"Fui clicado em {DateTime.Now}");
        }

        //  Você pode acrescentar alguma lógica para ativar ou não o clique do botão
        bool CanExecuteSearchCommand() {
            return true;
        }

    }

}
