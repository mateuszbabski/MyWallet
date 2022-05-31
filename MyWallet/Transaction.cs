using System;

public class Transaction
{
    public int Id { get; set; }
    public int BudgetID { get; set; }

    public string Type { get; set; }
    public string Category { get; set; }

    public decimal Value { get; set; }
    public DateTime TransactionDate { get; set; }

    public string Description { get; set; }

    public Budget Budget { get; set; }

}



