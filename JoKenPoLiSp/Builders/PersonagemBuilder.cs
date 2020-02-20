using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp
{
    class PersonagemBuilder
    {
        public Personagem BuildPersonagem(ConsoleKeyInfo consoleKeyInfo)
        {
            if (!IsValidKey(consoleKeyInfo))
                throw new ArgumentException("Personagem não identificado");

            int i = int.Parse(consoleKeyInfo.KeyChar.ToString());
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
                    throw new ArgumentException("Personagem não identificado");
            }
        }

        public bool IsValidKey(ConsoleKeyInfo consoleKeyInfo)
        {
            Regex regex = new Regex("[1,2,3,4,5]");
            return regex.IsMatch(consoleKeyInfo.Key.ToString());
        }
    }
}
