
using System.Linq.Expressions;

Console.WriteLine("Benvenuto/a! Inserire il nome della banca: ");
Bank bank = new Bank(Console.ReadLine());

Console.WriteLine($"Bentornato alla banca {bank.Name}, Si desidera: " +
    "Cercare un cliente(0), Aggiungere un cliente(1), Aggiungere un prestito(2), " +
    "Ottenere informazioni sui prestiti di un cliente(3), Visualizzare ogni cliente ed i suoi prestiti(4)");

switch (Convert.ToInt32(Console.ReadLine()) )
{
    case 0:
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
            #region Modifica cliente esistente
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
                #endregion

                break;
            case 1:
                // code block
                break;
            default:
                // code block
                break;
        }
    case 1:
        // code block
        break;
    case 2:
        // code block
        break;
    case 3:
        // code block
        break;
    default:
        // code block
        break;
}










Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", 5, 2, 3, 4)); 
Console.WriteLine(String.Format("|{0,5}|{1,5}|{2,5}|{3,5}|", 1, 2, 3, 4)); 
