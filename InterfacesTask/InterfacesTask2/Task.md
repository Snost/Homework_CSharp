## Task Interfaces

To add the following new functionalities to the project created in task Aggregation: 

1. To create interface **Iprolongable** (prolonging deposit) and declare within it method **CanToProlong** without parameters that returns logic value true or false, depending on the fact whether this specific deposit can be prolonged or not. 

2. To implement interface **IProlongable** in classes **SpecialDeposit** and **LongDeposit**. 

3. In addition, special deposit (**SpecialDeposit**) can be prolonged only when more than 1000 UAH were deposited, and long-term deposit (**LongDeposit**) can be prolonged if the period of deposit is no longer than 3 years. 

4. To implement standard generic interface **IComparable<Deposit>** in abstract class **Deposit**. Total sum amount (sum deposited plus interest during entire period) should be considered as comparison criteria of **Deposit** instances. 

5. To implement additionally in class **Client**: 
 
- Method **SortDeposits**, which performs deposits sorting in array **deposits** in descending order of total sum amount on deposit upon deposit expiration. 
- Method **CountPossibleToProlongDeposit**, which returns integer – amount of current client’s deposits that can be prolonged. 
