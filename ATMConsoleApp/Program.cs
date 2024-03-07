using System;
using System.Collections.Generic;

public class cardHolder
{
    string cardNumber;
    int pin;
    double balance;
    string firstName;
    string lastName;

    public cardHolder(string cardNumber, int pin, string firstName, string lastName, double balance)
    {
        this.cardNumber = cardNumber;
        this.pin = pin;
        this.balance = balance;
        this.firstName = firstName;
        this.lastName = lastName;
    }
    public string getCardNumber()
    {
        return cardNumber;
    }
    public int getPin()
    {
        return pin;
    }
    public double getBalance()
    {
        return balance;
    }
    public string getFirstName()
    {
        return firstName;
    }
    public string getLastName()
    {
        return lastName;
    }
    public void setNumber(string newCardNumber)
    {
        cardNumber = newCardNumber;
    }
    public void setPin(int newPin)
    {
        pin = newPin;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }
    public void setFirstName(string newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(string newLastName)
    {
        lastName = newLastName;
    }

    public static void Main(string[] args)
    {
        void printOptions()
        {
            System.Console.WriteLine("Please choose one of the following options...");
            System.Console.WriteLine("1. Deposit Money");
            System.Console.WriteLine("2. Withdraw Money");
            System.Console.WriteLine("3. Show Balance");
            System.Console.WriteLine("4. Exit");
        }
        void deposit(cardHolder currentUser)
        {
            System.Console.WriteLine("How much would you like to deposit?");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.setBalance(deposit);
            System.Console.WriteLine("Thank you for your deposit. Your new balance is: " + currentUser.getBalance());
        }
        void withdraw(cardHolder currentUser)
        {
            System.Console.WriteLine("How much would you like to withdraw?");
            double withdraw = double.Parse(System.Console.ReadLine());
            if (withdraw > currentUser.getBalance())
            {
                System.Console.WriteLine("Insufficient funds. Please try again.");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdraw);
                System.Console.WriteLine("Thank you for your withdrawal. Your new balance is: " + currentUser.getBalance());
            }
        }
        void balance(cardHolder currentUser)
        {
            System.Console.WriteLine("Your current balance is: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("1234432122223333", 0101, "Thomas", "Viard", 1000.00));
        cardHolders.Add(new cardHolder("1234432122224444", 4545, "Alex", "Wrtl", 500.00));
        cardHolders.Add(new cardHolder("1234432122225555", 7878, "Alfred", "Lafrod", 2000.00));
        cardHolders.Add(new cardHolder("1234432122226666", 1212, "Lea", "Gel", 3000.00));
        cardHolders.Add(new cardHolder("1234432122227777", 6969, "Colas", "Chaussure", 4000.00));

        System.Console.WriteLine("Welcome to the ATM. Please enter your card number: ");
        string debitcardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitcardNum = System.Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.getCardNumber() == debitcardNum);
                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid card number. Please try again.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Invalid card number. Please try again.");
            }
        }
        System.Console.WriteLine("Please enter your pin: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (currentUser.getPin() == userPin)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Invalid pin. Please try again.");
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Invalid pin. Please try again.");
            }
        }
        System.Console.WriteLine("Welcome " + currentUser.getFirstName() + " " + currentUser.getLastName() + "!");
        int option = 0;
        do
        {
            printOptions();
            option = int.Parse(System.Console.ReadLine());
            switch (option)
            {
                case 1:
                    deposit(currentUser);
                    break;
                case 2:
                    withdraw(currentUser);
                    break;
                case 3:
                    balance(currentUser);
                    break;
                case 4:
                    break;
                default:
                    System.Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
        while (option != 4);
        System.Console.WriteLine("Thank you for using the ATM. Have a great day!");
    }

}
