using GestaoDeRH.Aplicacao.Base;
using GestaoDeRH.Aplicacao.Ferias.DTO;
using GestaoDeRH.Aplicacao.Ferias.Interfaces;
using GestaoDeRH.Aplicacao.FolhaDePagamento.DTO;
using GestaoDeRH.Dominio.FeriasColaborador;
using GestaoDeRH.Dominio.FolhaDePagamento;
using GestaoDeRH.Dominio.Interfaces;
using GestaoDeRH.Dominio.Notificacao;
using GestaoDeRH.Dominio.Pessoas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoDeRH.Aplicacao.Ferias
{
    public class SolicitarFerias(IRepositorio<FeriasColaborador> repositorioFerias, IRepositorio<Colaborador> colaboradorRepositorio) : ISolicitarFerias
    {
        public async Task<ResultadoOperacao<FeriasColaborador>> Ferias(SolicitarFeriasDto dto)
        {
            var resultado = new ResultadoOperacao<FeriasColaborador>();
            var colaborador = await colaboradorRepositorio.Obter(dto.ColaboradorId);
            var diasSolicitados = dto.DataFimFerias.Subtract(dto.DataInicioFerias).Days;
            var solicitacaoNoMesmoPeriodo = await SolicitacaoNoMesmoPeriodo(dto);
            var diasDisponiveis = await DiasDisponiveisParaFerias(colaborador.Id);
            var tempoDeContratoEmDias = TempoDeContratoEmDias(colaborador.DataInicioContratoDeTrabalho);
            
            // Nao foi feito verificacao se o colaborador esta empregado atualmente pois nao era um requesito.
            if (colaborador == null)
            {
                resultado.Erros.Add($"Não existe colaborador com id {dto.ColaboradorId}");
                return resultado;
            }
            if (tempoDeContratoEmDias < 365)
            {
                resultado.Erros.Add($"Colaborador tem menos de 1 ano de trabalho.");
                return resultado;
            }
            else
            {
                if(solicitacaoNoMesmoPeriodo)
                {
                    resultado.Erros.Add($"Já há uma solicitação neste período para este colaborador.");
                    return resultado;
                }
                else
                {
                    if (diasDisponiveis > 0)
                    {
                        FeriasColaborador feriasColaborador = new FeriasColaborador()
                        {
                            ColaboradorId = colaborador.Id,
                            DataInicioFerias = new DateTime(dto.DataInicioFerias.Year, dto.DataInicioFerias.Month, dto.DataInicioFerias.Day),
                            DataFimFerias = new DateTime(dto.DataFimFerias.Year, dto.DataFimFerias.Month, dto.DataFimFerias.Day)
                        };

                        if (diasSolicitados > diasDisponiveis)
                        {
                            await repositorioFerias.Salvar(feriasColaborador);
                            resultado.Dados = feriasColaborador;
                            return resultado;
                        }
                        else
                        {
                            resultado.Erros.Add($"Total de dias solicitados: {diasSolicitados} dias, total de dias disponíveis: {diasDisponiveis} dias");
                            return resultado;
                        }
                    }
                    else
                    {
                        resultado.Erros.Add($"Total de dias solicitados: {diasSolicitados} dias, total de dias disponíveis: {diasDisponiveis} dias");
                        return resultado;
                    }
                }
            }
        }

        private int TempoDeContratoEmDias(DateTime dataInicioContratoDeTrabalho)
        {
            System.DateTime hoje = new System.DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            System.DateTime inicio = new System.DateTime(dataInicioContratoDeTrabalho.Year, dataInicioContratoDeTrabalho.Month, dataInicioContratoDeTrabalho.Day);
            var diferenca = hoje.Subtract(inicio);

            return diferenca.Days;
        }



        private async Task<int> DiasDisponiveisParaFerias(int colaboradorId)
        {

            var diasDisponiveis = 30;
            var hoje = DateTime.Now;
            var listaTodasFerias = await repositorioFerias.Listar();
            var feriasSolicitadasPeloColaboradorNoMesmoAno = listaTodasFerias.Where(x => x.ColaboradorId == colaboradorId && hoje.Subtract(x.DataUltimaSolicitacao).Days < 365).ToList();


            if (feriasSolicitadasPeloColaboradorNoMesmoAno.Count() > 0)
            {
                foreach (var ferias in feriasSolicitadasPeloColaboradorNoMesmoAno)
                {
                    var periodoFeriasEmdias = ferias.DataFimFerias.Subtract(ferias.DataInicioFerias).Days;
                    diasDisponiveis -= periodoFeriasEmdias;
                }
            }
            return diasDisponiveis;
        }

        private async Task<bool> SolicitacaoNoMesmoPeriodo(SolicitarFeriasDto ferias)
        {
            var listaTodasFerias = await repositorioFerias.Listar();
            var feriasSolicitadasPeloColaboradorNoMesmoAno = listaTodasFerias.Where(x => x.ColaboradorId == ferias.ColaboradorId && x.DataFimFerias == ferias.DataFimFerias && x.DataInicioFerias == ferias.DataInicioFerias);
            if (feriasSolicitadasPeloColaboradorNoMesmoAno.Count() > 0)
                return true;
            
            return false;
        }
    }
}


