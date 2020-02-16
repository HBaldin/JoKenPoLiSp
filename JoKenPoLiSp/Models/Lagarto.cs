using System;

namespace JoKenPoLiSp
{
    class Lagarto : Personagem
    {
        public override Type[] TiposQueVence =>
            new Type[] { typeof(Spock), typeof(Papel) };
    }
}
