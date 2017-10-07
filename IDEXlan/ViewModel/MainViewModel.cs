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

        public ICommand tokensBtnCommand;

        public MainViewModel()
        {
            Code = "Testing";
            tokensBtnCommand = new CommandBase((p) => Code = "Click je");
        }

    }
}
