using System;

namespace JoKenPoLiSp
{
    class Program
    {
        public static Jogo Jogo;

        static void Main(string[] args)
        {
            while (true)
            {
                Jogo = new Jogo();

                Jogo.ImprimeRegras();

                Jogo.RecuperarJogadas();

                Jogo.ImprimeResultado();

                if (!Jogo.JogarNovamente())
                    break;

                Console.Clear();
            }
        }
    }
}
