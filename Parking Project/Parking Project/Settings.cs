using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Project
{
    public static class Settings
    {
        public static readonly int ParkingSpace;
        private static double _fine;

        private static readonly Dictionary<string, int> _price = new Dictionary<string, int>
        {
            {CarType.Truck.ToString(), 5 },
            {CarType.Passenger.ToString(), 3 },
            {CarType.Bus.ToString(), 2 },
            {CarType.Motorcycle.ToString(), 1 }
        };

        public static double Fine
        {
            get { return _fine; }
            set
            {
                if (value <= 0)
                    _fine = 0;
                else
                    _fine = value;
            }
        }

        static Settings()
        {
            ParkingSpace = 20;
        }

        //Свойство Timeout(каждые N-секунд списывает средства за парковочное место) - по умолчанию 3 секунды
        public static double Timeout(bool hasMoney, string carType)
        {
            int result;
            double sum = 0;

            _price.TryGetValue(carType, out result);

            if (hasMoney)
                sum = result;
            else
                sum = result + result * 100 / Fine;

            return sum;
        }
    }
}
