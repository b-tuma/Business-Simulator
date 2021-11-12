using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AlterationPanel alterationPanel;
    public SupositionPanel supositionPanel;
    public InterfaceHandler uiHandler;
    public Button[] monthArray;
    public MonthObject[] savedMonths = new MonthObject[12];

    public MonthObject calculatedMonth;
    public int currentMonth;
    public Color red;
    public Color green;
    public void Start()
    {
        alterationPanel.UpdateFields(savedMonths[0], null);
        supositionPanel.UpdateFields(savedMonths[0]);
        uiHandler.UpdateSheetsUI(savedMonths[0], null);
        currentMonth = 0;
    }

    public void LoadMonth(int index)
    {
        Debug.Log(index);
        if(!savedMonths[index].initialized)
        {
            supositionPanel.AddSupositionsToMonth(savedMonths[index]);
            alterationPanel.AddDecisionsToMonth(savedMonths[index]);
            savedMonths[index].initialized = true;
            Debug.Log("ÏNIT");
        }
        alterationPanel.UpdateFields(savedMonths[index], index > 0 ? savedMonths[index - 1] : null);
        supositionPanel.UpdateFields(savedMonths[index]);
        uiHandler.UpdateSheetsUI(savedMonths[index], index > 0 ? savedMonths[index - 1] : null);
        currentMonth = index;
    }
    public void Calculate()
    {
        if (savedMonths[currentMonth].closed) return;
        calculatedMonth = savedMonths[currentMonth];
        //Adicionar variaveis das decisões
        alterationPanel.AddDecisionsToMonth(calculatedMonth);

        //Adicionar variaveis das suposições
        supositionPanel.AddSupositionsToMonth(calculatedMonth);

        MonthObject previousMonth = savedMonths[currentMonth - 1];

        //CONTA ESTOQUE
        calculatedMonth.estoqueCelular.qtdEstoqueInicial = previousMonth.estoqueCelular.qtdEstoqueFinal;
        calculatedMonth.estoqueSmartphone.qtdEstoqueInicial = previousMonth.estoqueSmartphone.qtdEstoqueFinal;
        calculatedMonth.estoqueTablet.qtdEstoqueInicial = previousMonth.estoqueTablet.qtdEstoqueFinal;
        //CAPACIDADE ATUALIZADA DA FABRICA unidade fabril da floorToInt
        calculatedMonth.ativo.imobilizado = previousMonth.ativo.imobilizado * 0.992d;
        calculatedMonth.depreciacao = previousMonth.ativo.imobilizado - calculatedMonth.ativo.imobilizado;
        double wantedFabrica = calculatedMonth.decCapacidadeFabril * 5000d;
        calculatedMonth.reinvestimentoNaFabrica = wantedFabrica - calculatedMonth.ativo.imobilizado;
        calculatedMonth.capacidadeDaFabrica = calculatedMonth.decCapacidadeFabril;
        calculatedMonth.contaImobilizado.fabricaInicioDoMes = previousMonth.contaImobilizado.fabricaAtual;
        calculatedMonth.contaImobilizado.depreciacao = calculatedMonth.depreciacao;
        calculatedMonth.contaImobilizado.reinvestimentoNaFabrica = calculatedMonth.reinvestimentoNaFabrica;
        calculatedMonth.contaImobilizado.fabricaAtual = calculatedMonth.contaImobilizado.fabricaInicioDoMes - calculatedMonth.contaImobilizado.depreciacao + calculatedMonth.contaImobilizado.reinvestimentoNaFabrica;
        calculatedMonth.ativo.imobilizado = calculatedMonth.contaImobilizado.fabricaAtual;
        calculatedMonth.forcaTrabalho = calculatedMonth.decNumTrabalhadores;
        //volume produzido
        //Verificar primeiro se tem capacidade o suficiente
        int capacidadeFabril = calculatedMonth.capacidadeDaFabrica;
        int capacidadeExtra = Mathf.FloorToInt(calculatedMonth.capacidadeDaFabrica * 0.2f);
        int defaultExtra = capacidadeExtra;
        int capacidadeCelular = calculatedMonth.decCelular.unidadesProduzir;
        int capacidadeSmartphone = calculatedMonth.decSmartphone.unidadesProduzir;
        int capacidadeTablet = calculatedMonth.decTablet.unidadesProduzir;
        if(capacidadeFabril < capacidadeCelular * 0.2f)
        {
            //Se tem menos capacidade do que unidades a produzir, verifica se tem como usar capacidade extra
            if(capacidadeFabril + capacidadeExtra < capacidadeCelular * 0.2f)
            {
                //Não tem o bastante, corta quantidade
                capacidadeCelular = Mathf.FloorToInt((capacidadeFabril + capacidadeExtra) / 0.2f);
                capacidadeFabril = 0;
                capacidadeExtra = 0;
            }
            else
            {
                int aProduzir = Mathf.FloorToInt(capacidadeCelular * 0.2f);
                aProduzir = aProduzir - capacidadeFabril;
                capacidadeFabril = 0;
                capacidadeExtra = capacidadeExtra - aProduzir;
            }
        }
        else
        {
            capacidadeFabril = capacidadeFabril - Mathf.FloorToInt(capacidadeCelular * 0.2f);
        }
        if (capacidadeFabril < capacidadeSmartphone * 0.8f)
        {
            //Se tem menos capacidade do que unidades a produzir, verifica se tem como usar capacidade extra
            if (capacidadeFabril + capacidadeExtra < capacidadeSmartphone * 0.8f)
            {
                capacidadeSmartphone = Mathf.FloorToInt((capacidadeFabril + capacidadeExtra) / 0.8f);
                capacidadeFabril = 0;
                capacidadeExtra = 0;
            }
            else
            {
                int aProduzir = Mathf.FloorToInt(capacidadeSmartphone * 0.8f);
                aProduzir = aProduzir - capacidadeFabril;
                capacidadeFabril = 0;
                capacidadeExtra = capacidadeExtra - aProduzir;
            }
        }
        else
        {
            capacidadeFabril = capacidadeFabril - Mathf.FloorToInt(capacidadeSmartphone * 0.8f);
        }
        if (capacidadeFabril < capacidadeTablet * 0.3f)
        {
            //Se tem menos capacidade do que unidades a produzir, verifica se tem como usar capacidade extra
            if (capacidadeFabril + capacidadeExtra < capacidadeTablet * 0.3f)
            {
                capacidadeTablet = Mathf.FloorToInt((capacidadeFabril + capacidadeExtra) / 0.3f);
                capacidadeFabril = 0;
                capacidadeExtra = 0;
            }
            else
            {
                int aProduzir = Mathf.FloorToInt(capacidadeTablet * 0.3f);
                aProduzir = aProduzir - capacidadeFabril;
                capacidadeFabril = 0;
                capacidadeExtra = capacidadeExtra - aProduzir;
            }
        }
        else
        {
            capacidadeFabril = capacidadeFabril - Mathf.FloorToInt(capacidadeTablet * 0.3f);
        }

        //depois verificar se tem mao de obra o suficiente
        int capacidadeHomemHora = calculatedMonth.forcaTrabalho * (160 - calculatedMonth.horasGreveTrabalhador);
        int capacidadeHorasExtra = Mathf.FloorToInt(capacidadeHomemHora * 0.2f);
        int defaultExtraH = capacidadeHorasExtra;
        
        if(capacidadeHomemHora < capacidadeCelular * 10)
        {
            //Se tem menos capacidade, verificar horas extras
            if(capacidadeHomemHora + capacidadeHorasExtra < capacidadeCelular * 10)
            {
                capacidadeCelular = Mathf.FloorToInt((capacidadeHomemHora + capacidadeHorasExtra) / 10f);
                capacidadeHorasExtra = 0;
                capacidadeHomemHora = 0;
            }
            else
            {
                int aProduzir = capacidadeCelular * 10;
                aProduzir = aProduzir - capacidadeHomemHora;
                capacidadeHomemHora = 0;
                capacidadeHorasExtra = capacidadeHorasExtra - aProduzir;
            }
        }
        else
        {
            capacidadeHomemHora = capacidadeHomemHora - (capacidadeCelular * 10);
        }
        if (capacidadeHomemHora < capacidadeSmartphone * 33)
        {
            //Se tem menos capacidade, verificar horas extras
            if (capacidadeHomemHora + capacidadeHorasExtra < capacidadeSmartphone * 33)
            {
                capacidadeSmartphone = Mathf.FloorToInt((capacidadeHomemHora + capacidadeHorasExtra) / 33f);
                capacidadeHorasExtra = 0;
                capacidadeHomemHora = 0;
            }
            else
            {
                int aProduzir = capacidadeSmartphone * 33;
                aProduzir = aProduzir - capacidadeHomemHora;
                capacidadeHomemHora = 0;
                capacidadeHorasExtra = capacidadeHorasExtra - aProduzir;
            }
        }
        else
        {
            capacidadeHomemHora = capacidadeHomemHora - (capacidadeSmartphone * 33);
        }
        if (capacidadeHomemHora < capacidadeTablet * 50)
        {
            //Se tem menos capacidade, verificar horas extras
            if (capacidadeHomemHora + capacidadeHorasExtra < capacidadeTablet * 50)
            {
                capacidadeTablet = Mathf.FloorToInt((capacidadeHomemHora + capacidadeHorasExtra) / 50f);
                capacidadeHorasExtra = 0;
                capacidadeHomemHora = 0;
            }
            else
            {
                int aProduzir = capacidadeTablet * 50;
                aProduzir = aProduzir - capacidadeHomemHora;
                capacidadeHomemHora = 0;
                capacidadeHorasExtra = capacidadeHorasExtra - aProduzir;
            }
        }
        else
        {
            capacidadeHomemHora = capacidadeHomemHora - (capacidadeTablet * 50);
        }


        //volume de vendas também (suposicao), vendas perdidas também (suposicao)
        calculatedMonth.infoCelular.custoUnitarioPadrao = calculatedMonth.infoCelular.materiaPrimaOutrosInsumos + calculatedMonth.infoCelular.salarioEncargos;
        calculatedMonth.infoSmartphone.custoUnitarioPadrao = calculatedMonth.infoSmartphone.materiaPrimaOutrosInsumos + calculatedMonth.infoSmartphone.salarioEncargos;
        calculatedMonth.infoTablet.custoUnitarioPadrao = calculatedMonth.infoTablet.materiaPrimaOutrosInsumos + calculatedMonth.infoTablet.salarioEncargos;
        calculatedMonth.estoqueCelular.qtdVolumeProduzido = capacidadeCelular;
        calculatedMonth.estoqueSmartphone.qtdVolumeProduzido = capacidadeSmartphone;
        calculatedMonth.estoqueTablet.qtdVolumeProduzido = capacidadeTablet;
        if (calculatedMonth.estoqueCelular.qtdEstoqueInicial + calculatedMonth.estoqueCelular.qtdVolumeProduzido < calculatedMonth.estoqueCelular.qtdVolumeVendas)
        {
            int estoque = calculatedMonth.estoqueCelular.qtdEstoqueInicial + calculatedMonth.estoqueCelular.qtdVolumeProduzido;
            int vendas = calculatedMonth.estoqueCelular.qtdVolumeVendas;
            calculatedMonth.estoqueCelular.qtdVolumeVendas = estoque;
            calculatedMonth.estoqueCelular.qtdVendasPerdidas = vendas - estoque;
        }
        else
        {
            calculatedMonth.estoqueCelular.qtdVendasPerdidas = 0;
        }
        if (calculatedMonth.estoqueSmartphone.qtdEstoqueInicial + calculatedMonth.estoqueSmartphone.qtdVolumeProduzido < calculatedMonth.estoqueSmartphone.qtdVolumeVendas)
        {
            int estoque = calculatedMonth.estoqueSmartphone.qtdEstoqueInicial + calculatedMonth.estoqueSmartphone.qtdVolumeProduzido;
            int vendas = calculatedMonth.estoqueSmartphone.qtdVolumeVendas;
            calculatedMonth.estoqueSmartphone.qtdVolumeVendas = estoque;
            calculatedMonth.estoqueSmartphone.qtdVendasPerdidas = vendas - estoque;
        }
        else
        {
            calculatedMonth.estoqueSmartphone.qtdVendasPerdidas = 0;
        }
        if (calculatedMonth.estoqueTablet.qtdEstoqueInicial + calculatedMonth.estoqueTablet.qtdVolumeProduzido < calculatedMonth.estoqueTablet.qtdVolumeVendas)
        {
            int estoque = calculatedMonth.estoqueTablet.qtdEstoqueInicial + calculatedMonth.estoqueTablet.qtdVolumeProduzido;
            int vendas = calculatedMonth.estoqueTablet.qtdVolumeVendas;
            calculatedMonth.estoqueTablet.qtdVolumeVendas = estoque;
            calculatedMonth.estoqueTablet.qtdVendasPerdidas = vendas - estoque;

        }
        else
        {
            calculatedMonth.estoqueTablet.qtdVendasPerdidas = 0;
        }
        calculatedMonth.estoqueCelular.qtdEstoqueFinal = calculatedMonth.estoqueCelular.qtdEstoqueInicial + calculatedMonth.estoqueCelular.qtdVolumeProduzido - calculatedMonth.estoqueCelular.qtdVolumeVendas;
        calculatedMonth.estoqueSmartphone.qtdEstoqueFinal = calculatedMonth.estoqueSmartphone.qtdEstoqueInicial + calculatedMonth.estoqueSmartphone.qtdVolumeProduzido - calculatedMonth.estoqueSmartphone.qtdVolumeVendas;
        calculatedMonth.estoqueTablet.qtdEstoqueFinal = calculatedMonth.estoqueTablet.qtdEstoqueInicial + calculatedMonth.estoqueTablet.qtdVolumeProduzido - calculatedMonth.estoqueTablet.qtdVolumeVendas;
        calculatedMonth.estoqueCelular.estoqueInicial = previousMonth.estoqueCelular.estoqueFinal;
        calculatedMonth.estoqueCelular.produzidos = calculatedMonth.infoCelular.custoUnitarioPadrao * calculatedMonth.estoqueCelular.qtdVolumeProduzido;
        calculatedMonth.infoCelular.custoMedioPadrao = (float)((calculatedMonth.estoqueCelular.estoqueInicial + calculatedMonth.estoqueCelular.produzidos) / (calculatedMonth.estoqueCelular.qtdEstoqueInicial + calculatedMonth.estoqueCelular.qtdVolumeProduzido));
        calculatedMonth.estoqueCelular.vendidos = calculatedMonth.infoCelular.custoMedioPadrao * calculatedMonth.estoqueCelular.qtdVolumeVendas;
        calculatedMonth.estoqueCelular.estoqueFinal = calculatedMonth.estoqueCelular.estoqueInicial + calculatedMonth.estoqueCelular.produzidos - calculatedMonth.estoqueCelular.vendidos;
        calculatedMonth.estoqueSmartphone.estoqueInicial = previousMonth.estoqueSmartphone.estoqueFinal;
        calculatedMonth.estoqueSmartphone.produzidos = calculatedMonth.infoSmartphone.custoUnitarioPadrao * calculatedMonth.estoqueSmartphone.qtdVolumeProduzido;
        calculatedMonth.infoSmartphone.custoMedioPadrao = (float)((calculatedMonth.estoqueSmartphone.estoqueInicial + calculatedMonth.estoqueSmartphone.produzidos) / (calculatedMonth.estoqueSmartphone.qtdEstoqueInicial + calculatedMonth.estoqueSmartphone.qtdVolumeProduzido));
        calculatedMonth.estoqueSmartphone.vendidos = calculatedMonth.infoSmartphone.custoMedioPadrao * calculatedMonth.estoqueSmartphone.qtdVolumeVendas;
        calculatedMonth.estoqueSmartphone.estoqueFinal = calculatedMonth.estoqueSmartphone.estoqueInicial + calculatedMonth.estoqueSmartphone.produzidos - calculatedMonth.estoqueSmartphone.vendidos;
        calculatedMonth.estoqueTablet.estoqueInicial = previousMonth.estoqueTablet.estoqueFinal;
        calculatedMonth.estoqueTablet.produzidos = calculatedMonth.infoTablet.custoUnitarioPadrao * calculatedMonth.estoqueTablet.qtdVolumeProduzido;
        calculatedMonth.infoTablet.custoMedioPadrao = (float)((calculatedMonth.estoqueTablet.estoqueInicial + calculatedMonth.estoqueTablet.produzidos) / (calculatedMonth.estoqueTablet.qtdEstoqueInicial + calculatedMonth.estoqueTablet.qtdVolumeProduzido));
        calculatedMonth.estoqueTablet.vendidos = calculatedMonth.infoTablet.custoMedioPadrao * calculatedMonth.estoqueTablet.qtdVolumeVendas;
        calculatedMonth.estoqueTablet.estoqueFinal = calculatedMonth.estoqueTablet.estoqueInicial + calculatedMonth.estoqueTablet.produzidos - calculatedMonth.estoqueTablet.vendidos;
        calculatedMonth.infoCelular.usoCapacidadeFabril = capacidadeCelular * 0.2f;
        calculatedMonth.infoSmartphone.usoCapacidadeFabril = capacidadeSmartphone * 0.8f;
        calculatedMonth.infoTablet.usoCapacidadeFabril = capacidadeTablet * 0.3f;


        calculatedMonth.saldoInicial = previousMonth.saldoFinal;
        calculatedMonth.devolucaoDeAplicacao = previousMonth.aplicacoesFinanceiras;
        //juros do mes anterior? se reduzir o emprestimo aumenta aqui? se manter só cobra o juros?
        if(previousMonth.emprestimos > calculatedMonth.decEmprestimo)
        {
            calculatedMonth.pagamentoDeEmprestimos = previousMonth.emprestimos - calculatedMonth.decEmprestimo;
        }
        else
        {
            calculatedMonth.pagamentoDeEmprestimos = 0f;
        }
        calculatedMonth.pagamentoDeCreditoRotativo = previousMonth.creditoRotativo;
        calculatedMonth.novoSaldo = calculatedMonth.saldoInicial + calculatedMonth.devolucaoDeAplicacao - calculatedMonth.pagamentoDeEmprestimos - calculatedMonth.pagamentoDeCreditoRotativo;

        //Calcular receita de vendas agora
        calculatedMonth.receitaDeVendas = (calculatedMonth.estoqueCelular.qtdVolumeVendas * calculatedMonth.decCelular.precoVenda) + (calculatedMonth.estoqueSmartphone.qtdVolumeVendas * calculatedMonth.decSmartphone.precoVenda) + (calculatedMonth.estoqueTablet.qtdVolumeVendas * calculatedMonth.decTablet.precoVenda);
        calculatedMonth.receitaFinanceira = calculatedMonth.aplicacoesFinanceiras * (previousMonth.taxaAplicacoesFinanceiras / 100d);
        
        calculatedMonth.outrasReceitas = 0; //TODO: outras receitas VEM DE ONDE?
        calculatedMonth.totalDeEntradas = calculatedMonth.receitaDeVendas + calculatedMonth.receitaFinanceira + calculatedMonth.outrasReceitas;

        //Pra calcular a proxima parte provavelmente precisa calcular o conta estoque primeiro

        calculatedMonth.custoDeProdutosProduzidos = (calculatedMonth.estoqueCelular.qtdVolumeProduzido * calculatedMonth.infoCelular.custoUnitarioPadrao) + (calculatedMonth.estoqueSmartphone.qtdVolumeProduzido * calculatedMonth.infoSmartphone.custoUnitarioPadrao) + (calculatedMonth.estoqueTablet.qtdVolumeProduzido * calculatedMonth.infoTablet.custoUnitarioPadrao);
        calculatedMonth.promocaoEPropaganda = calculatedMonth.decCelular.promocaoPropaganda + calculatedMonth.decSmartphone.promocaoPropaganda + calculatedMonth.decTablet.promocaoPropaganda;
        calculatedMonth.inovacaoETecnologia = calculatedMonth.decCelular.inovacaoTecnologia + calculatedMonth.decSmartphone.inovacaoTecnologia + calculatedMonth.decTablet.inovacaoTecnologia;
        calculatedMonth.gastosEmDesign = calculatedMonth.decGastosDesign;

        calculatedMonth.despesasAdicionais = 0; //TODO: Adicionar ao supositions, mas é um valor mais ou menos previsivel
        if (calculatedMonth.decCapacidadeFabril > previousMonth.capacidadeDaFabrica)
        {
            int CapacidadeNova = calculatedMonth.decCapacidadeFabril - previousMonth.capacidadeDaFabrica;
            float desp = (0.2f * Mathf.Pow(CapacidadeNova / 100f, 2)) + (0.1f * (CapacidadeNova / 100f));
            calculatedMonth.despesasAdicionais = desp * 100000f;
        }
        
        calculatedMonth.salarioMedioMensal = calculatedMonth.decSalarioMedio;
        calculatedMonth.maoDeObraOciosa = capacidadeHomemHora * 10;
        //calculatedMonth.maoDeObraOciosa = 123165;
        calculatedMonth.custoComHoraExtra = (((calculatedMonth.salarioMedioMensal * 2) / 160) * 0.3f) *(defaultExtraH - capacidadeHorasExtra);
        //calculatedMonth.custoComHoraExtra = 18156;
        calculatedMonth.aluguelDeMaquinas = 165 * (defaultExtra - capacidadeExtra);
        calculatedMonth.estocagem = (65 * calculatedMonth.estoqueCelular.qtdEstoqueFinal) + (65 * calculatedMonth.estoqueSmartphone.qtdEstoqueFinal) + (65 * calculatedMonth.estoqueTablet.qtdEstoqueFinal);
        //reinvestimento ta lá em cima
        //calculatedMonth.informacoesEPesquisas = 0f; //Suposicoes
        calculatedMonth.despesaFinanceira = (calculatedMonth.decEmprestimo * (calculatedMonth.taxaJurosParaEmprestimo / 100f)) + (previousMonth.creditoRotativo * 0.06d) ; //AHHH juros
        calculatedMonth.custoDosProdutosVendidos = calculatedMonth.estoqueCelular.vendidos + calculatedMonth.estoqueSmartphone.vendidos + calculatedMonth.estoqueTablet.vendidos;
        calculatedMonth.lucroBruto = calculatedMonth.receitaDeVendas - calculatedMonth.custoDosProdutosVendidos;
        calculatedMonth.beneficiosAosTrabalhadores = calculatedMonth.decNumTrabalhadores * calculatedMonth.decBeneficios; //O que e isso??
        calculatedMonth.lucroOperacional = calculatedMonth.lucroBruto - calculatedMonth.promocaoEPropaganda - calculatedMonth.inovacaoETecnologia - calculatedMonth.gastosEmDesign - calculatedMonth.despesasAdicionais - calculatedMonth.maoDeObraOciosa - calculatedMonth.custoComHoraExtra - calculatedMonth.aluguelDeMaquinas - calculatedMonth.estocagem - calculatedMonth.depreciacao - calculatedMonth.informacoesEPesquisas - calculatedMonth.beneficiosAosTrabalhadores;
        calculatedMonth.lucroAntesDoImposto = calculatedMonth.lucroOperacional + calculatedMonth.receitaFinanceira - calculatedMonth.despesaFinanceira + calculatedMonth.outrasReceitas - calculatedMonth.outrasDespesas;
        calculatedMonth.resultadosAnteriores = currentMonth == 1 ? 0 : previousMonth.resultadoAcumuladoAtual;
        if (calculatedMonth.lucroAntesDoImposto > 0f)
        {
            if(calculatedMonth.resultadosAnteriores < 0f)
            {
                calculatedMonth.impostoDeRenda = (calculatedMonth.lucroAntesDoImposto + calculatedMonth.resultadosAnteriores) * 0.3f;
            }
            else
            {
                calculatedMonth.impostoDeRenda = calculatedMonth.lucroAntesDoImposto * 0.3f;
            }
            
        }
        else
        {
            calculatedMonth.impostoDeRenda = 0f;
        }
        
        calculatedMonth.lucroLiquidoDoExercicio = calculatedMonth.lucroAntesDoImposto - calculatedMonth.impostoDeRenda;
        
        if(calculatedMonth.resultadosAnteriores + calculatedMonth.lucroLiquidoDoExercicio > 0f)
        {
            double partic = calculatedMonth.lucroLiquidoDoExercicio * (calculatedMonth.decParticipacao / 100f);
            calculatedMonth.participacaoNosLucros = partic >= 0 ? partic : 0f;
        }
        else
        {
            calculatedMonth.participacaoNosLucros = 0f;
        }
        
        double antesDividendos = calculatedMonth.resultadosAnteriores + calculatedMonth.lucroLiquidoDoExercicio - calculatedMonth.participacaoNosLucros;
        if(calculatedMonth.resultadosAnteriores + calculatedMonth.lucroLiquidoDoExercicio > 0f)
        {
            if (calculatedMonth.decDividendos > antesDividendos)
            {
                calculatedMonth.dividendosDistribuidos = antesDividendos;
                antesDividendos = 0;
            }
            else
            {
                calculatedMonth.dividendosDistribuidos = calculatedMonth.decDividendos;
                antesDividendos = antesDividendos - calculatedMonth.decDividendos;
            }
        }
        else
        {
            calculatedMonth.dividendosDistribuidos = 0f;
        }
        calculatedMonth.resultadoAcumuladoAtual = antesDividendos;
        calculatedMonth.outrasDespesas = 0f; //ONDE??
        calculatedMonth.totalDeSaidas = calculatedMonth.custoDeProdutosProduzidos + calculatedMonth.promocaoEPropaganda + calculatedMonth.inovacaoETecnologia + calculatedMonth.gastosEmDesign + calculatedMonth.despesasAdicionais + calculatedMonth.maoDeObraOciosa + calculatedMonth.custoComHoraExtra + calculatedMonth.aluguelDeMaquinas + calculatedMonth.estocagem + calculatedMonth.reinvestimentoNaFabrica + calculatedMonth.informacoesEPesquisas + calculatedMonth.beneficiosAosTrabalhadores + calculatedMonth.despesaFinanceira + calculatedMonth.impostoDeRenda + calculatedMonth.participacaoNosLucros + calculatedMonth.dividendosDistribuidos + calculatedMonth.outrasDespesas;
        calculatedMonth.saldoFinalAntes = calculatedMonth.novoSaldo + calculatedMonth.totalDeEntradas - calculatedMonth.totalDeSaidas;
        calculatedMonth.emprestimos = calculatedMonth.decEmprestimo;
        calculatedMonth.aplicacoesFinanceiras = calculatedMonth.decAplicacao;
        double valorAntesRotativo = calculatedMonth.saldoFinalAntes + calculatedMonth.emprestimos - calculatedMonth.aplicacoesFinanceiras;
        if (valorAntesRotativo < 0f)
        {
            calculatedMonth.creditoRotativo = -valorAntesRotativo;
        }
        else
        {
            calculatedMonth.creditoRotativo = 0f;
        }
        calculatedMonth.saldoFinal = calculatedMonth.saldoFinalAntes + calculatedMonth.emprestimos + calculatedMonth.creditoRotativo - calculatedMonth.aplicacoesFinanceiras;

        calculatedMonth.ativo.caixa = calculatedMonth.saldoFinal;
        calculatedMonth.ativo.aplicacoesFinanceiras = calculatedMonth.aplicacoesFinanceiras;
        calculatedMonth.ativo.celular = calculatedMonth.estoqueCelular.estoqueFinal;
        calculatedMonth.ativo.smartphone = calculatedMonth.estoqueSmartphone.estoqueFinal;
        calculatedMonth.ativo.tablet = calculatedMonth.estoqueTablet.estoqueFinal;
        calculatedMonth.ativo.total = calculatedMonth.ativo.caixa + calculatedMonth.ativo.aplicacoesFinanceiras + calculatedMonth.ativo.celular + calculatedMonth.ativo.smartphone + calculatedMonth.ativo.tablet + calculatedMonth.ativo.imobilizado;
        calculatedMonth.passivo.emprestimos = calculatedMonth.emprestimos;
        calculatedMonth.passivo.creditoRotativo = calculatedMonth.creditoRotativo;
        calculatedMonth.passivo.capitalSocial = 0f; //Depois ve isso
        calculatedMonth.passivo.lucroPrejuizoAcumulado = calculatedMonth.resultadoAcumuladoAtual;
        calculatedMonth.passivo.total = calculatedMonth.passivo.emprestimos + calculatedMonth.passivo.creditoRotativo + calculatedMonth.passivo.capitalSocial + calculatedMonth.passivo.lucroPrejuizoAcumulado;



        //adiciona a array
        calculatedMonth.calculated = true;
        savedMonths[currentMonth] = calculatedMonth;
        uiHandler.UpdateSheetsUI(calculatedMonth, previousMonth);
    }
}
