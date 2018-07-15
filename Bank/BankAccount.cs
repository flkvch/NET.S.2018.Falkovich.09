using System;

namespace Bank
{
    /// <summary>
    /// Privelege of BankAccount
    /// </summary>
    internal enum Privilege
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

        internal string GetInfo()
        {
            return $"Client: \nFirst name:{firstName} \nLast name: { lastName} \nDate of birth: { dateOfBirth} \nAdress: { adress}" +
            $"\nPassport data: { passportData}\nTelephone: { telephone}";
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
        public BankAccount(Client client, string priority)
        {
            ++NumberOfAccount;
            this.Client = client;
            Balance = 0;
            int numPriority = 2;
            switch (priority)
            {
                case "Base":
                    {
                        numPriority = 2;
                        break;
                    }

                case "Silver":
                    {
                        numPriority = 4;
                        break;
                    }

                case "Gold":
                    {
                        numPriority = 6;
                        break;
                    }

                case "Platinum":
                    {
                        numPriority = 8;
                        break;
                    }

                default:
                    {
                        numPriority = 2;
                        break;
                    }
            }

            Privilege = (Privilege)numPriority;
            IsActive = true;
        }

        /// <summary>
        /// Gets or sets the balance.
        /// </summary>
        /// <value>
        /// The balance.
        /// </value>
        public decimal Balance { get; private set; }

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

        public string GetInfo()
        {
            string info = $"The number of account: {NumberOfAccount }";
            if (IsActive)
            {
                info += "\nIs active";
            }
            else
            {
                info += "\nIs not active";
            }

            info += $"\nBalance: {Balance}" + $"\nPrivelege: {Privilege}" + $"\nBonus points: { BonusPoints}" + $"\n{Client.GetInfo()}";
            return info;
        }

        private int CostBalance() => (int)Privilege * (int)Math.Log((double)Balance + 1, 2);

        private int CostRefill(int sum) => (int)Privilege * (int)Math.Log(sum + 1, 2);

        private int CountRefillBonus(int sum) => 10 * (CostRefill(sum) - CostBalance());

        private int CountWithdrawBonus(int sum) => (CostBalance()) - CostRefill(sum);
    }
}
