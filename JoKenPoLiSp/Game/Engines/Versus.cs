using System;

namespace JoKenPoLiSp
{
    class Versus : GameEngine
    {
        Personagem PersonagemA;
        Personagem PersonagemB;
        string Resultado;

        public override void ExplicarRegras()
        {
            Console.WriteLine("* INSTRUÇÕES *");
            Console.WriteLine("1- Escolha qual jogada deseja fazer de acordo com os códigos abaixo e aperte enter");
            Console.WriteLine("2- Dois jogadores irão escolher suas jogadas, um de cada vez.");

            Console.WriteLine();
            Console.WriteLine();
        }

        public override void ExecutarJogo()
        {
            RecuperarJogadas();

            ProcessarJogadas();
        }

        public override void ExibirVencedor()
        {
            Console.WriteLine(Resultado);

            Console.WriteLine();
            Console.WriteLine();
        }

        private void RecuperarJogadas()
        {
            PersonagemA = RecuperaJogada("JOGADOR A");
            Console.WriteLine();

            PersonagemB = RecuperaJogada("JOGADOR B");
            Console.WriteLine();
        }

        private void ProcessarJogadas()
        {
            var res = PersonagemA.GanhaDe(PersonagemB);
            switch (res)
            {
                case ResultadoComparacao.Ganha:
                    Resultado = "JOGADOR A GANHOU";
                    break;
                case ResultadoComparacao.Empata:
                    Resultado = "EMPATE";
                    break;
                case ResultadoComparacao.Perde:
                    Resultado = "JOGADOR B GANHOU";
                    break;
            }
        }
    }
}
