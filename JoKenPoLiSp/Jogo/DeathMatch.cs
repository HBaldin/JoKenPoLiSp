using System;
using System.Collections.Generic;
using System.Linq;

namespace JoKenPoLiSp
{
    class DeathMatch : Game
    {
        Dictionary<Personagem, int> Personagens =
            new Dictionary<Personagem, int>();

        public override void ImprimeRegras()
        {
            Console.WriteLine("* INSTRUÇÕES *");
            Console.WriteLine("1- Escolha qual jogada deseja fazer de acordo com os códigos abaixo e aperte enter");

            Console.WriteLine();
            Console.WriteLine();
        }

        public override void ProcessarJogadas()
        {
            for (int i = 0; i < Personagens.Count; i++)
            {
                for (int j = 0; j < Personagens.Count; j++)
                {
                    var p1 = Personagens.ElementAt(i);
                    var p2 = Personagens.ElementAt(j);

                    if (p1.Key == p2.Key)
                        continue; ;

                    if (p1.Key.GanhaDe(p2.Key) == ResultadoComparacao.Ganha)
                        Personagens[p1.Key] += 1;
                }
            }
        }

        public override void RecuperarJogadas()
        {
            Console.Write("Quantos jogadores irão disputar: ");
            int numJogadores = int.Parse(Console.ReadKey().KeyChar.ToString());
            Console.WriteLine();

            for (int i = 0; i < numJogadores; i++)
            {
                var p = RecuperaJogada($"JOGADOR {i}: ");
                Personagens[p] = 0;
                Console.WriteLine();
            }
        }
    }
}
