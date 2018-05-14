using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Project
{
    class Car
    {
        // fields
        private string _id;
        private DateTime _createDateTime;
        private DateTime _addToParkingDateTime;
        private DateTime _removeFromParkingDateTime;
        private DateTime _timeOfLastBalance;

        // ctors
        public Car(CarType carType, string id)
        {
            _createDateTime = DateTime.Now;
            CarType = carType;
            Id = id;
        }

        public Car(CarType carType, string id, double balance)
            : this(carType, id)
        {
            Balance = balance;
        }

        // Properties
        public string Id
        {
            get { return _id; }
            private set
            {
                if (_id == null)
                    _id = value;
            }
        }

        public CarType CarType { get; private set; }

        public double Balance { get; private set; }
        public DateTime AddToParkingDateTime
        {
            get { return _addToParkingDateTime; }
            set
            {
                _addToParkingDateTime = value;
            }
        }

        public DateTime RemoveFromParkingDateTime
        {
            get { return _removeFromParkingDateTime; }
            set
            {
                _removeFromParkingDateTime = value;
            }
        }

        public DateTime TimeOfLastBalance
        {
            get { return _timeOfLastBalance; }
            set
            {
                _timeOfLastBalance = value;
            }
        }



        // Methods
        public void ReprenishBalance(double reprenishment, bool IsAdding)
        {
            if (reprenishment < 0)
                return;

            if (IsAdding == true)
                Balance += reprenishment;
            else
                Balance -= reprenishment;
        }
        public override string ToString()
        {
            return String.Format($"Type: {CarType.ToString()}\tId: {Id}\tBalance:{Balance}");
        }
    }
}
