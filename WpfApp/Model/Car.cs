using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Data;

namespace WpfApp.Model
{
   public class Car: Detail
    {
        /// <summary>
        /// Рама автомобиля
        /// </summary>
        public Body CarBody;

        /// <summary>
        /// Колёса автомобиля
        /// </summary>
        public ObservableCollection<Wheel> Wheels { get; set; }

        /// <summary>
        /// Двери автомобиля
        /// </summary>
        public ObservableCollection<Door> Doors { get; set; }



        public int WheelCount => Wheels.Count;

        public int DoorCount => Doors.Count;

        public double Weight { get { return Wheels.SelectMany(x => x.Nuts).Sum(x => x.Weight) + Wheels.Sum(x=>x.Weight) + Doors.Sum(x => x.Weight) + Body.Instance.Weight; } }
        /// <summary>
        /// Создаём автомобиль
        /// </summary>
        /// <param name="wCount">Кол-во колёс</param>
        /// <param name="DCount">Кол-во дверей</param>
        public Car(int wCount, int DCount)
        {
            NativeName = "Автомобиль";
            Wheels = new ObservableCollection<Wheel>();
            Doors = new ObservableCollection<Door>();

            for(var i = 0; i < wCount; i++)
            {
                var wheel = new Wheel{ DetailNumber = i + 1 };
                Wheels.Add(wheel);
            }
            for (var j = 0; j < DCount; j++)
            {
                var door = new Door { DetailNumber = j + 1 };
                Doors.Add(door);
            }
        }

        /// <summary>
        /// Композитная коллекция для TreeView
        /// </summary>
        public IList Children => new CompositeCollection()
        {
            new CollectionContainer {  Collection = new Collection<Body> { Body.Instance} },
            new CollectionContainer { Collection = Doors },
            new CollectionContainer { Collection = Wheels }
        };
    }
}
