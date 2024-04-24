using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkModul06
{
        class Money
        {
            int dollars;
            int cents;
            public Money(Money money)
            {
                dollars = money.dollars;
                cents = money.cents;
            }
            public Money(int dollars, int cents)
            {
                this.dollars = dollars;
                this.cents = cents;
            }
            public string GetPrice()
            {
                return dollars + "." + cents;
            }
            public void DecreaseSum(int value)
            {
                dollars -= value;
                if (dollars < 0)
                {
                    dollars = 0;
                    cents = 0;
                }
            }
        }
        class Product : Money
        {
            public Product(Money money, string name) : base(money)
            {
                Name = name;
            }
            public string Name { get; set; }
            public Product(int dollars, int cents, string name) : base(dollars, cents)
            {
                Name = name;
            }

        }
    }



