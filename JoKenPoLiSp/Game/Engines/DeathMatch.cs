using System;
using System.Collections.Generic;
using System.Linq;

namespace JoKenPoLiSp
{
    class DeathMatch : GameEngine
    {
        Dictionary<Personagem, int> Vitorias = new Dictionary<Personagem, int>();
        List<Personagem[]> Batalhas = new List<Personagem[]>();
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
                Vitorias[per] = 0;
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
            for (int i = 0; i < Vitorias.Count; i++)
            {
                for (int j = 0; j < Vitorias.Count; j++)
                {
                    var p1 = Vitorias.ElementAt(i);
                    var p2 = Vitorias.ElementAt(j);

                    if (p1.Key == p2.Key)
                        continue;

                    if (JaBatalhou(p1.Key,p2.Key))
                        continue;

                    if (p1.Key.GanhaDe(p2.Key) == ResultadoComparacao.Ganha)
                        Vitorias[p1.Key] += 1;

                    Batalhas.Add(new Personagem[] { p1.Key, p2.Key });
                }
            }
        }

        private bool JaBatalhou(Personagem p1, Personagem p2)
        {
            return Batalhas.Where(b => (b[0] == p1 && b[1] == p2) || (b[0] == p2 && b[1] == p1))
                .Any();
        }

        private void EncontrarMaiorVitorioso()
        {
            Personagem max = Vitorias.OrderBy(j => j.Value)
                .Select(j => j.Key)
                .First();

            int empatados = 0;
            foreach (var jogada in Vitorias)
                empatados += jogada.Value == Vitorias[max] ? 1 : 0;

            if (empatados > 1)
            {
                var newDic = new Dictionary<Personagem, int>();
                foreach (KeyValuePair<Personagem, int> keyValuePair in Vitorias)
                    if (keyValuePair.Value == Vitorias[max])
                        newDic.Add(keyValuePair.Key, keyValuePair.Value);

                if (newDic.Count == Vitorias.Count)
                {
                    Resultado = "EMPATE ENTRE MAIS DE UM JOGADOR";
                    return;
                }
                else
                {
                    Vitorias = newDic;
                    CalcularNumeroVitorias();
                    EncontrarMaiorVitorioso();
                }
            }

            Resultado = $"JOGADOR {Vitorias.Keys.ToList().IndexOf(max)} GANHOU";
        }

        public override void ExibirVencedor()
        {
            Console.WriteLine(Resultado);

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
