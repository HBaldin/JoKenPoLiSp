using System;

namespace JoKenPoLiSp
{
    class PersonagemBuilder
    {
        public Personagem BuildPersonagem(int i)
        {
            switch (i)
            {
                case 1:
                    return new Pedra();
                case 2:
                    return new Papel();
                case 3:
                    return new Tesoura();
                case 4:
                    return new Lagarto();
                case 5:
                    return new Spock();
                default:
                    throw new Exception("Personagem não identificado");
            }
        }
    }
}
