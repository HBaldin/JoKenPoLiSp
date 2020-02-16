using System;

namespace JoKenPoLiSp
{
    class Spock : Personagem
    {
        public override Type[] TiposQueVence =>
            new Type[] { typeof(Tesoura), typeof(Pedra) };
    }
}
