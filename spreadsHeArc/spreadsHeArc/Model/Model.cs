using System.ComponentModel;

namespace spreadsHeArc.Model
{
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));                
            }
        }
    }
}
