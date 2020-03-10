using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyHTMLEditor.ViewModel
{
    public class Command : ICommand
    {
        private Action<object> action;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public Command(Action<object> action, Func<object, bool> canExecute = null)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute != null ? canExecute(parameter) : true;
        }

        public void Execute(object parameter)
        {
            if (action != null)
            {
                action.Invoke(parameter);
            }
        }
    }

    public class EditorControlViewModel : BaseViewModel
    {
        private Action<object> textLayoutAction;
        public Action<object> TextLayoutAction
        {
            set
            {
                textLayoutAction = value;
            }
        }


        public ICommand TextLayoutRedactCommand
        {
            get
            {
                return new Command(textLayoutAction);
            }
        }
    }
}
