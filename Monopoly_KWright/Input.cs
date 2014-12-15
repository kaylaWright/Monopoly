using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_KWright
{
    class Input
    {
        public Input()
        {  }

        //reads input to determine number of players. 
        //takes in string from ReadLine, parses it and sets the number of players.
        public bool GetNumPlayers(string _input)
        {
            switch (_input)
            {
                case "1":
                    System.Console.WriteLine("This is going to be a one player game.\nSucker.");
                    Monopoly.m_numPlayers = 1;
                    return true;
                    break;
                case "2":
                    System.Console.WriteLine("This is going to be a two player game.\nLet's tango.");
                    Monopoly.m_numPlayers = 2;
                    return true;
                    break;
                case "3":
                    System.Console.WriteLine("This is going to be a three player game.\nIt's a crowd.");
                    Monopoly.m_numPlayers = 3;
                    return true;
                    break;
                case "4":
                    System.Console.WriteLine("This is going to be a four player game.\nGoing on forty.");
                    Monopoly.m_numPlayers = 4;
                    return true;
                    break;
                default:
                    Monopoly.m_numPlayers = 0;
                    return false;
                    break;
            }

            return false;
        }

        //reads user input to determine which token each player wants.
        //handles bad/irrelevant input as well as some deviations in typing. 
        //makes sure players can't take the same token.
        public bool ChooseToken(string _token)
        {
            Player temp;
            string chosentype = "xx";

            switch (_token.ToLower())
            {
                default:
                    return false;
                    break;
                case "wheelbarrow":
                case "barrow":
                    if(Monopoly.m_availablePieces.Contains("Wheelbarrow"))
                    {
                        temp = new Wheelbarrow();
                        chosentype = "Wheelbarrow";
                    }
                    else
                    {
                        System.Console.WriteLine("\nYou've chosen the wheelbarrow... after someone else did.\nPlease try again.");
                        return false;
                    }
                    break;
                case "battleship":
                case "ship":
                case "boat":
                    if(Monopoly.m_availablePieces.Contains("Battleship"))
                    {
                        temp = new Battleship();
                        chosentype = "Battleship";
                    }
                    else
                    {
                        System.Console.WriteLine("\nYou've chosen the battleship... after someone else did.\nPlease try again.");
                        return false;
                    }
                    break;
                case "thimble":
                    if (Monopoly.m_availablePieces.Contains("Thimble"))
                    {
                        temp = new Thimble();
                        chosentype = "Thimble";
                    }
                    else
                    {
                        System.Console.WriteLine("\nYou've chosen the thimble... thimbles are popular?\nPlease try again.");
                        return false;
                    }
                    break;
                case "tophat":
                case "top hat":
                case "hat":
                   if(Monopoly.m_availablePieces.Contains("Top Hat"))
                    {
                        temp = new TopHat();
                        chosentype = "Top Hat";
                      }
                    else
                    {
                        System.Console.WriteLine("\nYou've chosen the fancy hat... after someone else did.\nPlease try again.");
                        return false;
                    }
                    break;
                case "automobile":
                case "auto":
                case "car":
                    if(Monopoly.m_availablePieces.Contains("Automobile"))
                    {
                        temp = new Automobile();
                        chosentype = "Automobile";
                     }
                    else
                    {
                        System.Console.WriteLine("\nYou've chosen the automobile... after someone else did.\nPlease try again.");
                        return false;
                    }
                    break;
            
            
            }

            System.Console.WriteLine("\nYou've chosen the " + chosentype + ".");
            Monopoly.m_availablePieces.Remove(chosentype);
            Monopoly.m_players.Add(temp);
            System.Console.ReadLine();

            return true;
        }

        public bool TakeTurn(string _choice)
        {
            switch (_choice.ToLower())
            {
                default:
                    return false;
                    break;
                case "r":
                    Monopoly.m_players[Monopoly.m_turnCount].Move(Monopoly.m_players[Monopoly.m_turnCount].RollDice());
                    return true;
                    break;
                case "q":
                    Monopoly.m_quit = true;
                    return true;
                    break;
            }

            return false;
        }
    }
}
