
public class Bank
{
    public string Name { get; set; }
    public List<Client> Clients { get; set; }
    public List<Loan> Loans { get; set; }

    public Bank(string name)
    {
        Name = name;
        Clients = new List<Client>();
        Loans = new List<Loan>();
    }
    public Bank()
    {

    }


    #region Client methods

    public void ClientPush(Client client)
    {
        Clients.Add(client);
    }

    public void ModifyClient(Client clientToModify, Client modifiedClient)
    {
        int indexofClient = 0;
        foreach (Client client in Clients)
        {
            if (client == clientToModify)
            {
                indexofClient = Clients.IndexOf(client);
            }
        }

        Clients[indexofClient] = modifiedClient;
    }

    public Client SearchClient(string name, string surname)
    {
        foreach (Client client in Clients)
        {
            if (client.Name == name && client.Surname == surname)
            {
                return client;
            }
        }
        return null;
    }

    public Client SearchClientByFiscalCode(string fiscalCode)
    {
        foreach (Client client in Clients)
        {
            if (client.FiscalCode == fiscalCode)
            {
                return client;
            }
        }
        return null;
    }

    #endregion

    #region Loan methods

    public List<Loan> GetLoansOfUser(string fiscalCode)
    {
        List<Loan> userLoans = new List<Loan>();
        foreach(Loan loan in Loans)
        {
            if (loan.Client.FiscalCode == fiscalCode)
            {
                userLoans.Add(loan);
            }
        }
        return userLoans;
    }

    public void LoansPush(Loan newloan)
    {
        Loans.Add(newloan);
    }

    public int TotalInstallmentLeftToPay(List<Loan> userLoan)
    {
        int installmentLeftToPay = 0;
        foreach (Loan loan in userLoan)
        {
            installmentLeftToPay = installmentLeftToPay + ((loan.LoanEnd.Year - loan.LoanStart.Year) * 12) + loan.LoanEnd.Month - loan.LoanStart.Month;
        }
        return installmentLeftToPay;
    }
    public int InstallmentLeftToPay(DateTime LoanStart, DateTime LoanEnd)
    {
        int installmentLeftToPay = 0;
        installmentLeftToPay = installmentLeftToPay + ((LoanEnd.Year - LoanStart.Year) * 12) + LoanEnd.Month - LoanStart.Month;
        return installmentLeftToPay;
    }

    public int TotalToPay(List<Loan> userLoan)
    {
        int loanSum = 0;
        foreach (Loan loan in userLoan)
        {
            loanSum += loan.Total;
        }
        return loanSum;
    }

    #endregion
}