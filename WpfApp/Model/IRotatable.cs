using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
    public interface IRotatable
    {
        void Move();

        bool IsMoving { get; set; }

        string MovingState { get; set; }

        RelayCommand RotateCommand { get; set; }
    }
}
