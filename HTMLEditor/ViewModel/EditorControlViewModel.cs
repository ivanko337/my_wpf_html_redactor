using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HTMLEditor.Core;

namespace HTMLEditor.ViewModel
{
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
