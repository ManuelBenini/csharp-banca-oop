
public class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    public int Salary { get; set; }

    public Client(string name, string surname, string fiscalCode, int salary)
    {
        Name = name;
        Surname = surname;
        FiscalCode = fiscalCode;
        Salary = salary;
    }

    public Client()
    {

    }
}