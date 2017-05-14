using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
    /// <summary>
    /// Кузов
    /// </summary>
    public sealed class Body : RotatableDetail, IDoor
    {
        public RelayCommand OpenCommand { get; set; }

        static Body instance = null;

        private Body()
        {
            OpenCommand = new RelayCommand(Open);
            RotateCommand = new RelayCommand(Move);
            IsMoving = false;
        }

        public static Body Instance => instance ?? (instance = new Body { NativeName = "Рама", Weight = 900, DetailNumber = 0 });
        public bool IsOpened { get; set; } = false;

        public string DoorState { get; set; }

        public void Open()
        {
            MessageBox.Show("Увы, это не дверь!!!");
        }
    }
}
