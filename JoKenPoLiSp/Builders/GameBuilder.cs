﻿using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp.Builders
{
    class GameBuilder
    {
        public Game BuildGame(ConsoleKeyInfo consoleKeyInfo)
        {
            if (!IsValidKey(consoleKeyInfo))
                throw new ArgumentException("Valor inválido");

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
