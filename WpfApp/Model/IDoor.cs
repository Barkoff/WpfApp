using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
    public interface IDoor
    {
        string DoorState { get; set; }
        bool IsOpened { get; set; }
        void Open();
        RelayCommand OpenCommand { get; set; }
    }
}
