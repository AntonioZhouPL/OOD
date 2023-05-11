using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1A_1
{
    public abstract class SideDish
    {
        public abstract string GetName();
    }

    public class Rice:SideDish
    {

        public override string GetName()
        {
            return "Rice";
        }
    }

    public class Beer : SideDish
    {

        public override string GetName()
        {
            return "Beer";
        }
    }
    public class Fries : SideDish
    {

        public override string GetName()
        {
            return "Fries";
        }
    }
}
