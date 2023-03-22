namespace LendingBusiness;

public class RuleUnderOneMillion : IRule {

    const decimal minLoan = 100000;
    const decimal maxLoan = 1000000;    

    public ProcessStatus ProcessApplication( Guid applicationId, decimal loan, decimal assetValue, int creditScore ){
        var status = new ProcessStatus();
        // Top level validation
        if( loan < minLoan || loan > maxLoan) return status;

        // Process LTV
        status.LTV = loan / assetValue;

        // Qualify LTV and credit score
        if( status.LTV < 0.6M && creditScore >= 750 ) {
            status.Success = true;
        }

        if( status.LTV < 0.8M && creditScore >= 800 ) {
            status.Success = true;
        }

        if( status.LTV < 0.9M && creditScore >= 900 ) {
            status.Success = true;
        }

        return status;
    }

}