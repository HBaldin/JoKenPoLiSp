using System;

namespace JoKenPoLiSp
{
    class Tesoura : Personagem
    {
        public override Type[] TiposQueVence =>
            new Type[] { typeof(Papel), typeof(Lagarto) };
    }
}
