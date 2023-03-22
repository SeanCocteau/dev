namespace LendingBusiness;

public class RuleProcessor{

    Reporter Reporter;
    IList<IRule> rules;

    public RuleProcessor(Reporter reporter){
        Reporter = reporter;

        // Generate known rules (typically this would come from a factory)
        rules = new List<IRule>();

        rules.Add( new RuleOverOneMillion() );
        rules.Add( new RuleUnderOneMillion() );
    }

    public bool ProcessApplication(decimal loan, decimal asset, int creditScore){
        var applicationID = Guid.NewGuid();
        var reportItem = new ReportItem(applicationID,loan,asset,creditScore,false,0);
        var acceptApplication = false;

        // Add to the reporter
        Reporter.RecordItem(reportItem);

        // Loop through the rules
        foreach ( var rule in rules ){
            var result = rule.ProcessApplication(applicationID, loan, asset, creditScore);
            reportItem.LTV = result.LTV; // Just record

            if(result.Success){
                reportItem.Success = result.Success;
                acceptApplication = true;
                break;
            }
        }
        return acceptApplication;
    }   

}