using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank;

namespace ConsoleBankAccount
{
    static class Program
    {
        static void Main(string[] args)
        {
            BankAccount[] bankSystem = new BankAccount[100];
            int numOfClients = 0;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Bank System. " +
                "\nIf you want to create a new account press -c." +
                "\nIf you want to exit system press -e.");
                string input = Console.ReadLine();
                if (input == "-c")
                    {
                        Console.WriteLine("First, you should enter the information about client. \nEnter the firstname:");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("\nEnter the lastname:");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("\nEnter the day of birth:");
                        string dateOfBirth = Console.ReadLine();
                        Console.WriteLine("\nEnter the adress:");
                        string adress = Console.ReadLine();
                        Console.WriteLine("\nEnter the passport data:");
                        string passportData = Console.ReadLine();
                        Console.WriteLine("\nEnter the telephone:");
                        string telephone = Console.ReadLine();
                    Client c1 = new Client(firstName, lastName, dateOfBirth, passportData, telephone, adress);
                       
                        Console.WriteLine("Second, you should enter the priority of the bank account:");
                        int s1;
                        switch (Console.ReadLine())
                        {
                            case "Base":
                                {
                                    s1 = 2;
                                    break;
                                }

                            case "Silver":
                                {
                                    s1 = 4;
                                    break;
                                }

                            case "Gold":
                                {
                                    s1 = 6;
                                    break;
                                }

                            case "Platinum":
                                {
                                    s1 = 8;
                                    break;
                                }

                            default:
                                {
                                    s1 = 2;
                                    break;
                                }
                        }

                    bankSystem[++numOfClients] = new BankAccount(c1, s1);

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine($"You are in the menu of choosing accounts. Enter the number of acc from 1 to {numOfClients}." +
                            $"\nIf you want to exit enter -e");
                        string s11 = Console.ReadLine();
                        if (s11 == "-e")
                        {
                            break;
                        }

                        int num = int.Parse(s11);

                        while (true)
                        {
                            BankAccount a1 = bankSystem[num];
                            Console.Clear();
                            Console.WriteLine($"You are in the menu of the account number {a1.NumberOfAccount}." +
                                "\n\nIf yiu want to get status of acc press -s" +
                                "\n If you want to Refill press -r" +
                                "\nIf you want to Withdraw press -w" +
                                "\nIf you want to Delete Account press -d" +
                                "\nIf you want to Activate deleted Account press -a" +
                                "\nIf you want to exit this menu press -e");

                            string input2 = Console.ReadLine();
                            if (input2 == "-s")
                            {
                                a1.GetStatus();
                                Console.ReadLine();
                            }

                            if (input2 == "-r")
                            {
                                Console.Write("Enter the sum of refill: ");
                                try
                                {
                                    a1.Refill(int.Parse(Console.ReadLine()));
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                Console.ReadLine();
                            }

                            if (input2 == "-w")
                            {
                                Console.Write("Enter the sum of withdraw: ");
                                try
                                {
                                    a1.Withdraw(int.Parse(Console.ReadLine()));
                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                Console.ReadLine();
                            }

                            if (input2 == "-d")
                            {
                                try
                                {
                                    a1.DeleteAccount();
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                Console.ReadLine();
                            }

                            if (input2 == "-a")
                            {
                                try
                                {
                                    a1.ActivateAccount();
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }

                                Console.ReadLine();
                            }

                            if (input2 == "-e")
                            {
                                break;
                            }
                        }
                    }
                }

                if (input == "-e")
                {
                    return;
                }
            }
        }
    }
}
