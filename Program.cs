
using System.Linq.Expressions;

Console.WriteLine("Benvenuto/a! Inserire il nome della banca: ");
Bank bank = new Bank(Console.ReadLine());

Menu:
Console.WriteLine($"Bentornato alla banca {bank.Name}, Si desidera: " +
    "Cercare un cliente(0), Aggiungere un cliente(1), ottenere informazioni sui prestiti(2), Visualizzare ogni cliente ed i suoi prestiti(3)");

switch (Convert.ToInt32(Console.ReadLine()) )
{
    #region Ricerca cliente
    case 0:
        SearchingClient:
        Console.WriteLine("Inserire nome utente: ");
        string clientName = Console.ReadLine();

        Console.WriteLine("Inserire cognome utente: ");
        string clientSurname = Console.ReadLine();
        Client foundedClient = bank.SearchClient(clientName, clientSurname);
        
        Console.WriteLine($"Ecco i dati riepilogativi del cliente {foundedClient.Name} {foundedClient.Surname}:");

        Console.WriteLine($"Codice fiscale: {foundedClient.FiscalCode}");
        Console.WriteLine($"Salario: {foundedClient.Salary}");

        Console.WriteLine($"Modificare i dati del cliente(0), Ottenere i dettagli dei suoi prestiti(1), Tornare al menù(2)");

        switch (Convert.ToInt32(Console.ReadLine()))
        {
            #region Modifica cliente
            case 0:
                bool isChangesAccepted = false;
                Client modifiedClient = new Client();
                do
                {
                    Console.WriteLine("Inserire nuovo nome: ");
                    string newClientName = Console.ReadLine();

                    Console.WriteLine("Inserire nuovo cognome: ");
                    string newClientSurname = Console.ReadLine();

                    Console.WriteLine("Inserire nuovo codice fiscale: ");
                    string newClientFiscalCode = Console.ReadLine();

                    Console.WriteLine("Inserire nuovo salario: ");
                    int newClientSalary = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ecco i nuovi dati inseriti:");

                    Console.WriteLine($"Nome: {newClientName}");
                    Console.WriteLine($"Cognome: {newClientSurname}");
                    Console.WriteLine($"Codice fiscale: {newClientFiscalCode}");
                    Console.WriteLine($"Salario: {newClientSalary}");

                    Console.WriteLine("Conferma le modifiche? Si(1) No(0)");
                    switch (Convert.ToInt32(Console.ReadLine()))
                    {
                        case 1:
                            isChangesAccepted = true;
                            modifiedClient = new Client(newClientName, newClientSurname, newClientFiscalCode, newClientSalary);
                            break;
                        default:
                            isChangesAccepted = false;
                            break;
                    }
                } while (!isChangesAccepted);

                bank.ModifyClient(foundedClient, modifiedClient);

                goto SearchingClient;
            #endregion

            #region Dettagli prestiti cliente
            case 1:

            goto AddLoan;
                
            #endregion

            #region Ritorno al menù
            default:
                goto Menu;
            #endregion
        }
    #endregion

    #region Aggiungere cliente

    case 1:
        AddClient:
        bool isAccountAccepted = false;
        Client newClient = new Client();
        do
        {
            Console.WriteLine("Inserire nome: ");
            string ClientName = Console.ReadLine();

            Console.WriteLine("Inserire cognome: ");
            string ClientSurname = Console.ReadLine();

            Console.WriteLine("Inserire codice fiscale: ");
            string ClientFiscalCode = Console.ReadLine();

            Console.WriteLine("Inserire salario: ");
            int ClientSalary = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Ecco i dati inseriti:");

            Console.WriteLine($"Nome: {ClientName}");
            Console.WriteLine($"Cognome: {ClientSurname}");
            Console.WriteLine($"Codice fiscale: {ClientFiscalCode}");
            Console.WriteLine($"Salario: {ClientSalary}");

            Console.WriteLine("Crea cliente? Si(1) No(0)");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    isAccountAccepted = true;
                    newClient = new Client(ClientName, ClientSurname, ClientFiscalCode, ClientSalary);
                    break;
                default:
                    isAccountAccepted = false;
                    break;
            }
        } while (!isAccountAccepted);

        bank.ClientPush(newClient);

        goto SearchingClient;
    #endregion

    #region Aggiungere prestito
    case 2:
        AddLoan:
        Console.WriteLine("Inserire codice fiscale utente: ");

        Client addLoanfoundedClient = bank.SearchClientByFiscalCode(Console.ReadLine());

        List<Loan> userLoans = bank.GetLoansOfUser(addLoanfoundedClient.FiscalCode);

        if (userLoans != null)
        {
            Console.WriteLine($"Prestiti totali del cliente: {userLoans.Count}");

            Console.WriteLine($"Ammontare totale dei prestiti del cliente: {bank.TotalToPay(userLoans)}");

            Console.WriteLine($"Numero totale di rate ancora da pagare: {bank.TotalInstallmentLeftToPay(userLoans)}");

            Console.WriteLine($"Tutti i prestiti nei dettagli: ");

            foreach (Loan loan in userLoans)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine($"ID: {loan.ID}");
                Console.WriteLine($"Totale: {loan.Total}");
                Console.WriteLine($"Prezzo rata: {loan.Installment}");
                Console.WriteLine($"Data inizio: {loan.LoanStart}");
                Console.WriteLine($"Data fine: {loan.LoanEnd}");
            }

            Console.WriteLine("Aggiungere un prestito(0), tornare al menù(1), profilo utente(2)");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    LoanPush(addLoanfoundedClient);
                    goto AddLoan;

                case 1:
                    goto Menu;
                default:
                    goto SearchingClient;
            }
        }
        else
        {
            Console.WriteLine("Il cliente non ha nessun prestito.");

            Console.WriteLine("Aggiungere un prestito(0), tornare al menù(1)");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 0:
                    LoanPush(addLoanfoundedClient);
                    goto AddLoan;

                default:
                    goto Menu;
            }
        }
    #endregion

    default:
        foreach (Client client in bank.Clients)
        {
            Console.Write(String.Format("|{0,5}|", "cliente"));
            foreach (Loan loan in bank.Loans)
            {
                if(loan.Client == client)
                {
                    Console.Write(String.Format("|{0,5}|", "Prestiti"));
                }
                Console.WriteLine("=========");
            }
        }
       
       
       break;
}


void LoanPush(Client foundedClient)
{
    Console.WriteLine("Inserire ammontare totale: ");
    int totalLoan = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Inserire data inizio: ");
    DateTime loanStart = Convert.ToDateTime(Console.ReadLine());

    Console.WriteLine("Inserire data fine: ");
    DateTime loanEnd = Convert.ToDateTime(Console.ReadLine());

    bank.LoansPush(new Loan(foundedClient, totalLoan, loanStart, loanEnd));
}
