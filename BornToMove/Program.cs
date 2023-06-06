// See https://aka.ms/new-console-template for more information
using BornToMove;

MoveSuggestion moveSuggestion = new MoveSuggestion();

Move move;
DisplayMove displayMove = new DisplayMove();

Console.WriteLine("Time to move! \n Do you want me to suggest a move? \n (yes/y or no/n to select your self)");

string? answere = Console.ReadLine();

switch(answere)
{
    case "yes":
    case "y":
        move =  moveSuggestion.suggest();
        displayMove.show(move);
        break;
    case "no": 
    case "n":
        Console.WriteLine("no"); 
    break;
}
