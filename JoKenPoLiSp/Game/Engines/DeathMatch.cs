using System;
using System.Collections.Generic;
using System.Linq;

namespace JoKenPoLiSp
{
    class DeathMatch : GameEngine
    {
        readonly Dictionary<Personagem, int> Jogadas = new Dictionary<Personagem, int>();
        int NumeroDeJogadores;
        string Resultado;

        public override void ExplicarRegras()
        {
            Console.WriteLine("* INSTRUÇÕES *");
            Console.WriteLine("1- Escolha qual jogada deseja fazer de acordo com os códigos abaixo e aperte enter");
            Console.WriteLine("2- Informe o número de jogadores que irão disputar.");
            Console.WriteLine("3- O Jogador com o maior número de vitórias vence.");

            Console.WriteLine();
            Console.WriteLine();
        }

        public override void ExecutarJogo()
        {
            RecuperarNumeroDeJogadores();

            RecuperarJogadas();

            ProcessarJogadas();
        }

        private void RecuperarNumeroDeJogadores()
        {
            Console.Write("Quantos jogadores irão disputar: ");
            NumeroDeJogadores = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();
        }

        private void RecuperarJogadas()
        {
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                var per = RecuperaJogada($"JOGADOR {i}: ");
                Jogadas[per] = 0;
                Console.WriteLine();
            }
        }

        private void ProcessarJogadas()
        {
            CalcularNumeroVitorias();

            EncontrarMaiorVitorioso();
        }

        private void CalcularNumeroVitorias()
        {
            for (int i = 0; i < NumeroDeJogadores; i++)
            {
                for (int j = 0; j < NumeroDeJogadores; j++)
                {
                    var p1 = Jogadas.ElementAt(i);
                    var p2 = Jogadas.ElementAt(j);

                    if (p1.Key == p2.Key)
                        continue;

                    if (p1.Key.GanhaDe(p2.Key) == ResultadoComparacao.Ganha)
                        Jogadas[p1.Key] += 1;
                }
            }
        }

        private void EncontrarMaiorVitorioso()
        {
            Personagem max = Jogadas.OrderBy(j => j.Value)
                .Select(j => j.Key)
                .First();

            Resultado = $"JOGADOR {Jogadas.Keys.ToList().IndexOf(max)} GANHOU";
        }

        public override void ExibirVencedor()
        {
            Console.WriteLine(Resultado);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
