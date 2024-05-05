using System;


    
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

    public class BaseDeposit : Deposit
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
    }

    
    public class SpecialDeposit : Deposit
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
    }

    
    public class LongDeposit : Deposit
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
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Run tests to implement the task");
        Console.ReadLine();
        }
    }

