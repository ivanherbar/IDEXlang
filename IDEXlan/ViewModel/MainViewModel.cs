using IDEXlan.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IDEXlan.ViewModel
{
    public class MainViewModel: NotifyBase
    {
        private string code;

        public string Code
        {
            get { return code; }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }

        public ICommand TokensBtnCommand { get; set; }

        public MainViewModel()
        {
            Code = "Testing";
            TokensBtnCommand = new CommandBase((p) => Code = "Click je");
        }

    }
}
