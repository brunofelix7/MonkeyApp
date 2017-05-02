using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MonkeyApp.ViewModel {

    public class BaseViewModel : INotifyPropertyChanged {

        //  Método da interrface que vai notificar algum evento que ocorreu na View
        public event PropertyChangedEventHandler PropertyChanged;

        //  CallerMemberName - Não preciso passar o nome da propiedade, quando eu chamo esse método
        //  dentro de um set de alguma propriedade, a string automaticamente vem com o nome dessa propriedade.
        //  O null é somente porque esse método precisa de um valor default
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //  Faz tudo em um método só. Caso o valor seja igual, eu não preciso atualizar minha View
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null) {
            if(EqualityComparer<T>.Default.Equals(storage, value)) {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

    }
}
