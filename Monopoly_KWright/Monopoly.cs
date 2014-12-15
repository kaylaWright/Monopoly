using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Input")]

namespace Monopoly_KWright
{

    class Monopoly
    {
        private Random rnd = new Random();
        private Input input = new Input();

        //objects needed for the game at large.
        internal static List<string> m_availablePieces = new List<string>() { "Battleship", "Automobile", "Top Hat", "Thimble", "Wheelbarrow" };
        internal static List<Player> m_players = new List<Player>();

        internal static int m_numPlayers;
        internal static int m_turnCount;

        internal int m_turnNumber;
       
        //exit bools.
        internal static bool m_quit;
        internal bool m_gameOver;

        public Monopoly()
        {
            ResetGame();
            SetUpGame();

            PlayGame();
        }

        //determines the number of players, as well as their names and their chosen piece. 
        private void SetUpGame()
        {
            System.Console.WriteLine("Welcome to Monopoly~! Uguuu...\n");
            System.Console.WriteLine("How many kawaii players today? (1-4 players) <33  \n");

            while (!input.GetNumPlayers(System.Console.ReadLine()))
            {
                Console.Clear();
                System.Console.WriteLine("Please enter a number between one (1) and four (4).\n");
            }

            for (int i = 1; i <= m_numPlayers; i++)
            {
                Console.Clear();

                System.Console.WriteLine("All right, player " + i.ToString() + ".\nWhat token would you like to play as?\n");
                System.Console.WriteLine("Your options are... ");
                for (int j = 0; j < m_availablePieces.Count; j++)
                {
                    System.Console.WriteLine(m_availablePieces[j]);
                }
                System.Console.WriteLine("\n");


                while (!input.ChooseToken(System.Console.ReadLine()))
                {
                    System.Console.WriteLine("\nPlease enter a valid token.\n");
                }
                
            }

            Console.Clear();
            RandomizeTurnOrder();
            System.Console.WriteLine("All right!\nSo the randomized turn order is...\n");
            foreach (Player _p in m_players)
            {
                System.Console.WriteLine(_p.GetType());
            }

            Console.ReadLine();
        }

        private void PlayGame()
        {
            while (m_quit == false || m_gameOver == false)
            {
                CheckEnd();

                Console.Clear();
                //total turn counter.
                m_turnNumber++;
                //lets players know which turn it is before
                
                //when all players have gone, revert back to player one's turn.
                m_turnCount++;
                if (m_turnCount >= m_numPlayers)
                {
                    m_turnCount = 0;
                }

                TakeATurn();
            }


        }

        private void CheckEnd()
        {
             if (m_quit == true)
            {
                Console.WriteLine("Adios!\nPress any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
                return;
            }

            if (m_gameOver == true)
            {
                EndGame();
                return;
            }
        }               

        private void TakeATurn()
        {
            Console.WriteLine("\nCurrent Turn: " + m_turnNumber.ToString());
            Console.WriteLine("\nTime for the " + m_players[m_turnCount].GetType() + " to play!\nWhat action would you like to take?\nYou can (R)oll or (Q)uit.");
            while(!input.TakeTurn(Console.ReadLine()))
            {
                Console.WriteLine("Please make a valid decision.");
            }

            CheckEnd();

            Console.WriteLine("\nEnd Turn.\nPress any key to continue.");
            Console.ReadKey();
        }

        private void EndGame()
        {
            Console.WriteLine("Game Over... let's see who won!");
        }

        //reverts all variables to pre-game; will require reloading the SetUpGame function.
        private void ResetGame()
        {
            string[] pieces = {  "Battleship", "Automobile", "Top Hat", "Thimble", "Wheelbarrow"};
            m_availablePieces.Clear();
            m_availablePieces.AddRange(pieces);

            m_players.Clear();

            m_numPlayers = 0;
            m_turnNumber = 0;
            m_gameOver = false;
        }

        //generates two random numbers, displays them, then adds them together and returns the value.
        //reflects how the players move
        //->might be better to return a bool re: if it's doubles? 

        private void RandomizeTurnOrder()
        {
            if (m_numPlayers == 1)
                return;

            Random rng = new Random();
            int n = m_players.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Player tmp = m_players[k];
                m_players[k] = m_players[n];
                m_players[n] = tmp;
            }  
        }
    }
}
