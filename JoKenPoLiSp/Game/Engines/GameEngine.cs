using System;

namespace JoKenPoLiSp
{
    abstract class GameEngine : IGameEngine
    {
        PersonagemBuilder Builder = new PersonagemBuilder();

        public abstract void ExecutarJogo();

        public abstract void ExibirVencedor();

        public abstract void ExplicarRegras();

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
    }
}
