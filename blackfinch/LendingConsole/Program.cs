// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to the Lending System!");

// Grab top-level reporter
var reporter = new LendingBusiness.Reporter();

// Program loop
do {

} while(!instructionsLoop());


bool instructionsLoop(){
    Console.WriteLine();
    Console.WriteLine("Enter an applicant - Press 1");
    Console.WriteLine("Show Report - Press 2");
    Console.WriteLine("Exit - Press x");
    Console.WriteLine();

    var input = Console.ReadLine();

    switch(input){
        case "1":
            applicantLoop();
            return false;
        case "2":
            Console.WriteLine(reporter.ShowReport());
            return false;
        case "x":
            Console.WriteLine("Bye friend!");
            return true;
    }

    return true;
};

void applicantLoop(){
    Console.WriteLine("Applicant entry");
    Console.WriteLine("=================") ;

    Console.Write("Total loan size? ");
    var loan = Console.ReadLine();
    decimal loanValidated = 0;
    Console.WriteLine();

    Console.Write("Total asset size? ");
    var asset = Console.ReadLine();
    decimal assetValidated = 0;
    Console.WriteLine();

    Console.Write("Credit score rating (1 to 999)? ");
    var cs = Console.ReadLine();
    int csValidated = 0;
    Console.WriteLine();

    // Quick validate
    decimal.TryParse( loan, out loanValidated);
    decimal.TryParse( asset, out assetValidated);
    int.TryParse( cs, out csValidated);

    // Spin up the Rule Engine
    var ruleProcessor = new LendingBusiness.RuleProcessor(reporter);
    var result = ruleProcessor.ProcessApplication(loanValidated, assetValidated,csValidated);

    Console.WriteLine(
        "Your application for {0} secured against {1} has {2} ", 
        loanValidated.ToString("£#,#"), 
        assetValidated.ToString("£#,#"),
        result ? "been Successful" : "Failed");
    Console.WriteLine();
}
