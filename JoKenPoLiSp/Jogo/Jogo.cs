using System;
using System.Text.RegularExpressions;

namespace JoKenPoLiSp
{
    class Jogo
    {
        PersonagemBuilder Builder = new PersonagemBuilder();
        Personagem PersonagemA;
        Personagem PersonagemB;
        public ResultadoComparacao Resultado;

        public void ImprimeRegras()
        {
            Console.WriteLine("Jo-Ken-Po-Li-Sp -- Pedra-Papel-Tesoura-Lagarto-Spock");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("* INSTRUÇÕES *");
            Console.WriteLine("1- Escolha qual jogada deseja fazer de acordo com os códigos abaixo e aperte enter");
            Console.WriteLine("2- Primeiro o jogador A irá escolher, depois o jogador B");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("* CÓDIGOS *");
            Console.WriteLine("1 = PEDRA");
            Console.WriteLine("2 = PAPEL");
            Console.WriteLine("3 = TESOURA");
            Console.WriteLine("4 = LAGARTO");
            Console.WriteLine("5 = SPOCK");

            Console.WriteLine();
            Console.WriteLine();
        }

        public void RecuperarJogadas()
        {
            PersonagemA = RecuperaJogada("JOGADOR A");
            PersonagemB = RecuperaJogada("JOGADOR B");
        }

        public void ImprimeResultado()
        {
            Resultado = PersonagemA.GanhaDe(PersonagemB);
            switch (Resultado)
            {
                case ResultadoComparacao.Ganha:
                    Console.WriteLine("JOGADOR A GANHOU");
                    break;
                case ResultadoComparacao.Empata:
                    Console.WriteLine("EMPATE");
                    break;
                case ResultadoComparacao.Perde:
                    Console.WriteLine("JOGADOR B GANHOU");
                    break;
            }
        }

        private Personagem RecuperaJogada(string jogador)
        {
            ConsoleKeyInfo consoleKeyInfo;
            while (true)
            {
                Console.Write($"{jogador}: ");
                consoleKeyInfo = Console.ReadKey();

                Console.WriteLine();

                if (IsValidKey(consoleKeyInfo))
                    break;
                else
                {
                    Console.WriteLine("JOGADA INVÁLIDA. JOGUE UMA DAS TECLAS ACIMA.");
                    Console.WriteLine();
                }
            }

            int codigo = int.Parse(consoleKeyInfo.KeyChar.ToString());
            return Builder.BuildPersonagem(codigo);
        }

        private static bool IsValidKey(ConsoleKeyInfo consoleKeyInfo)
        {
            Regex regex = new Regex("[1,2,3,4,5]");
            return regex.IsMatch(consoleKeyInfo.Key.ToString());
        }

        public bool JogarNovamente()
        {
            Console.WriteLine();
            Console.WriteLine();

            Console.Write("GOSTARIA DE JOGAR NOVAMENTE? (S/N) ");

            return Console.ReadKey().Key.ToString() == "S";
        }
    }
}
