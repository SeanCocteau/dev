Console.WriteLine("Let's go girls!"); 

do {

} while(!instructionsLoop());


bool instructionsLoop(){
    Console.WriteLine("Option 1 - Press 1");
    Console.WriteLine("Option 2 - Press 2");
    Console.WriteLine("Exit - Press x");

    var input = Console.ReadLine();

    switch(input){
        case "1":
            Console.WriteLine("You selected Awesome!");
            entryLoop();
            return false;
        case "2":
            Console.WriteLine("You selected Royal!");
            return false;
        case "x":
            Console.WriteLine("You're out of here'!");
            return true;
    }

    return true;
};

void entryLoop(){
    Console.WriteLine("Enter some data");
    Console.Write("What's your age? ");
    
    var age = Console.ReadLine();
    int ageValidated = 0;

    Console.WriteLine();

    int.TryParse( age, out ageValidated);

    Console.WriteLine("You told me your age was {0}", ageValidated);

}