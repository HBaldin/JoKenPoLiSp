using JoKenPoLiSp.Builders;
using System;

namespace JoKenPoLiSp
{
    class Program
    {
        public static GameBuilder GameBuilder = new GameBuilder();
        public static Game Jogo;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Jo-Ken-Po-Li-Sp -- Pedra-Papel-Tesoura-Lagarto-Spock");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine("* MODOS DE JOGO ");
                Console.WriteLine("1 = Versus (1v1)");
                Console.WriteLine("2 = DeathMatch (NvN)");
                Console.WriteLine();

                EscolherModo();

                Jogo.ImprimeRegras();

                Jogo.ImprimeCodigos();

                Jogo.RecuperarJogadas();

                Jogo.ProcessarJogadas();

                Jogo.ImprimeResultado();

                if (!Jogo.JogarNovamente())
                    break;

                Console.Clear();
            }
        }

        private static void EscolherModo()
        {
            while (true)
            {
                try
                {
                    Console.Write("Modo de jogo: ");
                    Jogo = GameBuilder.BuildGame(Console.ReadKey());
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine();
                    Console.WriteLine("* MODO INVÁLIDO *");
                }
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
