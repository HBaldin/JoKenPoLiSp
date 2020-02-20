using JoKenPoLiSp.Builders;
using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp
{
    class Game
    {
        GameEngineBuilder GameEngineBuilder = new GameEngineBuilder();
        IGameEngine GameEngine;

        public Game()
        {
            Console.WriteLine("Jo-Ken-Po-Li-Sp -- Pedra-Papel-Tesoura-Lagarto-Spock");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal void EscolherModo()
        {
            Console.WriteLine("* MODOS DE JOGO ");
            Console.WriteLine("1 = Versus (1v1)");
            Console.WriteLine("2 = DeathMatch (NvN)");
            Console.WriteLine();

            while (true)
            {
                try
                {
                    Console.Write("Modo de jogo: ");
                    var consoleKey = Console.ReadKey();
                    Console.WriteLine();

                    GameEngine = GameEngineBuilder.BuildGameEngine(consoleKey);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("* MODO INVÁLIDO *");
                    Console.WriteLine();
                }
            }
        }

        internal void ExibirCodigos()
        {
            Console.WriteLine("* CÓDIGOS *");
            Console.WriteLine("1 = PEDRA");
            Console.WriteLine("2 = PAPEL");
            Console.WriteLine("3 = TESOURA");
            Console.WriteLine("4 = LAGARTO");
            Console.WriteLine("5 = SPOCK");

            Console.WriteLine();
            Console.WriteLine();
        }

        internal void ExplicarRegras()
        {
            GameEngine.ExplicarRegras();
        }

        internal void ExecutarJogo()
        {
            GameEngine.ExecutarJogo();
        }

        internal void ExibirVencedor()
        {
            GameEngine.ExibirVencedor();
        }

        internal bool JogarNovamente()
        {
            Console.Write("GOSTARIA DE JOGAR NOVAMENTE? (S/N) ");

            return Console.ReadKey().Key.ToString() == "S";
        }
    }
}
