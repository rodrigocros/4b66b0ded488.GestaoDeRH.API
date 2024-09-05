using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Aplicacao.Ferias.DTO
{
    public class SolicitarFeriasDto
    {
        public int ColaboradorId { get; set; }
        public System.DateTime DataInicioFerias { get; set; }
        public System.DateTime DataFimFerias { get; set; }

    }
}
