using BankProj;
using System;
using System.Collections.Generic;
public class Client
{
    #region Fields
    string? name;
    string? surname;
    string? patronymic;
    string? mobileNum;
    string? passportNum;
    int index;
    string? changes;

    #endregion
    /// <summary>
    /// Client constructor
    /// </summary>
    /// <param name="Name">Имя</param>
    /// <param name="Surname">Фамилия</param>
    /// <param name="Patronymic">Отчество</param>
    /// <param name="MobileNum">Мобильный номер</param>
    /// <param name="PassortNum">Серия и номер пасспорта</param>
    public Client(int Index,
                    string? Name, 
                    string? Surname,
                    string? Patronymic,
                    string? MobileNum,
                    string? PassortNum) // Client constructor
    {
        this.index = Index;
        this.name = Name;
        this.surname = Surname;
        this.patronymic = Patronymic;
        this.mobileNum = MobileNum;
        this.passportNum = PassortNum;
    }
    public Client() : this(0,"", "", "", "", "") // Autogenerate Client
    { }

    #region Properties
    public string? Name { get => name; set => name = value; }
    public string? Surname { get => surname; set => surname = value; }
    public string? Patronymic { get => patronymic; set => patronymic = value; }
    public string? MobileNum { get => mobileNum; set => mobileNum = value; }
    public string? PassportNum { get => passportNum; set => passportNum = value; }
    public int Index { get => index; set => index = value;} // ID
    public string? Changes { get => changes; set => changes = value;}
    
    #endregion

    #region Mehodts
    public void ClientInfo(Client client) =>
    Console.WriteLine(string.Format(" |ID: {0,-5} | First Name:{1,-10} | Second Name: {2,-15} | " +
            "Patronymic: {3,-15} | Mobile Number: {4,-11} | Passport Number: {5,-12}",
                    this.index,
                    this.name,
                    this.surname,
                    this.patronymic,
                    this.mobileNum,
                    this.passportNum));



    /// <summary>
    /// Autogenerate Cleints method
    /// </summary>
    /// <param name="num">Number of generated clients</param>
    /// <returns></returns>
    public List<Client> ClientGeneration(int num)
    {
        
        List<Client> clients = new List<Client>();
        for (int i = 0; i < num; i++)
        {
            var genGuid = Guid.NewGuid().ToString().Substring(0, 5);
            clients.Add(new Client(Index++, $"{genGuid}", $"{genGuid}",
                $"{genGuid}", $"{genGuid}", $"" +
                                            $"{genGuid}"));

        }
        return clients;
    }


    #endregion
}