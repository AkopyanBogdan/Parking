using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Parking parking = new Parking();

            Console.WriteLine("Hello to you in our parking");

            Menu.Show();


            int choice = int.Parse(Console.ReadLine());

            while (choice > 0 && choice < 8)
            {
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("We add new car");
                            Console.WriteLine("Make your choice about car type and then press enter");
                            Console.WriteLine("0-Passenger,1- Truck,2- Bus,3- Motorcycle");
                            int typeCar = 0;

                            try
                            {
                                typeCar = int.Parse(Console.ReadLine());
                            }

                            catch (ArgumentOutOfRangeException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (OutOfMemoryException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }

                            catch (ArgumentNullException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (OverflowException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }

                            Console.WriteLine("Create a balance for your car in $");
                            double bal = 0;
                            try
                            {
                                bal = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (OverflowException ex)
                            {

                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            Console.WriteLine("Format  of id is   XX12345");
                            string idCar = Console.ReadLine();
                            Car car = new Car();
                            if (idCar.Length == 6 &&
                                (char)idCar[0] >= 65 && (char)idCar[0] < 90 &&
                                (char)idCar[1] >= 65 && (char)idCar[1] < 90 &&
                                 (char)idCar[2] < 57 && (char)idCar[2] >= 48 &&
                                 (char)idCar[3] < 57 && (char)idCar[3] >= 48 &&
                                 (char)idCar[4] < 57 && (char)idCar[4] >= 48 &&
                                 (char)idCar[5] < 57 && (char)idCar[5] >= 48
                                 )
                            { car = new Car((CarType)typeCar, idCar, bal); }
                            else
                            {
                                Console.WriteLine("Unnormal format IdCar");
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            parking.AddCar(car);

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 2:
                        {
                            Console.WriteLine("We want delete car");
                            Console.WriteLine("This is the list of our parking");
                            Console.WriteLine(parking);
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            string idCar;
                            try
                            {
                                idCar = Console.ReadLine();
                            }
                            catch (OutOfMemoryException ex)
                            {
                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }
                            catch (ArgumentOutOfRangeException ex)
                            {

                                Console.WriteLine(ex.Message);
                                Console.WriteLine(ex.Source);
                                Menu.Show();
                                choice = int.Parse(Console.ReadLine());
                                break;
                            }



                            parking.RemoveCarById(idCar);


                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        {
                            Console.WriteLine("We want increase cars balance");
                            Console.WriteLine("This is the list of our parking");
                            Console.WriteLine(parking);
                            Console.WriteLine("Make your choice about cars id and then press enter");
                            string idCar = Console.ReadLine();
                            Console.WriteLine("Make your choice about sum of increasing");
                            int z = int.Parse(Console.ReadLine());
                            parking.IncreaseBalanceCarById(idCar, z, true);


                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 4:
                        {
                            Console.WriteLine("Transactions for last minute");
                            parking.ShowTransactionsPerLastMinute();

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;

                    case 5:
                        {
                            Console.WriteLine("Parkings earnings");
                            Console.WriteLine(parking.ShowBalance());

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;


                    case 6:
                        {
                            Console.WriteLine("Parkings free places");
                            Console.WriteLine(parking.CountOfFreePlaces());

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        {
                            Console.WriteLine("Pull data from Transactions.log");
                            parking.ShowLog();

                        }
                        Menu.Show();
                        choice = int.Parse(Console.ReadLine());
                        break;



                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Hello1Default");
                        break;
                }
            }

            Console.WriteLine(parking);

        }
    }
}
