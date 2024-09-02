using GestaoDeRH.Dominio.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Dominio.FeriasColaborador
{
    public class FeriasColaborador : Entidade
    {
        public int ColaboradorId { get; set; }
        public System.DateTime DataInicioFerias { get; set; }
        public System.DateTime DataFimFerias { get; set; }
        public System.DateTime DataUltimaSolicitacao { get; set; } = DateTime.Now;

        //public bool ValidarTempoFeriasSolicitadoMenorQue30Dias(FeriasColaborador feriasColaborador)
        //{
        //    int maximoDiasFeriasColaborador = 30;
        //    System.DateTime fim = new System.DateTime(feriasColaborador.DataFimFerias.Year, feriasColaborador.DataFimFerias.Month, feriasColaborador.DataFimFerias.Day);
        //    System.DateTime inicio = new System.DateTime(feriasColaborador.DataInicioFerias.Year, feriasColaborador.DataInicioFerias.Month, feriasColaborador.DataInicioFerias.Day);
        //    var diferenca = fim.Subtract(inicio);

        //    if (diferenca.Days < maximoDiasFeriasColaborador)
        //    { return true; }
        //    return false;
        //}
    }
}
