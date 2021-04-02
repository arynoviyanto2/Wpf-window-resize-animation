using System.ComponentModel;

namespace Wpf_window_resize_animation.Utility
{
    public class BaseService<T> : INotifyPropertyChanged where T : new()
    {
        protected BaseService() { }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static T _instance;
        public static T Instance 
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

        public virtual void Initialise()
        {
        }

        public virtual void Terminate()
        {
        }
    }
}
