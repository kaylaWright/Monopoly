using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_KWright
{
    public class Player
    {
        //private string m_playerName;
        public int m_turnOrder;

        public int m_money;
        public int m_position;

        private Random rnd;

        public Player()
        {
            rnd = new Random();

            m_money = 1500;
            m_position = 0;
        }
        
        ~Player()
        { }

        public void Move(int _movement)
        {
            DerMove(_movement);

            m_position += _movement;
            if (m_position > 40)
            {
                m_position -= 40;
            }
            System.Console.WriteLine("Your new position is at... " + m_position.ToString());
        }

        public virtual void DerMove(int _movement)
        { }

        new virtual public string GetType()
        { return "PROGRAMMER DUN FUCKED UP."; }

        public int RollDice()
        {
            int temp = rnd.Next(1, 7);
            int temp2 = rnd.Next(1, 7);

            System.Console.WriteLine("\nYou rolled... " + temp.ToString() + " and " + temp2.ToString() + ".");

            return temp + temp2;
        }
        //public void SetName(string _name)
        //{ m_playerName = _name; }
        //public string GetName()
        //{ return m_playerName; }
    }

    public class Battleship : Player
    {
        public Battleship() : base()
        { }

        override public void DerMove(int _movement)
        {
            Console.WriteLine("Splish splash, you're takin' a move... You advance: " + _movement.ToString() + " spaces." );
            
        }

        override public string GetType()
        { return "Battleship"; }
    }

    public class Thimble : Player
    {
        public Thimble() : base()
        { }

        override public void DerMove(int _movement)
        {
            Console.WriteLine("You, as a thimble, advance: " + _movement.ToString() + " spaces.");
        }

        override public string GetType()
        { return "Thimble"; }
    }

    public class Wheelbarrow : Player
    {
        public Wheelbarrow() : base()
        { }

        override public void DerMove(int _movement)
        {
            Console.WriteLine("They see you rollin', they hatin'... You advance: " + _movement.ToString() + " spaces.");
        }

        override public string GetType()
        { return "Wheelbarrow"; }
    }

    public class TopHat : Player
    {
        public TopHat() : base()
        { }

        override public void DerMove(int _movement)
        {
            Console.WriteLine("Hat's off (and on the road!)... You advance: " + _movement.ToString() + " spaces.");
        }

        override public string GetType()
        { return "Top Hat"; }
    }

    public class Automobile : Player
    {
        public Automobile() : base()
        { }

        override public void DerMove(int _movement)
        {
            Console.WriteLine("Zoom zoom... You advance: " + _movement.ToString() + " spaces.");
        }

        override public string GetType()
        { return "Automobile"; }
    }
}
