using System;

namespace JoKenPoLiSp
{
    class Papel : Personagem
    {
        public override Type[] TiposQueVence =>
            new Type[] { typeof(Pedra), typeof(Spock) };
    }
}
