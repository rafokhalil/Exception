using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ExceptionTask
{
    class Program
    {
        class BankCard
        {
            public string Bankname { get; set; }
            public string Username { get; set; }
            public string PAN { get; set; }
            public string PIN { get; set; }
            public string CVC { get; set; }
            public DateTime ExpireDate { get; set; }
            public decimal Balans { get; set; }

            public void ShowBankCard()
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine();
                Console.WriteLine("=========BankCard==========");
                Console.WriteLine($"Bankname : {Bankname}");
                Console.WriteLine($"Username : {Username}");
                Console.WriteLine($"PAN : {PAN}");
                //Console.WriteLine($"CVC : {CVC}");    //Random oldugunu yoxlamaq ucun
                Console.WriteLine($"ExpireDate : {ExpireDate}");
                Console.ResetColor();
            }



        }

        class Client
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
            public double Salary { get; set; }
            public BankCard bankcard { get; set; }

            public void ShowClient()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine();
                Console.WriteLine("=========CLIENT==========");
                Console.WriteLine($"Id : {ID}");
                Console.WriteLine($"Name : {Name}");
                Console.WriteLine($"Surname : {Surname} ");
                Console.WriteLine($"Age : {Age} ");
                Console.WriteLine($"Salary : {Salary} ");
                bankcard.ShowBankCard();
                Console.ResetColor();
            }
        }


        class Bank
        {
            public Client[] clients { get; set; }

            public int CountofClients { get; set; } = 0;


            public void AddClient(ref Client client)
            {
                var temp = new Client[++CountofClients];

                if (clients != null)
                {
                    clients.CopyTo(temp, 0);

                }
                temp[temp.Length - 1] = client;

                clients = temp;
            }

            public void ShowClients()
            {
                if (clients != null)
                {

                    foreach (var c in clients)
                    {
                        if (c.bankcard.PAN.Length == 16 && c.bankcard.PIN.Length == 4 && c.bankcard.CVC.Length == 3)
                        {
                            c.ShowClient();
                        }

                        else if (c.bankcard.PAN.Length > 16 || c.bankcard.PAN.Length < 16)
                        {
                            throw new ArgumentOutOfRangeException("PAN code is written outside the boundaries");
                        }

                        else if (c.bankcard.PIN.Length > 4 || c.bankcard.PIN.Length < 4)
                        {
                            throw new ArgumentOutOfRangeException("PIN code is written outside the boundaries");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("There is no Client in Bank");
                }
            }
        }

        public static void Run()
        {
            DateTime datetime = DateTime.Now;

            Random random = new Random();

            int CVC1 = random.Next(100, 999);
            int CVC2 = random.Next(100, 999);
            int CVC3 = random.Next(100, 999);



            try
            {
                BankCard bankCard1 = new BankCard
                {
                    Bankname = "Kapital",
                    Username = "Rafael",
                    PAN = "5568307451345147",
                    PIN = "3366",
                    CVC = CVC1.ToString(),
                    ExpireDate = new DateTime(2021, 10, 30),
                    Balans = random.Next(1000, 2000),
                };



                BankCard bankCard2 = new BankCard
                {
                    Bankname = "Beynelxalq Bank",
                    Username = "Revan",
                    PAN = "9165487443133221",
                    PIN = "6548",
                    CVC = CVC2.ToString(),
                    ExpireDate = new DateTime(2021, 9, 30),
                    Balans = random.Next(1000, 2000),
                };


                BankCard bankCard3 = new BankCard
                {
                    Bankname = "Kapital",
                    Username = "Mehemmed",
                    PAN = "6985723144317324",
                    PIN = "3333",
                    CVC = CVC3.ToString(),
                    ExpireDate = new DateTime(2021, 5, 30),
                    Balans = random.Next(1000, 2000),
                };




                Client clients1 = new Client
                {
                    ID = 1,
                    Name = "Rafael",
                    Surname = "Xelilzade",
                    Age = 18,
                    Salary = 4000,
                    bankcard = bankCard1
                };


                Client clients2 = new Client
                {
                    ID = 2,
                    Name = "Revan",
                    Surname = "Esgerov",
                    Age = 18,
                    Salary = 2000,
                    bankcard = bankCard2
                };

                Client clients3 = new Client
                {
                    ID = 3,
                    Name = "Mehemmed",
                    Surname = "Kazimov",
                    Age = 20,
                    Salary = 800,
                    bankcard = bankCard3
                };

                Bank bank = new Bank();

                bank.AddClient(ref clients1);
                bank.AddClient(ref clients2);
                bank.AddClient(ref clients3);

                bank.ShowClients();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }

        static void Main(string[] args)
        {
            Run();
        }
    }
}
