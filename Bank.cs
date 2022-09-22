

public class Bank
{
    public string Name { get; set; }
    public List<Client> Clients { get;}
    public List<Loan> Loans { get;}

    public Bank(string name)
    {
        Name = name;
        Clients = new List<Client>();
        Loans = new List<Loan>();
    }

    #region Client Methods
    public void ClientAdd(Client client)
    {
        Clients.Add(client);

        Console.WriteLine($"Cliente {client.Name} {client.Surname} creato con successo!");
    }

    //Metodo che restituisce un Cliente con i tutti i campi compilati dall'utente
    public Client ClientFiller()
    {
        Console.WriteLine("Inserire nome:");
        string newClientName = Console.ReadLine();

        Console.WriteLine("Inserire cognome:");
        string newClientSurname = Console.ReadLine();

        Console.WriteLine("Inserire codice fiscale:");
        string newClientFiscalCode = Console.ReadLine();

        Console.WriteLine("Inserire stipendio:");
        double newClientSalary = Convert.ToDouble(Console.ReadLine());

        Client newClient = new Client(newClientName, newClientSurname, newClientFiscalCode, newClientSalary);

        return newClient;
    }

    //Ricerca cliente per corrispondenza codisce fiscale
    public Client GetClient(string fiscalCode)
    {
        foreach (Client client in Clients)
        {
            if (client.FiscalCode.ToLower().Contains(fiscalCode.ToLower()))
            {
                return client;
            }
        }
        return null;
    }

    //Metodo che modifica un cliente preesistente con delle informazioni aggiornate scelte dall'utente
    public void ModifyClient(Client oldClient , Client newClient)
    {
        Console.WriteLine(Clients.Count);
        Clients[Clients.IndexOf(oldClient)] = newClient;

        foreach (Loan loan in Loans)
        {
            if(loan.Client == oldClient)
            {
                loan.Client = newClient;
            }
        }
    }

    //Metodo che stampa in pagina tutti i dati di un cliente
    public void Print(Client client)
    {
        Console.WriteLine($"Nome {client.Name}");
        Console.WriteLine($"Cognome {client.Surname}");
        Console.WriteLine($"Codice Fiscale: {client.FiscalCode}");
        Console.WriteLine($"Stipendio: {client.Salary}");
    }
    #endregion

    #region Loan Methods
    public void LoanAdd(Loan loan)
    {
        Loans.Add(loan);

        Console.WriteLine($"Prestito aggiunto con successo al cliente {loan.Client.Name} {loan.Client.Surname}!");
    }

    //Metodo che restituisce un Prestito con i tutti i campi compilati dall'utente
    public Loan LoanFiller(Client client)
    {
        Console.WriteLine("Inserire totale prestito");
        double loanSum = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Inserire data di sottoscrizione");
        DateTime loanStart = Convert.ToDateTime(Console.ReadLine());

        Console.WriteLine("Inserire data di scadenza del prestito");
        DateTime loanEnd = Convert.ToDateTime(Console.ReadLine());

        Loan loan = new Loan(client, loanSum, loanStart, loanEnd);

        return loan;
    }

    //Metodo che restituisce tutti i prestiti di un utente
    public List<Loan> GetClientLoans(string fiscalCode)
    {
        List<Loan> clientLoans = new List<Loan>();
        foreach (Loan loan in Loans)
        {
            if (loan.Client.FiscalCode == fiscalCode)
            {
                clientLoans.Add(loan);
            }
        }
        return clientLoans;
    }

    //Metodo che restituisce il Totale dei prestiti
    public double GetTotalUserLoans(string fiscalCode)
    {
        double total = 0;
        foreach (Loan loan in Loans)
        {
            if (loan.Client.FiscalCode == fiscalCode)
            {
                total += loan.Total;
            }
        }
        return total;
    }

    //Metodo che stampa in pagina, in forma tabellare, tutti i prestiti di un utente
    public void Print(List<Loan> loans)
    {
        if (loans.Count != 0)
        {
            Console.WriteLine($"Il cliente {loans[0].Client.Name} {loans[0].Client.Surname} ha {loans.Count} prestiti, per un totale di {GetTotalUserLoans(loans[0].Client.FiscalCode)}€  che sono: ");

            Console.WriteLine();
            Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,25}|{5,15}|", "ID", "Importo", "Rata", "rate rimaste", "Data sottoscrizione", "Data scadenza"));
            Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,25}|{5,15}|", "", "", "", " ", " ", " "));

            foreach (Loan loan in loans)
            {
                Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,25}|{5,15}|", loan.ID, loan.Total, Loan.MonthsDifferenceBetweenDates(loan.LoanEnd, loan.LoanStart),
                Loan.MonthsDifferenceBetweenDates(loan.LoanEnd, DateTime.Now), loan.LoanStart.ToShortDateString(), loan.LoanEnd.ToShortDateString()));

                Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|{4,25}|{5,15}|", "", "", "", " ", " ", " "));
            }
        }
        else
        {
            Console.WriteLine("Il cliente non ha prestiti");
        }
    }
    #endregion
}
