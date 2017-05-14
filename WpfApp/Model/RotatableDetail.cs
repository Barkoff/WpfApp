using System.Windows;
using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
   public class RotatableDetail : Detail,  IRotatable
    {
        public void Move()
        {
            IsMoving = !IsMoving;
            MessageBox.Show(string.Join(" ", Name, MovingState));
        }


        private bool isMoving;
        public virtual bool IsMoving
        {
            get { return isMoving; }
            set
            {
                isMoving = value; RaisePropertyChanged(() => IsMoving);
                MovingState = IsMoving ? "едет" : "не едет";
            }
        }

        private string movingState;
        public string MovingState
        {
            get { return movingState; }
            set { movingState = value; RaisePropertyChanged(() => MovingState); }
        }
        public RelayCommand RotateCommand { get; set; }
    }
}
