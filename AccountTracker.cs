using System;
using System.Collections.Generic;
using System.Linq;

namespace Bank
{
  public class AccountTracker
  {
    public List<Account> Accounts { get; set; }


    public void DepositToCheck(Account account, int amountToDeposit)

    {

      account.Checking = account.Checking + amountToDeposit;

    }
    public void DepositToSavings(Account account, int amountToDeposit)
    {
      account.Saving = account.Saving + amountToDeposit;
    }

    public void WithdrawChecking(Account account, int amountToWithdraw)
    {
      account.Checking = account.Checking - amountToWithdraw;
    }
    public void WithdrawSaving(Account account, int amountToWithdraw)
    {
      account.Saving = account.Saving - amountToWithdraw;
    }
    public void TransferToChecking(Account account, int amtToTransToChecking)
    {
      account.Saving = account.Saving - amtToTransToChecking;
      account.Checking = account.Checking + amtToTransToChecking;
    }
    public void TransferToSaving(Account account, int amtToTransToSaving)
    {
      account.Checking = account.Checking - amtToTransToSaving;
      account.Saving = account.Saving + amtToTransToSaving;
    }


  }
}