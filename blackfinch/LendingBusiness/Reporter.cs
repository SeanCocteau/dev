namespace LendingBusiness;

using System.Text;

public class Reporter{

    // Slight laziness but helps with unit tests
    public IList<ReportItem> items;

    public Reporter(){
        items = new List<ReportItem>();
    }
    
    public void RecordItem(ReportItem item){
        items.Add(item);
    }

    public string ShowReport(){
        var sb = new StringBuilder();

        sb.Append("Applicants Report");
        sb.Append(Environment.NewLine);
        sb.Append("=================");
        sb.Append(Environment.NewLine);
        sb.Append("Total number of Applicants: ");
        sb.Append(this.TotalNumberOfApplicants());
        sb.Append(Environment.NewLine);
        sb.Append("Total number of Successful Applicants: ");
        sb.Append(this.TotalNumberOfSuccessfulApplicants());
        sb.Append(Environment.NewLine);
        sb.Append("Total number of Failed Applicants: ");
        sb.Append(this.TotalNumberOfFailedApplicants());

        sb.Append(Environment.NewLine);
        sb.Append("Written Loans Total: ");
        sb.Append(this.TotalValueOfWrittenLoans().ToString("£#,#"));
        sb.Append(Environment.NewLine);
        sb.Append("Average LTV of all applicants: ");
        sb.Append(this.AverageLtvOfAll().ToString("##%"));
        sb.Append(Environment.NewLine);
        sb.Append("=================") ;
        sb.Append(Environment.NewLine);
        return sb.ToString();
    }

    // Added the below for easier testing

    public int TotalNumberOfApplicants(){
        return items.Count();
    }

    public int TotalNumberOfSuccessfulApplicants(){
        return items.Where(x => x.Success).Count();
    }

    public int TotalNumberOfFailedApplicants(){
        return items.Where(x => !x.Success).Count();
    }

    public decimal TotalValueOfWrittenLoans(){
        return items.Where(x => x.Success).Sum(x => x.Loan);
    }

    public decimal AverageLtvOfAll(){
        return items.Count() != 0 ? items.Average(x => x.LTV) : 0;
    }

}

public class ReportItem{

    public ReportItem(){

    }

    public ReportItem(Guid applicationId, decimal loan, decimal asset, int creditScore, bool success, decimal ltv){
        ApplicationID = applicationId;
        Loan = loan;
        Asset = asset;
        CreditScore = creditScore;
        Success = success;
        LTV = ltv;
    }

    public Guid ApplicationID {get;set;}
    public decimal Loan {get;set;}
    public decimal Asset {get;set;}
    public int CreditScore {get;set;}
    public bool Success {get;set;}
    public decimal LTV {get;set;}

}