Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Benvenuto/a! Inserire il nome della banca: ");
Bank bank = new Bank(Console.ReadLine());

#region Menù principale
Menu:
Console.WriteLine($"Bentornato/a nella banca {bank.Name}! Azioni:");
Console.WriteLine("1. Cerca Utente");
Console.WriteLine("2. Aggiungi Utente");
Console.WriteLine("3. Cerca Prestito");
Console.WriteLine("4. Aggiungi Prestito");
Console.WriteLine("5. Lista di tutti gli utenti");
#endregion

Client foundedClient = new Client();
switch (Convert.ToInt32(Console.ReadLine()))
{
    
	case 1:
    #region Ricerca utente
    ClientSearch:
        Console.WriteLine("Inserisci codice fiscale utente");
        Client.FoundedFiscalCode = Console.ReadLine();

        foundedClient = bank.GetClient(Client.FoundedFiscalCode);

        if(foundedClient != null)
        {
            bank.Print(foundedClient);
        }
        else
        {
            Console.WriteLine("Nessun cliente trovato. Torna al Menù(1) Effettua una nuova ricerca(2)");

            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    goto Menu;
                default:
                    goto ClientSearch;
            }
        }

        
        ClientAction:
        Console.WriteLine("Azioni:");
        Console.WriteLine("1. Modifica utente");
        Console.WriteLine("2. Vedi prestiti utente");
        Console.WriteLine("3. Aggiungi prestito");
        Console.WriteLine("4. Torna al menù");

        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                #region Modifica utente
                Console.WriteLine(Client.FoundedFiscalCode);
                foundedClient = bank.GetClient(Client.FoundedFiscalCode);
                Client modifiedClient = bank.ClientFiller();
                bank.ModifyClient(foundedClient, modifiedClient);
                Client.FoundedFiscalCode = modifiedClient.FiscalCode;
                goto ClientAction;
                #endregion
            case 2:
                #region Vedi prestiti utente
                foundedClient = bank.GetClient(Client.FoundedFiscalCode);
                List<Loan> searchedClientLoans = bank.GetClientLoans(foundedClient.FiscalCode);

                bank.Print(searchedClientLoans);

                Console.WriteLine("1. Aggiungi prestito");
                Console.WriteLine("2. Torna al menù");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        foundedClient = bank.GetClient(Client.FoundedFiscalCode);
                        Loan newLoan = bank.LoanFiller(foundedClient);
                        bank.LoanAdd(newLoan);
                        goto loanOptions;
                    default:
                        goto Menu;
                }
            #endregion
            case 3:
                #region Aggiungi prestito
                foundedClient = bank.GetClient(Client.FoundedFiscalCode);
                Loan newLoanToClient = bank.LoanFiller(foundedClient);
                bank.LoanAdd(newLoanToClient);
                goto loanOptions;
                #endregion
            default:
                #region Torna al menù
                goto Menu;
                #endregion
        }
    #endregion

    case 2:
    #region Aggiungi utente
        Client newClient = bank.ClientFiller();

        bank.ClientAdd(newClient);

        Client.FoundedFiscalCode = newClient.FiscalCode;

        bank.Print(newClient);

        goto ClientAction;
    #endregion

    case 3:
    #region Cerca prestito
        Console.WriteLine("Inserisci codice fiscale utente");

        foundedClient = bank.GetClient(Console.ReadLine());

        List <Loan> clientLoans = bank.GetClientLoans(foundedClient.FiscalCode);

        bank.Print(clientLoans);

        loanOptions:
        Console.WriteLine("1. Aggiungi prestito:");
        Console.WriteLine("2. Torna al menù");

        switch (Convert.ToInt32(Console.ReadLine()))
        {
            case 1:
                #region Aggiungi prestito
                Loan newLoan = bank.LoanFiller(foundedClient);
                bank.LoanAdd(newLoan);
                goto loanOptions;
                #endregion
            default:
                #region Torna al menù
                goto Menu;
                #endregion
        }
    #endregion

    case 4:
    #region Aggiungi prestito
        Console.WriteLine("Inserisci codice fiscale utente");

        foundedClient = bank.GetClient(Console.ReadLine());

        Loan LoanToClient = bank.LoanFiller(foundedClient);

        bank.LoanAdd(LoanToClient);

        goto loanOptions;
    #endregion

    default:
    #region Visualizza tutti i clienti
        if(bank.Clients.Count != 0)
        {
            Console.WriteLine();
            Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|", "Nome", "Cognome", "Codice Fiscale", "Stipendio"));
            Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|", "", "", "", " "));

            foreach (Client client in bank.Clients)
            {
                Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|", client.Name, client.Surname, client.FiscalCode, client.Salary));

                Console.WriteLine(String.Format("|{0,15}|{1,15}|{2,15}|{3,15}|", "", "", "", " "));
            }
        }
        else
        {
            Console.WriteLine("Questa banca non ha clienti.");
        }
        Console.WriteLine();
        goto Menu;
        #endregion
}
