using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using CompanyManager.Employees;

namespace CompanyManager.MyCompany
{
    class ManagementOfTheCompany
    {
        Company _myCompany;

        public ManagementOfTheCompany() { }

        public void MainMenu()
        {
            Console.Write("\t");

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Management MENU:");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine();

            Console.WriteLine("press 1 to employ the worker;");
            Console.WriteLine("press 2 to dismiss the worker;");
            Console.WriteLine("press 3 to increase the worker in a post;");
            Console.WriteLine("press 4 to show the information on workers of the company");
            Console.WriteLine("press 5 to exit the program.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("select the required action: ");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        void SwitchProgram()
        {
            //Console.Clear();

            switch (EnterNumber(5, ()=>MainMenu()))
            {
                case 1: CreateEmployee(); break;

                case 2: DismissalEmployee(); break;

                case 3: IncreaseEmployee(); break;

                case 4: DisplayEmployee(); break;

                case 5: ExitProgram(); break;
            }
        }

        public void CreateCompany()
        {
            string nameCompany = EnterName("company");

            _myCompany = new Company(nameCompany);
        }
        
        public void CreateCEOCompany()
        {
            string nameCEO = EnterName("CEO");

            double rate = EnterRate("CEO");

            _myCompany.Ceo = new CEO(1, nameCEO, rate);

            Company.NumberOfTheEmployee++;
        }



        void MenuCreateEmployee()
        {
            Console.WriteLine("Choose a category of workers:");

            Console.WriteLine("1 - The manager on the staff;");
            Console.WriteLine("2 - The manager on sales;");
            Console.WriteLine("3 - Workers with hourly payment;");
            Console.WriteLine("4 - Workers with payment under the rate.");

            Console.Write("Enter number of the chosen category: ");
        }

        void CreateEmployee()
        {
            Console.Clear();

            MenuCreateEmployee();

            switch (EnterNumber(4, () => MenuCreateEmployee()))
            {
                case 1: CreateManager("The manager on the staff"); break;

                case 2: CreateManager("The manager on sales"); break;

                case 3: CreateHourlyEmployee(); break;

                case 4: CreateSalariedEmployee(); break;
            }

            Console.ReadKey();
        }

        static string EnterName(string message)
        {
            string name = null;

            Console.Write("Enter the name of a {0}: ", message);

            Console.ForegroundColor = ConsoleColor.Green;

            name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Gray;

            if (string.IsNullOrEmpty(name))
            {
                name = "No name";
            }

            return name;
        }

        static double EnterRate(string post)
        {
            double rate = 0;

            while (true)
            {
                Console.Write("Enter the salary for {0}: ", post);

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    rate = int.Parse(Console.ReadLine());

                    if (rate <= 0)
                        // Closest exception.
                        throw new InvalidOperationException("Enter value > 0.");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (OverflowException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter an integer or real value, for example 7 or 3,14.");

                    continue;
                }
            }

            return rate;
        }

        static int EnterCountHour()
        {
            int countHours = 0;

            while (true)
            {
                Console.Write("Enter quantity of hours: ");

                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    countHours = int.Parse(Console.ReadLine());

                    if (countHours <= 0)
                        // Closest exception.
                        throw new InvalidOperationException("Enter value > 0.");

                    Console.ForegroundColor = ConsoleColor.Gray;

                    break;
                }
                catch (OverflowException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message);

                    continue;
                }
                catch (Exception ex)
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine(ex.Message + "\nEnter an integer value, for example 7.");

                    continue;
                }
            }

            return countHours;
        }

        public void CreateManager(string specialization)
        {
            Console.Clear();

            string name = EnterName("manager");

            Random randId = new Random();

            int id = randId.Next(1000);

            double rate = EnterRate("manager");

            _myCompany.managers.Add(new Manager(id, name, specialization, rate));

            Company.NumberOfTheEmployee++;
        }

        public void CreateHourlyEmployee()
        {
            Console.Clear();

            string name = EnterName("hourly employee");

            Random randId = new Random();

            int id = randId.Next(1000);

            Console.Clear();

            MenuChoiceOfAPost();

            string post = ChoiceOfAPost().ToString();

            int countHour = EnterCountHour();

            double paymentForHour = EnterRate("one hour");

            _myCompany.hourlyEmployees.Add(new HourlyEmployee(id, name, post, countHour, paymentForHour));
        }

        static void MenuChoiceOfAPost()
        {
            Console.WriteLine("Choose a post from the list:");

            Console.WriteLine("1 - The superintendent;");
            Console.WriteLine("2 - The engineer;");
            Console.WriteLine("3 - The master;");
            Console.WriteLine("4 - The worker.");

            Console.Write("Enter number of a necessary post: ");
        }

        Posts ChoiceOfAPost()
        {
            Posts post = Posts.worker;

            switch (EnterNumber(4, ()=>MenuChoiceOfAPost()))
            {
                case 1: post = Posts.superintendent;
                    break;
                case 2: post = Posts.engineer;
                    break;
                case 3: post = Posts.master;
                    break;
                case 4: post = Posts.worker;
                    break;
            }

            return post;
        }

        public void CreateSalariedEmployee()
        {
            Console.Clear();

            string name = EnterName("salaried employee");

            Random randId = new Random();

            int id = randId.Next(1000);

            Console.Clear();

            MenuChoiceOfAPost();

            string post = ChoiceOfAPost().ToString();

            double rate = EnterRate("salaried employee");

            _myCompany.salariedEmployees.Add(new SalariedEmployee(id, name, post, rate));
        }

        int EnterNumber(int number, Action action)
        {
            var numberMenu = 0;

            string message = string.Format("Enter a number from 1 to {0}: ", number);

            // Cycle until one of the menu item numbers is entered
            while (true)
            {
                // The required menu number is entered, taking into account 
                // the overflow and the format of the entered number.
                try
                {
                    numberMenu = int.Parse(Console.ReadLine());

                    var condition = numberMenu > 0 && numberMenu < (number + 1);

                    if (condition)
                    {
                        break;
                    }
                    else
                    {
                        throw new Exception(message);
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (ex.GetType().ToString() == "System.FormatException")
                        {
                            throw new FormatException(message);
                        }
                        else if (ex.GetType().ToString() == "System.OverflowException")
                        {
                            throw new OverflowException(message);
                        }
                        else
                        {
                            Console.Clear();

                            action();

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n" + ex.Message);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    catch (OverflowException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    catch (FormatException exc)
                    {
                        Console.Clear();

                        action();

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\n" + exc.Message);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }

            return numberMenu;
        }

        public void DismissalEmployee()
        {
            Console.Clear();

            MenuDismissal();

            switch (EnterNumber(3, () => MenuDismissal()))
            {
                case 1: DismissalManager();  break;
                case 2: DismissalHourlyWorkers(); break;
                case 3: DismissalSalariedWorkers(); break;
            }

            Console.ReadKey();
        }

        void MenuDismissal()
        {
            Console.WriteLine("Choose a category of workers:");

            Console.WriteLine("1 - Managers;");
            Console.WriteLine("2 - Hourly workers;");
            Console.WriteLine("3 - Workers with the salary.");

            Console.Write("Enter number of a category: ");
        }

        void DismissalManager()
        {
            if (_myCompany.managers.Count > 0)
            {
                foreach (var item in _myCompany.managers)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("manager");

                for (int i = 0; i < _myCompany.managers.Count; i++)
                {
                    if (name == _myCompany.managers[i].Name)
                    {
                        _myCompany.managers.Remove(_myCompany.managers[i]);

                        return;
                    }
                }

                Console.WriteLine("The manager with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no manager.");
            }
        }

        void DismissalHourlyWorkers()
        {
            if (_myCompany.hourlyEmployees.Count > 0)
            {
                foreach (var item in _myCompany.hourlyEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("Hourly worker");

                for (int i = 0; i < _myCompany.hourlyEmployees.Count; i++)
                {
                    if (name == _myCompany.hourlyEmployees[i].Name)
                    {
                        _myCompany.hourlyEmployees.Remove(_myCompany.hourlyEmployees[i]);

                        return;
                    }
                }

                Console.WriteLine("The hourly worker with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no hourly worker.");
            }
        }

        void DismissalSalariedWorkers()
        {
            if (_myCompany.salariedEmployees.Count > 0)
            {
                foreach (var item in _myCompany.salariedEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("worker with the salary");

                for (int i = 0; i < _myCompany.salariedEmployees.Count; i++)
                {
                    if (name == _myCompany.salariedEmployees[i].Name)
                    {
                        _myCompany.salariedEmployees.Remove(_myCompany.salariedEmployees[i]);

                        return;
                    }
                }

                Console.WriteLine("The worker with the salary with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no worker on the rate.");
            }
        }

        void MenuIncrease()
        {
            Console.WriteLine("Choose a category of workers:");

            Console.WriteLine("1 - Hourly workers;");
            Console.WriteLine("2 - Workers with the salary.");

            Console.Write("Enter number of a category: ");
        }

        void IncreaseHourlyWorkers()
        {
            if (_myCompany.hourlyEmployees.Count > 0)
            {
                foreach (var item in _myCompany.hourlyEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("Hourly worker");

                for (int i = 0; i < _myCompany.hourlyEmployees.Count; i++)
                {
                    if (name == _myCompany.hourlyEmployees[i].Name)
                    {
                        for (int j = 2; j < (int)Posts.worker; j++)
                        {
                            if (_myCompany.hourlyEmployees[i].Post == ((Posts)j).ToString() && j > 2)
                            {
                                _myCompany.hourlyEmployees[i].Post = ((Posts)(j - 1)).ToString();

                                _myCompany.hourlyEmployees[i].PaymentForHour += _myCompany.hourlyEmployees[i].PaymentForHour * 0.1;
                            }
                        }

                        return;
                    }
                }

                Console.WriteLine("The hourly worker with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no hourly worker.");
            }
        }

        void IncreaseSalariedWorkers()
        {
            if (_myCompany.salariedEmployees.Count > 0)
            {
                foreach (var item in _myCompany.salariedEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("Hourly worker");

                for (int i = 0; i < _myCompany.salariedEmployees.Count; i++)
                {
                    if (name == _myCompany.salariedEmployees[i].Name)
                    {
                        for (int j = 2; j < (int)Posts.worker; j++)
                        {
                            if (_myCompany.salariedEmployees[i].Post == ((Posts)j).ToString() && j > 2)
                            {
                                _myCompany.salariedEmployees[i].Post = ((Posts)(j - 1)).ToString();

                                _myCompany.salariedEmployees[i].TheRate += _myCompany.salariedEmployees[i].TheRate * 0.1;
                            }
                        }

                        return;
                    }
                }

                Console.WriteLine("The worker with the salary with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no worker on the rate.");
            }
        }

        // Повышение в должности.
        void IncreaseEmployee()
        {
            Console.Clear();

            MenuIncrease();

            switch (EnterNumber(2, () => MenuIncrease()))
            {
                case 1: IncreaseHourlyWorkers(); break;
                case 2: IncreaseSalariedWorkers(); break;
            }

            Console.ReadKey();
        }


        void MenuDisplay()
        {
            Console.WriteLine("Choose a category of workers:");

            Console.WriteLine("1 - CEO;");
            Console.WriteLine("2 - Managers;");
            Console.WriteLine("3 - Hourly workers;");
            Console.WriteLine("4 - Workers with the salary.");

            Console.Write("Enter number of a category: ");
        }

        void DisplayEmployee()
        {
            Console.Clear();

            MenuDisplay();

            switch (EnterNumber(4, () => MenuDisplay()))
            {
                case 1: DisplayCEO(); break;
                case 2: DisplayManagers(); break;
                case 3: DisplayHourlyWorkers(); break;
                case 4: IncreaseSalariedWorkers(); break;
            }

            Console.ReadKey();
        }

        void DisplayCEO()
        {
            Console.Clear();

            Console.WriteLine("Name CEO: {0}", _myCompany.Ceo.Name);

            Console.WriteLine("The salary CEO: {0}", _myCompany.Ceo.ChargeOfWages(_myCompany.ProfitOfTheCompany));
        }

        void DisplayManagers()
        {
            if (_myCompany.managers.Count > 0)
            {
                foreach (var item in _myCompany.managers)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("manager");

                for (int i = 0; i < _myCompany.managers.Count; i++)
                {
                    if (name == _myCompany.managers[i].Name)
                    {
                        Console.WriteLine("The salary of the manager with name {0} - {1}", _myCompany.managers[i].Name, _myCompany.managers[i].ChargeOfWages(_myCompany.ProfitOfTheCompany));

                        return;
                    }
                }

                Console.WriteLine("The manager with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no manager.");
            }
        }

        void DisplayHourlyWorkers()
        {
            Console.Clear();

            if (_myCompany.hourlyEmployees.Count > 0)
            {
                foreach (var item in _myCompany.hourlyEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("Hourly worker");

                for (int i = 0; i < _myCompany.hourlyEmployees.Count; i++)
                {
                    if (name == _myCompany.hourlyEmployees[i].Name)
                    {
                        Console.WriteLine("The salary of the hourly worker with name {0} - {1}", _myCompany.hourlyEmployees[i].Name, _myCompany.hourlyEmployees[i].ChargeOfWages(_myCompany.ProfitOfTheCompany));

                        return;
                    }
                }

                Console.WriteLine("The hourly worker with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no hourly worker.");
            }
        }

        void DisplaySalariedWorkers()
        {
            Console.Clear();

            if (_myCompany.salariedEmployees.Count > 0)
            {
                foreach (var item in _myCompany.salariedEmployees)
                {
                    Console.WriteLine(item.Name);
                }

                string name = EnterName("worker with the salary");

                for (int i = 0; i < _myCompany.salariedEmployees.Count; i++)
                {
                    if (name == _myCompany.salariedEmployees[i].Name)
                    {
                        Console.WriteLine("The salary of the worker with the salary with name {0} - {1}", _myCompany.salariedEmployees[i].Name, _myCompany.salariedEmployees[i].ChargeOfWages(_myCompany.ProfitOfTheCompany));

                        return;
                    }
                }

                Console.WriteLine("The worker with the salary with such name is not present.");
            }
            else
            {
                Console.WriteLine("In the company there is no worker on the rate.");
            }
        }

        void ExitProgram()
        {
            Environment.Exit(0);
        }

        public void Run()
        {
            CreateCompany();

            CreateCEOCompany();

            Console.Clear();

            Console.WriteLine("The company '{0}' is successfully created!\n", _myCompany.NameCompany);


            while (true)
            {
                Console.Clear();

                MainMenu();

                SwitchProgram();
            }
        }
    }
}
