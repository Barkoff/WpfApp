using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WpfApp.Model;
using WpfApp.View;

namespace WpfApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Car> CarList { get; set; }

        public RelayCommand CreateCarCommand { get; set; }
        public RelayCommand<object> SetSelectedItemCommand { get; set; }
        public RelayCommand<object> RemoveOrInsertCommand { get; set; }

        private string selectedName;
        public string SelectedName { get { return selectedName; } set { selectedName = value; RaisePropertyChanged(() => SelectedName); } }

        public MainViewModel()
        {
            CarList = new ObservableCollection<Car>();
            CreateCarCommand = new RelayCommand(CreateCar);
            SetSelectedItemCommand = new RelayCommand<object>(SetSelectedItem);
            RemoveOrInsertCommand = new RelayCommand<object>(RemoveOrInsertItem);
        }

        /// <summary>
        /// —оздание или удаление элемента, в зависимости от параметра команды
        /// </summary>
        /// <param name="o"></param>
        private void RemoveOrInsertItem(object o)
        {
            var isInsert = o.ToString() == "Insert";

            if (SelectedItem is Door)
            {
                var door = (Door)SelectedItem;
                var tempCar = CarList.FirstOrDefault(x => x.Doors.IndexOf(door) > -1);
                if (isInsert)
                    tempCar?.Doors.Insert(tempCar.Doors.IndexOf(door), new Door { DetailNumber = tempCar.Doors.Max(x => x.DetailNumber) + 1 });
                else
                    tempCar?.Doors.Remove(door);
                return;
            }

            if (SelectedItem is Wheel)
            {
                var wheel = (Wheel)SelectedItem;
                var tempCar = CarList.FirstOrDefault(x => x.Wheels.IndexOf(wheel) > -1);
                if (isInsert)
                    tempCar?.Wheels.Insert(tempCar.Wheels.IndexOf(wheel), new Wheel { DetailNumber = tempCar.Wheels.Max(x => x.DetailNumber) + 1 });
                else
                    tempCar?.Wheels.Remove(wheel);
                return;
            }

            if (SelectedItem is Nut)
            {
                var nut = (Nut)SelectedItem;
                var tempWheel = CarList.FirstOrDefault(x => x.Wheels.Select(y => y.Nuts.IndexOf(nut) > -1).FirstOrDefault())?.Wheels.FirstOrDefault(y => y.Nuts.IndexOf(nut) > -1);
                if (isInsert)
                    tempWheel?.Nuts.Insert(tempWheel.Nuts.IndexOf(nut), new Nut { DetailNumber = tempWheel.Nuts.Max(x => x.DetailNumber) + 1 });
                else
                    tempWheel?.Nuts.Remove(nut);
            }
        }


        private void CreateCar()
        {
            var cd = new CarDialog();
            var result = cd.ShowDialog();
            if (result != true) return;
            int dCount;
            int wCount;
            if (int.TryParse(cd.DoorCountTextBox.Text, out dCount) &&
                int.TryParse(cd.WheelCountTextBox.Text, out wCount))
            {
                var car = new Car(wCount, dCount)
                {
                    DetailNumber = CarList.Count + 1
                };
                CarList.Add(car);
            }
            else
                MessageBox.Show("¬ведены неверные параметры автомобил€!");
            
        }



        private void SetSelectedItem(object o)
        {
            SelectedItem = o as IDetail;
            if (SelectedItem != null)
                SelectedName = SelectedItem.Name;
        }

        public IList Children => new CompositeCollection()
        {
            new CollectionContainer { Collection = CarList },
            new CollectionContainer { Collection = from v in  CarList select v.Children }

        };

        private IDetail selectedItem;
        public IDetail SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(() => SelectedItem); }
        }

    }
}

//  CarList.FirstOrDefault(x => x.Wheels.FirstOrDefault(y=>y.Nuts.IndexOf(nut) > -1).Nuts.Remove(nut));