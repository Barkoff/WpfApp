using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
    /// <summary>
    /// Дверь
    /// </summary>
   public class Door : Detail, IDoor
    {
        public RelayCommand OpenCommand { get; set; }

        public Door()
        {
            NativeName = "Дверь";
            Weight = 40;
            OpenCommand = new RelayCommand(Open);
            IsOpened = false;
        }

        private string doorState;
        public string DoorState {
            get { return doorState; }
            set { doorState = value; RaisePropertyChanged(()=>DoorState); }
        }
        private bool _isOpened;


        public bool IsOpened
        {
            get { return _isOpened; }

            set { _isOpened = value; RaisePropertyChanged(()=>IsOpened);
                DoorState = IsOpened ?  "открыта" : "закрыта";
            }
        }

        public void Open()
        {
            IsOpened = !IsOpened;
            MessageBox.Show(string.Join(" ", Name, DoorState));
        }
    }
}