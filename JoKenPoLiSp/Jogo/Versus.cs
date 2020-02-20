using System;

namespace JoKenPoLiSp
{
    class Versus : Game
    {
        ResultadoComparacao Resultado;
        Personagem PersonagemA;
        Personagem PersonagemB;

        public override void ImprimeRegras()
        {
            Console.WriteLine("* INSTRUÇÕES *");
            Console.WriteLine("1- Escolha qual jogada deseja fazer de acordo com os códigos abaixo e aperte enter");

            Console.WriteLine();
            Console.WriteLine();
        }

        public override void RecuperarJogadas()
        {
            PersonagemA = RecuperaJogada("JOGADOR A");
            Console.WriteLine();

            PersonagemB = RecuperaJogada("JOGADOR B");
            Console.WriteLine();
        }

        public override void ProcessarJogadas()
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
    }
}
