using System;
using System.Linq;

namespace JoKenPoLiSp
{
    public abstract class Personagem
    {
        public abstract Type[] TiposQueVence { get; }

        public ResultadoComparacao GanhaDe(Personagem personagem)
        {
            var tipoAtual = this.GetType();
            var tipoOponente = personagem.GetType();

            if (tipoOponente == tipoAtual)
                return ResultadoComparacao.Empata;

            if (TiposQueVence.Contains(tipoOponente))
                return ResultadoComparacao.Ganha;
            else
                return ResultadoComparacao.Perde;
        }
    }
}
