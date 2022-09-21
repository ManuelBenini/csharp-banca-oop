
public class Loan
{
    public int ID { get; set; }
    public Client Client { get; set; }
    public int Total { get; set; }
    public int Installment { get; set; }
    public string LoanStart { get; set; }
    public string LoanEnd { get; set; }

    public Loan(int iD, Client client, int total, int installment, string loanStart, string loanEnd)
    {
        ID = iD;
        Client = client;
        Total = total;
        Installment = installment;
        LoanStart = loanStart;
        LoanEnd = loanEnd;
    }

    public Loan()
    {

    }
}