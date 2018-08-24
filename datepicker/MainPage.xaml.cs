using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace datepicker
{
    public partial class MainPage : ContentPage
    {
        MainViewModel _vm = new MainViewModel();
        public MainPage()
        {
            InitializeComponent();
           BindingContext = _vm;
            _vm.Dt = DateTime.Now.AddDays(-1);
        }
    }

    public class MainViewModel: INotifyPropertyChanged
    {
        DateTime? dateTime;
        public DateTime? Dt
        {
            set
            {
                if (dateTime != value)
                {
                    dateTime = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Dt"));
                    }
                }
            }
            get
            {
                return dateTime;
            }
        }

        private Command _nullCommand;
        public Command NullCommand
        {
            get
            {
                _nullCommand = _nullCommand ?? new Command(DoNull);
                return _nullCommand;
            }
        }
        public void DoNull(){
            Dt = null;
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
