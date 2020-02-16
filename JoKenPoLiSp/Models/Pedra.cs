using System;

namespace JoKenPoLiSp
{
    class Pedra : Personagem
    {
        public override Type[] TiposQueVence =>
            new Type[] { typeof(Tesoura), typeof(Lagarto) };
    }
}
