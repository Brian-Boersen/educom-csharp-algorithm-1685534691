// See https://aka.ms/new-console-template for more information
using BornToMove;

MoveSuggestion moveSuggestion = new MoveSuggestion();
ChooseFromList chooseFromList = new ChooseFromList();

Move move = new Move();
DisplayMove displayMove = new DisplayMove();

Ratings rating = new Ratings();

string? answere;

bool run = true;
bool stepCompleted = false;

while (run == true)
{
    Console.WriteLine("Time to move! \n Do you want me to suggest a move? \n (yes/y or no/n to select your self)");

    answere = Console.ReadLine();

    while (stepCompleted == false)
    {
        switch (answere)
        {
            case "yes":
            case "y":
            case "":
                move = moveSuggestion.suggest();
                stepCompleted = true;
                break;

            case "no":
            case "n":
                move = chooseFromList.go();
                stepCompleted = true;
                break;
        }

        if(stepCompleted == false)
        {
            Console.WriteLine("input not valid, try again");
        }
    }

    stepCompleted = false;

    if(move.Id >= 0)
    {
        displayMove.show(move);
        rating.rate(move);
    }


    Console.WriteLine("do you want to do another exersise? y/n");
    answere = Console.ReadLine();

    switch (answere)
    {
        case "n":
            run = false;
            break;
    }
}
