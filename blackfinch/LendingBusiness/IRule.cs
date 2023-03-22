namespace LendingBusiness;
public interface IRule
{
    public ProcessStatus ProcessApplication( Guid applicationId, decimal loan, decimal assetValue, int creditScore );

}

// Simple class for processing status
public class ProcessStatus {

    public decimal LTV {get;set;}
    public bool Success {get;set;}

    public ProcessStatus(){
        Success = false;
    }

}
