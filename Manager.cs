using static System.Int32;
using System;
using System.Collections.Generic;
using BankProj;

public class Manager : IEmployee
{
    
    public void ChangeMobile(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter ID client: ");
        int id = Parse(Console.ReadLine()!);
        Console.WriteLine($"Enter new mobile number");
        clients[id].MobileNum = Console.ReadLine();
        clients[id].Changes += $"{DateTime.Now}  {employee.GetType()} " + "Changed surname";
        Changes.Add(clients[id].Changes!); ;

    }

    public void ChangeName(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter ID client: ");
        int id = Parse(Console.ReadLine()!);
        Console.WriteLine($"Enter new name");
        clients[id].Name = Console.ReadLine();
        clients[id].Changes += $"{DateTime.Now}  {employee.GetType()} " + "Changed Name";
        Changes.Add(clients[id].Changes!); ;
    }

    public void ChangePassport(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter ID client: ");
        int id = Parse(Console.ReadLine()!);
        Console.WriteLine($"Enter new PassportID");
        clients[id].PassportNum = Console.ReadLine();
        clients[id].Changes += $"{DateTime.Now} Changed by - {employee.GetType()} " + "Changed passport num";
        Changes.Add(clients[id].Changes!);
    }

    public void ChangePatronymic(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter ID client: ");
        int id = Parse(Console.ReadLine()!);
        Console.WriteLine($"Enter new Patronymic");
        clients[id].Patronymic = Console.ReadLine();
        clients[id].Changes += $"{DateTime.Now} Changed by - {employee.GetType()} " + "Changed patronymic";
        Changes.Add(clients[id].Changes!); ;
    }

    public void ChangeSurname(List<Client> clients, List<string> Changes, IEmployee employee)
    {
        Console.WriteLine($"Enter ID client: ");
        int id = Parse(Console.ReadLine()!);
        Console.WriteLine($"Enter new Surname");
        clients[id].Surname = Console.ReadLine();
        clients[id].Changes += $"{DateTime.Now} Changed by - {employee.GetType()} Changed surname";
        Changes.Add(clients[id].Changes!); ;
    }

    public void AddClient(Client client, List<Client> clients, IEmployee employee, List<string> changes)
    {
        Console.WriteLine("Enter the num of added Clients");
        TryParse(Console.ReadLine(), out int num); 
           for (int i = 0;i<num; i++ )
           {
             Console.WriteLine("Enter name of new Client:");
            client.Name = Console.ReadLine();
            Console.WriteLine("Enter surname of new Client:");
            client.Surname = Console.ReadLine();
            Console.WriteLine("Enter patronymic of new Client:");
            client.Patronymic = Console.ReadLine();
            Console.WriteLine("Enter mobile number of new Client:");
            client.MobileNum = Console.ReadLine();
            Console.WriteLine("Enter passport numbers of new client:");
            client.PassportNum = Console.ReadLine();

            clients.Add(new Client(client.Index++, client.Name, client.Surname,
                client.Patronymic,
                client.MobileNum, client.PassportNum));
            client.Changes += $"Added new client |Name - {client.Name} Surname - {client.Surname}| by ({employee.GetType()}) at {DateTime.Now}.\n";
            Console.WriteLine("Successfully added!");
           }
            changes.Add(client.Changes!);
    }

    public void ShowClientInfo(List<Client> clients)
    {
        foreach (var cl in clients)
        {
            cl.ClientInfo(cl);
        }
    }
    public void SeeOneClient(Client client, List<Client> clients)
    {
        Console.WriteLine("Введите ID клиента");
        TryParse(Console.ReadLine(), out int num);
        for (int i = 0; i <clients.Count ; i++)
        {
            if (num == clients[i].Index) clients[clients[i].Index].ClientInfo(client);
            
        }
    }
}
