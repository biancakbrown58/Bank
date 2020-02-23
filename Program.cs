using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System.Globalization;

namespace Bank
{
  class Program
  {
    static void SaveTransaction(List<Account> accounts)
    {
      var writer = new StreamWriter("accounts.csv");
      var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
      csvWriter.WriteRecords(accounts);
      writer.Flush();
    }
    static void Main(string[] args)
    {
      // var account = new Account
      // {
      //   User = "Bianca",
      //   Checking = 1000,
      //   Saving = 1000
      // };
      Console.WriteLine("   Welcome to Suncoast Bank");
      Console.WriteLine("  ---------------------------");
      var tracker = new AccountTracker();
      //var account = Account();




      var accounts = new List<Account>();

      var reader = new StreamReader("accounts.csv");
      var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
      accounts = csvReader.GetRecords<Account>().ToList();
      var account = accounts[0];

      Console.WriteLine($"Your current checking Balance is ${account.Checking}");
      Console.WriteLine($"Your current saving Balance is ${account.Saving}");

      var isRunning = true;
      while (isRunning)
      {
        Console.WriteLine("");
        Console.WriteLine("  What would you like to do?  ");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine(" Deposit Checking or Savings");
        Console.WriteLine("Enter dc=Checking / ds=Savings");
        Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        Console.WriteLine(" Withdraw Checking or Savings");
        Console.WriteLine("Enter wc=Checking / ws=Savings");
        Console.WriteLine(" ");
        Console.WriteLine("    Enter 'quit' to exit");
        Console.WriteLine(" ");


        var input = Console.ReadLine().ToLower();
        if (input == "checking")
        {
          // Deposit Checking
          Console.WriteLine("Deposit Amount:");
          var amountToDeposit = int.Parse(Console.ReadLine());
          tracker.DepositToCheck(account, amountToDeposit);
          Console.WriteLine($"Checking Balance: {account.Checking}");
        }
        else if (input == "saving")
        {
          // Deposit Savings
          Console.WriteLine("Deposit Amount:");
          var amountToDeposit = int.Parse(Console.ReadLine());
          tracker.DepositToSavings(account, amountToDeposit);
          //SaveTransaction(accounts);
          Console.WriteLine($"Savings Balance: {account.Saving}");
        }
        else if (input == "wc")
        {
          // Withdraw Checking
          Console.WriteLine("Withdraw Amount:");
          var amountToWithdraw = int.Parse(Console.ReadLine());
          tracker.WithdrawChecking(account, amountToWithdraw);
          Console.WriteLine($"You now have {account.Checking}");
          //SaveTransaction(accounts);
        }
        // ammttotrans = userinput
        // acct.check = 

        else if (input == "ws")
        {
          // Withdraw Savings
          Console.WriteLine("Withdraw Amount:");
          var amountToWithdraw = int.Parse(Console.ReadLine());
          tracker.WithdrawSaving(account, amountToWithdraw);
          Console.WriteLine($"You now have {account.Saving}");
          //SaveTransaction(accounts);
        }
        else if (input == "tc")
        {
          Console.WriteLine("Transfer Amount:");
          var amtToTransToChecking = int.Parse(Console.ReadLine());
          tracker.TransferToChecking(account, amtToTransToChecking);
          Console.WriteLine($"new Savings balance: {account.Saving}");
          Console.WriteLine($"new Checking total: {account.Checking}");
        }
        else if (input == "ts")
        {
          Console.WriteLine("Transfer Amount:");
          var amtToTransToSaving = int.Parse(Console.ReadLine());
          tracker.TransferToSaving(account, amtToTransToSaving);
          Console.WriteLine($"new checking balance: {account.Checking}");
          Console.WriteLine($"new Saving total: {account.Saving}");
        }
        else if (input == "quit")
        {
          SaveTransaction(accounts);
          isRunning = false;
        }
      }
    }
  }
}

