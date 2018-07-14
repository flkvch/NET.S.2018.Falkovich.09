using System;

namespace Bank
{
    /// <summary>
    /// Privelege of BankAccount
    /// </summary>
    public enum Privilege
    {
        Base = 2,
        Silver = 4,
        Gold = 6,
        Platinum = 8
    }

    /// <summary>
    /// Client Information
    /// </summary>
     public struct Client
    {
        private string firstName;
        private string lastName;
        private string dateOfBirth;
        private string passportData;
        private string telephone;
        private string adress;   
        
        public Client(string firstName, string lastName, string dateOfBirth, string passportData, string telephone, string adress)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.adress = adress;
            this.passportData = passportData;
            this.telephone = telephone;
        }

        public void Print()
        {
            Console.WriteLine($"Client: \n{firstName} \n{ lastName} \n{ dateOfBirth} \n{ adress}" +
            $"\n{ passportData}\n{ telephone}");
        }
    }

    /// <summary>
    /// Bank Account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="priority">The priority.</param>
        public BankAccount(Client client, int priority)
        {
            ++NumberOfAccount;
            this.Client = client;
            Balance = 0;
            Privilege = (Privilege)priority;
            IsActive = true;
            //Console.WriteLine($"Account #{NumberOfAccount} is created");
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public int Balance { get; private set; }

        public int NumberOfAccount { get; private set; } = 0;

        private Client Client { get; set; }

        private Privilege Privilege { get; set; }

        /// <summary>
        /// Gets or sets the bonus points.
        /// </summary>
        /// <value>
        /// The bonus points.
        /// </value>
        public int BonusPoints { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; private set; }

        /// <summary>
        /// Refills the specified sum.
        /// </summary>
        /// <param name="sum">The sum.</param>
        /// <exception cref="System.InvalidOperationException">The account isn't active.</exception>
        public void Refill(int sum)
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("The account isn't active.");
            }

            BonusPoints += CountRefillBonus(sum);   
            Balance += sum;
        }

        /// <summary>
        /// Withdraws the specified sum.
        /// </summary>
        /// <param name="sum">The sum.</param>
        /// <exception cref="System.InvalidOperationException">The account isn't active.</exception>
        /// <exception cref="System.ArgumentException"></exception>
        public void Withdraw(int sum)
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("The account isn't active.");
            }

            if (sum > Balance)
            {
                throw new ArgumentException($"You have only {Balance} on your " +
                    $"Balance and you've tried to withdraw {sum}.");
            }

            BonusPoints -= CountWithdrawBonus(sum);
            Balance -= sum;
        }

        /// <summary>
        /// Deletes the account.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">The account is already deleted.</exception>
        public void DeleteAccount()
        {
            if (!IsActive)
            {
                throw new InvalidOperationException("The account is already deleted.");
            }

            IsActive = false;
        }

        /// <summary>
        /// Activates the account.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Account is already active.</exception>
        public void ActivateAccount()
        {
            if (IsActive)
            {
                throw new InvalidOperationException("Account is already active. ");
            }

            IsActive = true;
        }

        public void GetStatus()
        {
            Console.WriteLine($"The number of account: {NumberOfAccount }");
            if (IsActive)
            {
                Console.WriteLine("Is active");
            }
            else
            {
                Console.WriteLine("is not active");
            }

            Console.WriteLine($"Balance: {Balance}");
            Console.WriteLine($"Privelege: {Privilege}");
            Console.WriteLine($"Bonus points: { BonusPoints}");
            Client.Print();
        }

        private int CostBalance() => (int)Math.Log(Balance + 1, (int)Privilege);

        private int CostRefill(int sum) => (int)Math.Log(sum + 1, (int)Privilege);

        private int CountRefillBonus(int sum) => CostRefill(sum) / (CostBalance() + 1);

        private int CountWithdrawBonus(int sum) => 10 * CostRefill(sum) / (CostBalance() + 1);
    }
}
