using BankProj;
using System;
using System.Collections.Generic;

public interface IEmployee
{
    
    void ChangeName(List<Client> clients, List<string> changes, IEmployee employee);
    void ChangeSurname(List<Client > clients, List<string> changes, IEmployee employee);
    void ChangePatronymic(List<Client > clients, List<string> changes, IEmployee employee);
    void ChangeMobile(List<Client > clients, List<string> changes, IEmployee employee);
    void ChangePassport(List<Client> clients, List<string> changes, IEmployee employee);
    void ShowClientInfo(List<Client> clients);
    void AddClient(Client client, List<Client> clients, IEmployee employee, List<string> changes);
    void SeeOneClient(Client client, List<Client> clients);
}