using static System.Int32;
using System;
using System.Collections.Generic;
using BankProj;

public class Consultant : IEmployee
{
    
    public void ChangeName(List<Client> clients, List<string > Changes, IEmployee employee)
    {
        Console.WriteLine("You cant use this");
    }

    public void ChangeSurname(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine("You cant use this");
    }

    public void ChangePatronymic(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine("You cant use this");
    }

    public void ChangeMobile(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter client phone number: ");
        if (string.IsNullOrWhiteSpace(Console.ReadLine()))
            Console.WriteLine($"Phone number cannot be null");
    }

    public void ChangePassport(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine("You cant use this");
    }

    public void ShowClientInfo(List<Client> clients)
    {
        foreach (var cl in clients)
        {
            Console.WriteLine(string.Format(" |ID: {0,-5} | First Name:{1,-10} | Second Name: {2,-15} | " +
            "Patronymic: {3,-15} | Mobile Number: {4,-11} | Passport Number: ** ** ******",
                    cl.Index,
                    cl.Name,
                    cl.Surname,
                    cl.Patronymic,
                    cl.MobileNum));
        }
    }

    public void AddClient(Client client, List<Client> clients, IEmployee employee, List<string> changes)
    {
        Console.WriteLine("You cant use this");
    }

    public void SeeOneClient(Client client, List<Client> clients)
    {
        Console.WriteLine("Enter client ID");
        TryParse(Console.ReadLine(), out int num);
        for (int i = 0; i < clients.Count; i++)
        {
            if (num == clients[i].Index) clients[clients[i].Index].ClientInfo(client);
        }
    }
}

