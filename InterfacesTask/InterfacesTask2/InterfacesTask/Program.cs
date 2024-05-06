using System;

/*
 TODO
Create interface IProlongable

Add interfaces to classes:
    Deposit (bank account);
    BaseDeposit (regular deposit), 
    SpecialDeposit (special deposit), 
    LongDeposit (long-term deposit)

Implement method CountPossibleToProlong in class Client
 */


public abstract class Deposit
{
    public double Total { get; }
    public int Period { get; }


    public Deposit(double depositTotal, int depositPeriod)
    {
        Total = depositTotal;
        Period = depositPeriod;
    }


    public abstract double Income();
}

public class BaseDeposit : Deposit, IProlongable
{
    public BaseDeposit(double depositTotal, int depositPeriod) : base(depositTotal, depositPeriod)
    {
    }

    public override double Income()
    {
        double income = Total;
        for (int i = 0; i < Period; i++)
        {
            income += income * 0.05;
        }
        return income - Total;
    }

    public bool CanToProlong()
    {
        return true;
    }
}

public class SpecialDeposit : Deposit, IProlongable
{
    public SpecialDeposit(double depositTotal, int depositPeriod) : base(depositTotal, depositPeriod)
    {
    }

    public override double Income()
    {
        double income = Total;
        for (int i = 1; i <= Period; i++)
        {
            income += income * (i / 100.0);
        }
        return income - Total;
    }

    public bool CanToProlong()
    {
        
        return true;
    }
}

public class LongDeposit : Deposit, IProlongable
{
    public LongDeposit(double depositTotal, int depositPeriod) : base(depositTotal, depositPeriod)
    {
    }

    public override double Income()
    {
        if (Period <= 6)
        {
            return 0;
        }

        double income = Total;
        for (int i = 7; i <= Period; i++)
        {
            income += income * 0.15;
        }
        return income - Total;
    }

    public bool CanToProlong()
    {
       
        return Period > 6;
    }
}



public class Client
{
    private Deposit[] deposits;

    public Client()
    {
        deposits = new Deposit[10];
    }

    public bool AddDeposit(Deposit deposit)
    {
        for (int i = 0; i < deposits.Length; i++)
        {
            if (deposits[i] == null)
            {
                deposits[i] = deposit;
                return true;
            }
        }
        return false;
    }

    public int CountPossibleToProlongDeposit()
    {
        int count = 0;
        foreach (Deposit deposit in deposits)
        {
            if (deposit is IProlongable prolongable && prolongable.CanToProlong())
            {
                count++;
            }
        }
        return count;
    }

 
public double TotalIncome()
    {
        double totalIncome = 0;
        foreach (Deposit deposit in deposits)
        {
            if (deposit != null)
            {
                totalIncome += deposit.Income();
            }
        }
        return totalIncome;
    }


    public double MaxIncome()
    {
        double maxIncome = 0;
        foreach (Deposit deposit in deposits)
        {
            if (deposit != null)
            {
                double income = deposit.Income();
                if (income > maxIncome)
                {
                    maxIncome = income;
                }
            }
        }
        return maxIncome;
    }

    public double GetIncomeByNumber(int number)
    {
        if (number >= 1 && number <= deposits.Length && deposits[number - 1] != null)
        {
            return deposits[number - 1].Income();
        }
        return 0;
    }
    public void SortDeposits()
    {
        Array.Sort(deposits, (x, y) =>
        {
            if (x == null && y == null) return 0;
            if (x == null) return 1;
            if (y == null) return -1;

            
            return y.Total.CompareTo(x.Total);
        });
    }

}
public interface IProlongable
{
    bool CanToProlong();
}


class Program
{
    static void Main()
    {
        Console.WriteLine("Run tests to implement the task");
        Client client = new Client();

       
        client.AddDeposit(new BaseDeposit(1000, 12));
        client.AddDeposit(new SpecialDeposit(2000, 6));
        client.AddDeposit(new LongDeposit(3000, 10));
        client.AddDeposit(new BaseDeposit(1500, 24));

        int count = client.CountPossibleToProlongDeposit();
        Console.WriteLine(count);

        
        double totalIncome = client.TotalIncome();
        Console.WriteLine(totalIncome);

        Console.ReadLine();
    }
}

