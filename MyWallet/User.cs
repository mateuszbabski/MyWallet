﻿using System;

public class User
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }
    public string PasswordHash { get; set; }

    public List<Budget> Budgets { get; set; }
}





