using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly_KWright
{
    class Board
    {
       public BoardSpace[] m_spaces;
    }

    class BoardSpace
    {
        string m_name;
        int m_position;

        public BoardSpace()
        { }

        protected virtual void LandedOn()
        { } 
    }

    class Property : BoardSpace
    {
        //identifiers.
        string m_type;

        int m_cost;
        int m_house1Cost;
        int m_house2Cost;
        int m_house3Cost;
        int m_hotelCost;

        int m_mortgageCost;

        bool m_isAvailable;
        string m_owner;
    }

    class Card : BoardSpace
    {

    }

    class Tax : BoardSpace
    {

    }

    class Special : BoardSpace
    {

    }
}
