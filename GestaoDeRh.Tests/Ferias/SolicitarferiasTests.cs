using GestaoDeRH.Aplicacao.Ferias;
using GestaoDeRH.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRh.Tests.Ferias
{
    public class SolicitarferiasTests
    {
        [Fact]
        public void SolicitarFerias()
        {
            //Arrange
            var colaborador = new Colaborador()
            {
                Id = 0,
                 Nome = "Halirio",
                 Sobrenome = "Pinto",
                 Email = "halirioPinto@email.com",
                 DataDeNascimento =  new DateTime(1990, 5, 11),
                 CPF = "200",
                 RG = "190",
                 DataInicioContratoDeTrabalho = new DateTime(20211, 5, 11),
                 Salario = 1500,
                 Cargo =   "Dev Full Stack Sr"
            };

            //Act




        }
    }
}
