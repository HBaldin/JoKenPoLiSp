using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp.Builders
{
    class GameEngineBuilder
    {
        public IGameEngine BuildGameEngine(ConsoleKeyInfo consoleKeyInfo)
        {
            if (!IsValidKey(consoleKeyInfo))
                throw new ArgumentException("Argumento inválido");

            int i = int.Parse(consoleKeyInfo.KeyChar.ToString());
            switch (i)
            {
                case 1:
                    return new Versus();
                case 2:
                    return new DeathMatch();
                default:
                    throw new ArgumentException("Valor inválido");
            }
        }

        public bool IsValidKey(ConsoleKeyInfo consoleKeyInfo)
        {
            Regex regex = new Regex("[1,2]");
            return regex.IsMatch(consoleKeyInfo.Key.ToString());
        }
    }
}
