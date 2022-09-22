public class Client
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string FiscalCode { get; set; }
    static public string? FoundedFiscalCode { get; set; }
    public double Salary { get; set; }

    public Client(string name, string surname, string fiscalCode, double salary)
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