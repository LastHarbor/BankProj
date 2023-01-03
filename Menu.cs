using BankProj;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.IO;

public class Menu
{
    string path = @".\DataBase\Clients.json";
    private static readonly Client _client =  new Client();
    private readonly List<Client> _listClients = new List<Client>();
    private readonly List<string> _changes = new List<string>();
    public void Start()
    {
        DataBase(_listClients, _changes);
        IEmployee? employee = null;
        Console.WriteLine($"1 - Работать как менеджер\n"+
        "2 - Работать как консультант\n3 - Exit");
        string? input = Console.ReadLine();
        bool result = char.TryParse(input, out char sw);
        if (result)
        {
            switch (sw)
            {
                case '1':
                    Console.WriteLine($"Enter by manager");
                    employee = new Manager();
                    Console.Clear();
                    break;
                case '2':
                    Console.WriteLine($"Enter by consultant");
                    employee = new Consultant();
                    Console.Clear();
                    break;
                    case '3':
                    Environment.Exit(0);
                    break;
            }
        }
        else Console.WriteLine($"Нельзя выбрать что то другое!");
        StartMenu(employee!);
    }

    public void StartMenu(IEmployee employee)
    {
        bool flag = true;
        while (flag)
        {
            string menu = new string('-', 30) +
                          "\n1 - List clients\n" +
                          "2 - Change client Name \n" +
                          "3 - Change client Surname \n" +
                          "4 - Change client Patronymic \n" +
                          "5 - Change client phone number\n" +
                          "6 - Change client passport numbers  \n" +
                          "7 - Add new client\n" +
                          "8 - See one client\n" +
                          "9 - Save and close\n"+
                          "10 - Change List\n"+
                          "11 - Exit from this User";
            Console.WriteLine(menu);
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("User - " + employee?.GetType());
            var sw2 = Console.ReadLine();
            switch (sw2)
            {
                case "1":
                    employee?.ShowClientInfo(_listClients);
                    break;

                case "2":
                    employee?.ChangeName(_listClients, _changes, employee);
                    break;

                case "3":
                    employee?.ChangeSurname(_listClients, _changes, employee);
                    break;

                case "4":
                    employee?.ChangePatronymic(_listClients, _changes, employee);
                    break;

                case "5":
                    employee?.ChangeMobile(_listClients, _changes, employee);
                    break;

                case "6":
                    employee?.ChangePassport(_listClients, _changes, employee);
                    break;

                case "7":
                    employee?.AddClient(_client, _listClients, employee, _changes);
                    break;
                case "8":
                    employee?.SeeOneClient(_client, _listClients);
                    break;
                case "9":
                    CreateJson(_listClients);
                    LogList(_changes);
                    Environment.Exit(0);
                    break;
                case "10":
                    foreach (var change in _changes)
                    {
                        Console.WriteLine(change);
                    }
                    break;
                case "11":
                    Start();
                    break;
            }
        }
    }
    public void CreateJson(List<Client> clients)
    {
       path = @".\DataBase\Clients.json";
       if(!File.Exists(path)) File.WriteAllText(path, string.Empty);
       using (StreamWriter file = File.CreateText(path))
        {
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, clients);
        }
    }

    public void DataBase(List<Client> clients, List<string> changes)
    {
        string loglist = File.ReadAllText("Log.txt");
        changes.Add(loglist);
        //
        string json = File.ReadAllText(path);
        var data = JsonConvert.DeserializeObject<List<Client>>(json);
        foreach (var cl in data)
        {
        clients.Add(new Client(cl.Index, cl.Name, cl.Surname, cl.Patronymic, cl.MobileNum, cl.PassportNum));
        }
    }

    public void LogList(List<string> changes)
    {
        path = "Log.txt";
        if(!File.Exists(path)) File.Create(path);
        foreach (var ch in changes)
        {
            File.WriteAllText(path, ch);
        }
    }
}


