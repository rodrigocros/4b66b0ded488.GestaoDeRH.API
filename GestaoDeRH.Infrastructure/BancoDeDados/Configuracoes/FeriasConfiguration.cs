using GestaoDeRH.Dominio.FeriasColaborador;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Infra.BancoDeDados.Configuracoes
{
    internal class FeriasConfiguration : IEntityTypeConfiguration<FeriasColaborador>
    {
        public void Configure(EntityTypeBuilder<FeriasColaborador> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ColaboradorId);
            builder.Property(x => x.DataFimFerias);
            builder.Property(x => x.DataInicioFerias);
            builder.Property(x => x.DataUltimaSolicitacao);

        }
    }
}
