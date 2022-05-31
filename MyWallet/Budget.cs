using System;

public class Budget
{
    public int Id { get; set; }
    public int UserID { get; set; }

    public string Name { get; set; }
    public string? Description { get; set; }

    public List<Transaction> Transactions { get; set; }
    public User User { get; set; }

}





