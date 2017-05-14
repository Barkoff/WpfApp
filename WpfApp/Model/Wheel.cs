using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace WpfApp.Model
{
    /// <summary>
    /// Колесо
    /// </summary>
    public class Wheel : RotatableDetail
    {
        /// <summary>
        /// Гайки колеса
        /// </summary>
        public ObservableCollection<Nut> Nuts { get; set; }

        public int NutsCount { get; set; } = 6;


        public Wheel()
        {
            NativeName = "Колесо";
            Weight = 70;
            Nuts = new ObservableCollection<Nut>();
            for (var i = 0; i < NutsCount; i++)
            {
                var nut = new Nut { DetailNumber = i + 1 };
                Nuts.Add(nut);
            }
            RotateCommand = new RelayCommand(Move);
            IsMoving = false;
        }

        private bool isMoving;
        public override bool IsMoving { get { return isMoving; }
            set { isMoving = value; RaisePropertyChanged(()=>IsMoving);
                MovingState = IsMoving ? "вращается" : "не вращается";
            }}

    }
}
