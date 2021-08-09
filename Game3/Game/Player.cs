using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game3
{
    enum Sign
    {
        X,
        O
    }

    class Player
    {
        public Sign Sign
        {
            get { return sign; }
            set { sign = value; }
        }
        Sign sign;

    }
}
