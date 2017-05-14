using GalaSoft.MvvmLight;

namespace WpfApp.Model
{
    /// <summary>
    /// Деталь. Базовый класс
    /// </summary>
   public abstract class Detail: ViewModelBase, IDetail
    {
        public double Weight { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }
        private int detailNumber;
        public int DetailNumber { get { return detailNumber; } set { detailNumber = value; Name = string.Join(" ", NativeName, "№", value); } }

        private string state;
        public virtual string State {get { return state; } set { state = value; RaisePropertyChanged(()=>State); } }

        public enum StateEnum
        {
            
        }

        private object _selectedItem = null;
        public object SelectedItem
        {
            get { return _selectedItem; }
            private set
            {
                if (_selectedItem != value)
                {
                    _selectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                }
            }
        }

        private bool _isSelected;
        public bool Selected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    RaisePropertyChanged(() => Selected);
                    if (_isSelected)
                    {
                        SelectedItem = this;
                    }
                }
            }
        }


    }
}
