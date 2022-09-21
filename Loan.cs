
public class Loan
{
    private int lastId = 0;
    public int ID { get; set; }
    public Client Client { get; set; }
    public int Total { get; set; }
    public int Installment { get; set; }
    public DateTime LoanStart { get; set; }
    public DateTime LoanEnd { get; set; }

    public Loan(Client client, int total, DateTime loanStart, DateTime loanEnd)
    {
        lastId = ID;
        ID = lastId++;
        Client = client;
        Total = total;
        Installment = Total / new Bank().InstallmentLeftToPay(loanStart, loanEnd);
        LoanStart = loanStart;
        LoanEnd = loanEnd;
    }

    public Loan()
    {

    }

    
}