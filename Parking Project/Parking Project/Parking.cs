using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Project
{
    class Parking
    {
        private static readonly Lazy<Parking> instance = new Lazy<Parking>(() => new Parking());
        private int _parkingSpace;
        private double _sumOfTransactions = 0;
        private List<Transaction> _transactions;
        private DateTime _dateOfLog;
        private List<Car> _cars;

        public Parking()
        {
            _parkingSpace = Settings.ParkingSpace;
            _transactions = new List<Transaction>();
            _dateOfLog = DateTime.Now;
            _cars = new List<Car>();
        }

        public double Balance { get; private set; }

        public static Parking Instance { get { return instance.Value; } }


        //Списать средства за парковочное место (через каждые N-секунд будет срабатывать таймер и списывать с каждой машины стоимость парковки).
        public void PayForParking()
        {
            double payment;
            foreach (Car car in _cars)
            {
                double secondsOnParking = (DateTime.Now - car.TimeOfLastBalance).TotalSeconds;

                if (secondsOnParking >= 3)
                {
                    secondsOnParking /= 3;
                    payment = Settings.Timeout(car.Balance > 0, car.CarType.ToString()) * secondsOnParking;
                    car.ReprenishBalance(payment, false);

                    Balance += payment;
                    _transactions.Add(new Transaction(car.Id, payment));
                    car.TimeOfLastBalance = DateTime.Now;
                }
                //payment = Settings.Timeout(car.Balance > 0, car.CarType.ToString());

                //_sumOfTransactions += payment;

                //car.ReprenishBalance(payment, false);

                //ListOfTransaction(payment, car.CarType);
            }
        }

        //Список транзакций
        //public void ListOfTransaction(double payment, CarType carType)
        //{
        //    //Transaction s = new Transaction("ere");
        //    //_transactions.Add(s);
        //}

        public void AddCar(Car car)
        {
            if (_parkingSpace > 0)
            {
                car.AddToParkingDateTime = car.TimeOfLastBalance = DateTime.Now;
                _parkingSpace--;
                _cars.Add(car);
            }
        }

        public void RemoveCar(Car car)
        {
            if (_cars.Count != 0 && _cars.Contains(car))
            {
                car.RemoveFromParkingDateTime = DateTime.Now;
                _parkingSpace++;
                _cars.Remove(car);
            }
        }

        public string ShowBalance()
        {
            return String.Format("The balance of parking: {0}", Balance);
        }

        public string CountOfFreePlaces()
        {
            if (_parkingSpace > 1)
                return String.Format("There are {0} free places in this parking!", _parkingSpace);
            else if (_parkingSpace == 0)
                return String.Format("There isn't any free place in parking");
            else
                return String.Format("There is {0} free place in this parking!", _parkingSpace);
        }

        // Create async run.
        //Каждую минуту записывать в файл Transactions.log сумму транзакций за последнюю минуту с пометкой даты.
        public void WriteLog()
        {
            if ((DateTime.Now - _dateOfLog).TotalSeconds >= 3) // totalminute == 1
                foreach (var item in _transactions)
                {
                    if ((DateTime.Now - _dateOfLog).TotalSeconds >= 10) // change to 1 minute
                    {
                        _sumOfTransactions += item.SpentFunds;
                    }
                }
            using (StreamWriter write = File.AppendText("Transactions.log"))
            {
                write.Write("Log Entry : ");
                write.WriteLine("\r\nDate: {0}", DateTime.Now.ToString());
                write.WriteLine("Sum of transactions: {0}", _sumOfTransactions);
                write.WriteLine("----------------------------\r\n");

                // reset data
                _sumOfTransactions = 0;
                _dateOfLog = DateTime.Now;
            }
        }

        //Вывести Transactions.log (отформатировать вывод)
        public string ShowLog()
        {
            using (StreamReader reader = File.OpenText("Transactions.log"))
            {
                StringBuilder log = new StringBuilder();
                while ((reader.ReadLine()) != null)
                {
                    log.Append(reader.ReadLine() + "\r\n");
                }
                return String.Format(log.ToString());
            }
        }

        //Вывести истории транзакций за последнюю минуту.
        public string ShowTransactionsPerLastMinute()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (Transaction item in _transactions)
            {
                if ((DateTime.Now - item.DateTimeOfTransaction).TotalMinutes <= 1)
                    stringBuilder.Append(item.ToString() + "\r\n");
            }
            return String.Format(stringBuilder.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Car item in _cars)
            {
                sb.Append(item + "\r\n");
            }
            return String.Format(sb.ToString());
        }
    }
}
