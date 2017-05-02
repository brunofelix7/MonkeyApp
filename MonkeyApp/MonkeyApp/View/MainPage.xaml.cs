using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MonkeyApp.ViewModel;

namespace MonkeyApp {
    public partial class MainPage : ContentPage {
        public MainPage() {
            InitializeComponent();
            //  Diz que essa página .xaml está associada a está ViewModel
            //  Detecta se essa classe implementa a interface INotifyPropertyChanged
            BindingContext = new MainViewModel();
        }
    }
}
