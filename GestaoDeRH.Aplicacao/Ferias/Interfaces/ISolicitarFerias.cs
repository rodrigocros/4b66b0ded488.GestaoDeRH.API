using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.ControlePonto.DTO;
using GestaoDeRH.Aplicacao.Ferias.DTO;
using GestaoDeRH.Dominio.FeriasColaborador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Aplicacao.Ferias.Interfaces
{
    public interface ISolicitarFerias
    {
        Task<ResultadoOperacao<FeriasColaborador>> Ferias(SolicitarFeriasDto dto);

    }
}
