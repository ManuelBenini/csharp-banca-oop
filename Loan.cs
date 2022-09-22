public class Loan
{
    public static int lastId = 1;
    public int ID { get; set; }
    public Client Client { get; set; }
    public double Total { get; set; }
    public double Installment { get; set; }
    public DateTime LoanStart { get; set; }
    public DateTime LoanEnd { get; set; }

    public Loan(Client client, double total, DateTime loanStart, DateTime loanEnd)
    {
        ID = Loan.lastId++;
        Client = client;
        Total = total;
        Installment = Total / Loan.MonthsDifferenceBetweenDates(LoanEnd, LoanStart); // L'importo della rata è uguale all'importo totale diviso il numero di rate
        LoanStart = loanStart;
        LoanEnd = loanEnd;
    }

    //Metodo che restituisce i mesi di distanza tra due date, servirà ad ottenere il numero di rate del prestito e delle rate rimanenti dalla data attuale
    public static int MonthsDifferenceBetweenDates(DateTime dateEnd, DateTime dateStart)
    {
        int months;

        return months = ((dateEnd.Year - dateStart.Year) * 12) + (dateEnd.Month - dateStart.Month);

    }
}