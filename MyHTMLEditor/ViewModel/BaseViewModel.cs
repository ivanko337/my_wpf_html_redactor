using System.ComponentModel;

namespace MyHTMLEditor.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected BaseViewModel()
        { }

        public virtual void OnProperyChanged(string propName)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
