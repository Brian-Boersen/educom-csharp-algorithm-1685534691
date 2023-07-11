// See https://aka.ms/new-console-template for more information
using BornToMove;
using System;

using BornToMove.DAL;

public class Program
{
    public static void Main(string[] args)
    {
        MoveSuggestion moveSuggestion = new MoveSuggestion();
        ChooseFromList chooseFromList = new ChooseFromList();

        Move move = new Move();
        DisplayMove displayMove = new DisplayMove();

        Ratings rating = new Ratings();

        bool run = true;

        while (run == true)
        {
            if(ConsoleInput.AskYesNo("Time to move! \n Do you want me to suggest a move? \n (yes/y or no/n to select your self)"))
            {
                move = moveSuggestion.suggest();
            }
            else
            {
                move = chooseFromList.go();
            }

            displayMove.show(move);
            rating.rate(move);

            if(!(ConsoleInput.AskYesNo("Do you want to do another exersise? y/n")))
            {
                run = false;
            }
        }
    }
}