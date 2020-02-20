using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp
{
    abstract class Game
    {
        protected PersonagemBuilder Builder = new PersonagemBuilder();
        string ResultadoFinal;

        public abstract void ImprimeRegras();

        public void ImprimeCodigos()
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

        public abstract void RecuperarJogadas();

        public abstract void ProcessarJogadas();

        public void ImprimeResultado()
        {
            Console.WriteLine(ResultadoFinal);

            Console.WriteLine();
            Console.WriteLine();
        }

        protected Personagem RecuperaJogada(string jogador)
        {
            while (true)
            {
                try
                {
                    Console.Write($"{jogador}: ");
                    Personagem personagem = Builder.BuildPersonagem(Console.ReadKey());
                    return personagem;
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("JOGADA INVÁLIDA. JOGUE UMA DAS TECLAS ACIMA.");
                    Console.WriteLine();

                }
            }
        }

        public bool JogarNovamente()
        {
            Console.Write("GOSTARIA DE JOGAR NOVAMENTE? (S/N) ");

            return Console.ReadKey().Key.ToString() == "S";
        }
    }
}
