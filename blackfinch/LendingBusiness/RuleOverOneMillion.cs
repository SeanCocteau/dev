namespace LendingBusiness;

public class RuleOverOneMillion : IRule {

    const decimal minLoan = 100000;
    const decimal maxLoan = 1500000;    

    public ProcessStatus ProcessApplication( Guid applicationId, decimal loan, decimal assetValue, int creditScore ){
        var status = new ProcessStatus();
        // Top level validation
        if( loan < minLoan || loan > maxLoan) return status;

        // Process LTV
        status.LTV = loan / assetValue;

        // Qualify LTV
        if( status.LTV <= 0.6M && creditScore >= 950 ) {
            status.Success = true;
        }

        return status;
    }

}