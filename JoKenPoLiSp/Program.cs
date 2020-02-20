using JoKenPoLiSp.Builders;
using System;

namespace JoKenPoLiSp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Game game = new Game();

                game.EscolherModo();

                game.ExplicarRegras();

                game.ExibirCodigos();

                game.ExecutarJogo();

                game.ExibirVencedor();

                if (!game.JogarNovamente())
                    break;

                Console.Clear();
            }
        }
    }
}
