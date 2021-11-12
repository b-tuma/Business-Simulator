using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceHandler : MonoBehaviour
{
    [Header("FDC")]
    public GameManager gameManager;
    //Panel FDC
    public GameObject panelFDC;
    public Button button_fdc;
    public Text fdc_saldoInicial;
    public Text fdc_decolucao;
    public Text fdc_pagamentoEmprestimo;
    public Text fdc_pagCreditoRotativo;
    public Text fdc_novoSaldo;
    public Text fdc_totalEntradas;
    public Text fdc_receitaVendas;
    public Text fdc_receitaFinanceira;
    public Text fdc_outrasReceitas;
    public Text fdc_totalSaidas;
    public Text fdc_custoProduzidos;
    public Text fdc_propaganda;
    public Text fdc_tecnologia;
    public Text fdc_gastosDesign;
    public Text fdc_despesasAdicionais;
    public Text fdc_maoObraOciosa;
    public Text fdc_horaExtra;
    public Text fdc_aluguelMaquinas;
    public Text fdc_estocagem;
    public Text fdc_reinvestimento;
    public Text fdc_pesquisas;
    public Text fdc_beneficios;
    public Text fdc_despesasFinanceiras;
    public Text fdc_impostoRenda;
    public Text fdc_participacaoLucros;
    public Text fdc_dividendos;
    public Text fdc_despesas;
    public Text fdc_saldoFinalAntes;
    public Text fdc_emprestimos;
    public Text fdc_creditoRotativo;
    public Text fdc_aplicFinanceiras;
    public Text fdc_saldoFinal;

    [Header("DRE")]
    //Panel DRE
    public GameObject panelDRE;
    public Button button_dre;
    public Text dre_receitaVendas;
    public Text dre_custoProdutosVendidos;
    public Text dre_lucroBruto;
    public Text dre_propaganda;
    public Text dre_tecnologia;
    public Text dre_gastosDesign;
    public Text dre_despesasAdicionais;
    public Text dre_maoObraOciosa;
    public Text dre_custoHoraExtra;
    public Text dre_aluguelMaquinas;
    public Text dre_estocagem;
    public Text dre_depreciacao;
    public Text dre_pesquisas;
    public Text dre_beneficios;
    public Text dre_lucroOperacional;
    public Text dre_receitaFinanceira;
    public Text dre_despesaFinanceira;
    public Text dre_outrasReceitas;
    public Text dre_outrasDespesas;
    public Text dre_lucroAntesImposto;
    public Text dre_impostoRenda;
    public Text dre_llexercicio;
    public Text dre_resultadosAnteriores;
    public Text dre_llexercicio2;
    public Text dre_participacaoLucros;
    public Text dre_dividendos;
    public Text dre_resultadoAtual;

    [Header("Balanco")]
    //Panel Balanco
    public GameObject panelBalanco;
    public Button button_balanco;
    public Text ba_caixa;
    public Text ba_aplicFinanceiras;
    public Text ba_celular;
    public Text ba_smartphone;
    public Text ba_tablet;
    public Text ba_imobilizado;
    public Text ba_totalAtivo;
    public Text ba_emprestimos;
    public Text ba_creditoRotativo;
    public Text ba_capitalSocial;
    public Text ba_lucroAcumulado;
    public Text ba_totalPassivo;
    public Text ba_fabricaInicio;
    public Text ba_depreciacao;
    public Text ba_reinvestimentoFabrica;
    public Text ba_fabricaAtual;

    [Header("Estoque")]
    //Panel Estoque
    public GameObject panelEstoque;
    public Button button_estoque;
    public Text es_celEstoqueInicial;
    public Text es_celProduzidos;
    public Text es_celVendidos;
    public Text es_celEstoqueFinal;
    public Text es_smaEstoqueInicial;
    public Text es_smaProduzidos;
    public Text es_smaVendidos;
    public Text es_smaEstoqueFinal;
    public Text es_tabEstoqueInicial;
    public Text es_tabProduzidos;
    public Text es_tabVendidos;
    public Text es_tabEstoqueFinal;
    public Text es_cnEstoqueInicial;
    public Text es_cnVolumeProduzido;
    public Text es_cnVolumeVendas;
    public Text es_cnVendasPerdidas;
    public Text es_cnEstoqueFinal;
    public Text es_snEstoqueInicial;
    public Text es_snVolumeProduzido;
    public Text es_snVolumeVendas;
    public Text es_snVendasPerdidas;
    public Text es_snEstoqueFinal;
    public Text es_tnEstoqueInicial;
    public Text es_tnVolumeProduzido;
    public Text es_tnVolumeVendas;
    public Text es_tnVendasPerdidas;
    public Text es_tnEstoqueFinal;

    [Header("Informacoes")]
    //Panel Informacoes
    public GameObject panelInfo;
    public Button button_info;
    public Text inf_celSalario;
    public Text inf_celMateria;
    public Text inf_celCustoUni;
    public Text inf_celCustoMedio;
    public Text inf_celUsoFabril;
    public Text inf_smaSalario;
    public Text inf_smaMateria;
    public Text inf_smaCustoUni;
    public Text inf_smaCustoMedio;
    public Text inf_smaUsoFabril;
    public Text inf_tabSalario;
    public Text inf_tabMateria;
    public Text inf_tabCustoUni;
    public Text inf_tabCustoMedio;
    public Text inf_tabUsoFabril;
    public Text inf_salMedioMensal;
    public Text inf_beneficios;
    public Text inf_participacao;
    public Text inf_numeroAcoes;
    public Text inf_taxaJuros;
    public Text inf_taxaAplicacoes;
    public Text inf_capacidadeFabrica;
    public Text inf_forcaTrabalho;
    public Text inf_horasGreve;
    public Text inf_valorAcaoMercado;



    public void ChangePanel(int num)
    {
        if(num == 0)
        {
            panelFDC.SetActive(true);
            button_fdc.interactable = false;
            panelBalanco.SetActive(false);
            button_balanco.interactable = true;
            panelDRE.SetActive(false);
            button_dre.interactable = true;
            panelEstoque.SetActive(false);
            button_estoque.interactable = true;
            panelInfo.SetActive(false);
            button_info.interactable = true;
        }
        else if (num == 1)
        {
            panelFDC.SetActive(false);
            button_fdc.interactable = true;
            panelBalanco.SetActive(true);
            button_balanco.interactable = false;
            panelDRE.SetActive(false);
            button_dre.interactable = true;
            panelEstoque.SetActive(false);
            button_estoque.interactable = true;
            panelInfo.SetActive(false);
            button_info.interactable = true;
        }
        else if(num == 2)
        {
            panelFDC.SetActive(false);
            button_fdc.interactable = true;
            panelBalanco.SetActive(false);
            button_balanco.interactable = true;
            panelDRE.SetActive(true);
            button_dre.interactable = false;
            panelEstoque.SetActive(false);
            button_estoque.interactable = true;
            panelInfo.SetActive(false);
            button_info.interactable = true;
        }
        else if (num == 3)
        {
            panelFDC.SetActive(false);
            button_fdc.interactable = true;
            panelBalanco.SetActive(false);
            button_balanco.interactable = true;
            panelDRE.SetActive(false);
            button_dre.interactable = true;
            panelEstoque.SetActive(true);
            button_estoque.interactable = false;
            panelInfo.SetActive(false);
            button_info.interactable = true;
        }
        else if (num == 4)
        {
            panelFDC.SetActive(false);
            button_fdc.interactable = true;
            panelBalanco.SetActive(false);
            button_balanco.interactable = true;
            panelDRE.SetActive(false);
            button_dre.interactable = true;
            panelEstoque.SetActive(false);
            button_estoque.interactable = true;
            panelInfo.SetActive(true);
            button_info.interactable = false;
        }
    }

    public void ChangeValue(Text text, double value, double lastValue, bool colorize = true, bool lessBetter = false)
    {
        string newValue = value.ToString("N2", CultureInfo.CurrentCulture);
        text.text = newValue;
        if(colorize)
        {
            if(value > lastValue)
            {
                text.color = !lessBetter ? gameManager.green : gameManager.red;
            }
            else if(value < lastValue)
            {
                text.color = !lessBetter ? gameManager.red : gameManager.green;
            }
            else
            {
                text.color = Color.black;
            }
        }
    }

    public void ChangeValue(Text text, int value, int lastValue, bool colorize = true, bool lessBetter = false)
    {
        text.text = value.ToString();
        if (colorize)
        {
            if (value > lastValue)
            {
                text.color = !lessBetter ? gameManager.green : gameManager.red;
            }
            else if (value < lastValue)
            {
                text.color = !lessBetter ? gameManager.red : gameManager.green;
            }
            else
            {
                text.color = Color.black;
            }
        }
    }

    public void UpdateSheetsUI(MonthObject month, MonthObject lastMonth)
    {
        if (month == null) return;
        if (lastMonth == null) lastMonth = month;
        if (month.closed) lastMonth = month;
        //FDC
        ChangeValue(fdc_saldoInicial, month.saldoInicial, lastMonth.saldoInicial);
        ChangeValue(fdc_decolucao, month.devolucaoDeAplicacao, lastMonth.devolucaoDeAplicacao);
        ChangeValue(fdc_pagamentoEmprestimo, month.pagamentoDeEmprestimos, lastMonth.pagamentoDeEmprestimos);
        ChangeValue(fdc_pagCreditoRotativo, month.pagamentoDeCreditoRotativo, lastMonth.pagamentoDeCreditoRotativo);
        ChangeValue(fdc_novoSaldo, month.novoSaldo, lastMonth.novoSaldo);
        ChangeValue(fdc_totalEntradas, month.totalDeEntradas, lastMonth.totalDeEntradas);
        ChangeValue(fdc_receitaVendas, month.receitaDeVendas, lastMonth.receitaDeVendas);
        ChangeValue(fdc_receitaFinanceira, month.receitaFinanceira, lastMonth.receitaFinanceira);
        ChangeValue(fdc_outrasReceitas, month.outrasReceitas, lastMonth.outrasReceitas);
        ChangeValue(fdc_totalSaidas, month.totalDeSaidas, month.totalDeSaidas);
        ChangeValue(fdc_custoProduzidos, month.custoDeProdutosProduzidos, lastMonth.custoDeProdutosProduzidos, true, true);
        ChangeValue(fdc_propaganda, month.promocaoEPropaganda, month.promocaoEPropaganda);
        ChangeValue(fdc_tecnologia, month.inovacaoETecnologia, lastMonth.inovacaoETecnologia);
        ChangeValue(fdc_gastosDesign, month.gastosEmDesign, lastMonth.gastosEmDesign);
        ChangeValue(fdc_despesasAdicionais, month.despesasAdicionais, lastMonth.despesasAdicionais, true, true);
        ChangeValue(fdc_maoObraOciosa, month.maoDeObraOciosa, lastMonth.maoDeObraOciosa, true, true);
        ChangeValue(fdc_horaExtra, month.custoComHoraExtra, lastMonth.custoComHoraExtra, true , true);
        ChangeValue(fdc_aluguelMaquinas, month.aluguelDeMaquinas, lastMonth.aluguelDeMaquinas, true, true);
        ChangeValue(fdc_estocagem, month.estocagem, lastMonth.estocagem, true, true);
        ChangeValue(fdc_reinvestimento, month.reinvestimentoNaFabrica, lastMonth.reinvestimentoNaFabrica);
        ChangeValue(fdc_pesquisas, month.informacoesEPesquisas, lastMonth.informacoesEPesquisas);
        ChangeValue(fdc_beneficios, month.beneficiosAosTrabalhadores, lastMonth.beneficiosAosTrabalhadores);
        ChangeValue(fdc_despesasFinanceiras, month.despesaFinanceira, lastMonth.despesaFinanceira, true, true);
        ChangeValue(fdc_impostoRenda, month.impostoDeRenda, lastMonth.impostoDeRenda, true, true);
        ChangeValue(fdc_participacaoLucros, month.participacaoNosLucros, lastMonth.participacaoNosLucros);
        ChangeValue(fdc_dividendos, month.dividendosDistribuidos, lastMonth.dividendosDistribuidos);
        ChangeValue(fdc_despesas, month.outrasDespesas, lastMonth.outrasDespesas, true, true);
        ChangeValue(fdc_saldoFinalAntes, month.saldoFinalAntes, lastMonth.saldoFinalAntes);
        ChangeValue(fdc_emprestimos, month.emprestimos, lastMonth.emprestimos);
        ChangeValue(fdc_creditoRotativo, month.creditoRotativo, lastMonth.creditoRotativo, true, true);
        ChangeValue(fdc_aplicFinanceiras, month.aplicacoesFinanceiras, lastMonth.aplicacoesFinanceiras);
        ChangeValue(fdc_saldoFinal, month.saldoFinal, lastMonth.saldoFinal);

        //DRE
        ChangeValue(dre_receitaVendas, month.receitaDeVendas, lastMonth.receitaDeVendas);
        ChangeValue(dre_custoProdutosVendidos, month.custoDosProdutosVendidos, lastMonth.custoDosProdutosVendidos);
        ChangeValue(dre_lucroBruto, month.lucroBruto, lastMonth.lucroBruto);
        ChangeValue(dre_propaganda, month.promocaoEPropaganda, lastMonth.promocaoEPropaganda);
        ChangeValue(dre_tecnologia, month.inovacaoETecnologia, lastMonth.inovacaoETecnologia);
        ChangeValue(dre_gastosDesign, month.gastosEmDesign, lastMonth.gastosEmDesign);
        ChangeValue(dre_despesasAdicionais, month.despesasAdicionais, lastMonth.despesasAdicionais, true, true);
        ChangeValue(dre_maoObraOciosa, month.maoDeObraOciosa, lastMonth.maoDeObraOciosa, true, true);
        ChangeValue(dre_custoHoraExtra, month.custoComHoraExtra, lastMonth.custoComHoraExtra, true, true);
        ChangeValue(dre_aluguelMaquinas, month.aluguelDeMaquinas, lastMonth.aluguelDeMaquinas, true, true);
        ChangeValue(dre_estocagem, month.estocagem, lastMonth.estocagem, true, true);
        ChangeValue(dre_depreciacao, month.depreciacao, lastMonth.depreciacao, true, true);
        ChangeValue(dre_pesquisas, month.informacoesEPesquisas, lastMonth.informacoesEPesquisas);
        ChangeValue(dre_beneficios, month.beneficiosAosTrabalhadores, lastMonth.beneficiosAosTrabalhadores);
        ChangeValue(dre_lucroOperacional, month.lucroOperacional, lastMonth.lucroOperacional);
        ChangeValue(dre_receitaFinanceira, month.receitaFinanceira, lastMonth.receitaFinanceira);
        ChangeValue(dre_despesaFinanceira, month.despesaFinanceira, lastMonth.despesaFinanceira, true, true);
        ChangeValue(dre_outrasReceitas, month.outrasReceitas, lastMonth.outrasReceitas);
        ChangeValue(dre_outrasDespesas, month.outrasDespesas, lastMonth.outrasDespesas,true, true);
        ChangeValue(dre_lucroAntesImposto, month.lucroAntesDoImposto, lastMonth.lucroAntesDoImposto);
        ChangeValue(dre_impostoRenda, month.impostoDeRenda, lastMonth.impostoDeRenda,true, true);
        ChangeValue(dre_llexercicio, month.lucroLiquidoDoExercicio, lastMonth.lucroLiquidoDoExercicio);
        ChangeValue(dre_resultadosAnteriores, month.resultadosAnteriores, lastMonth.resultadosAnteriores);
        ChangeValue(dre_llexercicio2, month.lucroLiquidoDoExercicio, lastMonth.lucroLiquidoDoExercicio);
        ChangeValue(dre_participacaoLucros, month.participacaoNosLucros, lastMonth.participacaoNosLucros);
        ChangeValue(dre_dividendos, month.dividendosDistribuidos, lastMonth.dividendosDistribuidos);
        ChangeValue(dre_resultadoAtual, month.resultadoAcumuladoAtual, lastMonth.resultadoAcumuladoAtual);

        //Balanco
        ChangeValue(ba_caixa, month.ativo.caixa, lastMonth.ativo.caixa);
        ChangeValue(ba_aplicFinanceiras, month.ativo.aplicacoesFinanceiras, lastMonth.ativo.aplicacoesFinanceiras);
        ChangeValue(ba_celular, month.ativo.celular, lastMonth.ativo.celular);
        ChangeValue(ba_smartphone, month.ativo.smartphone, lastMonth.ativo.smartphone);
        ChangeValue(ba_tablet, month.ativo.tablet, lastMonth.ativo.tablet);
        ChangeValue(ba_imobilizado, month.ativo.imobilizado, lastMonth.ativo.imobilizado);
        ChangeValue(ba_totalAtivo, month.ativo.total, lastMonth.ativo.total);
        ChangeValue(ba_emprestimos, month.passivo.emprestimos, lastMonth.passivo.emprestimos);
        ChangeValue(ba_creditoRotativo, month.passivo.creditoRotativo, lastMonth.passivo.creditoRotativo,true, true);
        ChangeValue(ba_capitalSocial, month.passivo.capitalSocial, lastMonth.passivo.capitalSocial);
        ChangeValue(ba_lucroAcumulado, month.passivo.lucroPrejuizoAcumulado, lastMonth.passivo.lucroPrejuizoAcumulado);
        ChangeValue(ba_fabricaInicio, month.contaImobilizado.fabricaInicioDoMes, lastMonth.contaImobilizado.fabricaInicioDoMes);
        ChangeValue(ba_depreciacao, month.contaImobilizado.depreciacao, lastMonth.contaImobilizado.depreciacao);
        ChangeValue(ba_reinvestimentoFabrica, month.contaImobilizado.reinvestimentoNaFabrica, lastMonth.contaImobilizado.reinvestimentoNaFabrica);
        ChangeValue(ba_fabricaAtual, month.contaImobilizado.fabricaAtual, lastMonth.contaImobilizado.fabricaAtual);

        //Conta Estoque
        ChangeValue(es_celEstoqueInicial, month.estoqueCelular.estoqueInicial, lastMonth.estoqueCelular.estoqueInicial);
        ChangeValue(es_celProduzidos, month.estoqueCelular.produzidos, lastMonth.estoqueCelular.produzidos);
        ChangeValue(es_celVendidos, month.estoqueCelular.vendidos, lastMonth.estoqueCelular.vendidos);
        ChangeValue(es_celEstoqueFinal, month.estoqueCelular.estoqueFinal, lastMonth.estoqueCelular.estoqueFinal);
        ChangeValue(es_smaEstoqueInicial, month.estoqueSmartphone.estoqueInicial, lastMonth.estoqueSmartphone.estoqueInicial);
        ChangeValue(es_smaProduzidos, month.estoqueSmartphone.produzidos, lastMonth.estoqueSmartphone.produzidos);
        ChangeValue(es_smaVendidos, month.estoqueSmartphone.vendidos, lastMonth.estoqueSmartphone.vendidos);
        ChangeValue(es_smaEstoqueFinal, month.estoqueSmartphone.estoqueFinal, lastMonth.estoqueSmartphone.estoqueFinal);
        ChangeValue(es_tabEstoqueInicial, month.estoqueTablet.estoqueInicial, lastMonth.estoqueTablet.estoqueInicial);
        ChangeValue(es_tabProduzidos, month.estoqueTablet.produzidos, lastMonth.estoqueTablet.produzidos);
        ChangeValue(es_tabVendidos, month.estoqueTablet.vendidos, lastMonth.estoqueTablet.vendidos);
        ChangeValue(es_tabEstoqueFinal, month.estoqueTablet.estoqueFinal, lastMonth.estoqueTablet.estoqueFinal);
        ChangeValue(es_cnEstoqueInicial, month.estoqueCelular.qtdEstoqueInicial, lastMonth.estoqueCelular.qtdEstoqueInicial);
        ChangeValue(es_cnVolumeProduzido, month.estoqueCelular.qtdVolumeProduzido, lastMonth.estoqueCelular.qtdVolumeProduzido);
        ChangeValue(es_cnVolumeVendas, month.estoqueCelular.qtdVolumeVendas, lastMonth.estoqueCelular.qtdVolumeVendas);
        ChangeValue(es_cnVendasPerdidas, month.estoqueCelular.qtdVendasPerdidas, lastMonth.estoqueCelular.qtdVendasPerdidas, true, true);
        ChangeValue(es_cnEstoqueFinal, month.estoqueCelular.qtdEstoqueFinal, lastMonth.estoqueCelular.qtdEstoqueFinal);
        ChangeValue(es_snEstoqueInicial, month.estoqueSmartphone.qtdEstoqueInicial, lastMonth.estoqueSmartphone.qtdEstoqueInicial);
        ChangeValue(es_snVolumeProduzido, month.estoqueSmartphone.qtdVolumeProduzido, lastMonth.estoqueSmartphone.qtdVolumeProduzido);
        ChangeValue(es_snVolumeVendas, month.estoqueSmartphone.qtdVolumeVendas, lastMonth.estoqueSmartphone.qtdVolumeVendas);
        ChangeValue(es_snVendasPerdidas, month.estoqueSmartphone.qtdVendasPerdidas, lastMonth.estoqueSmartphone.qtdVendasPerdidas, true, true);
        ChangeValue(es_snEstoqueFinal, month.estoqueSmartphone.qtdEstoqueFinal, lastMonth.estoqueSmartphone.qtdEstoqueFinal);
        ChangeValue(es_tnEstoqueInicial, month.estoqueTablet.qtdEstoqueInicial, lastMonth.estoqueTablet.qtdEstoqueInicial);
        ChangeValue(es_tnVolumeProduzido, month.estoqueTablet.qtdVolumeProduzido, lastMonth.estoqueTablet.qtdVolumeProduzido);
        ChangeValue(es_tnVolumeVendas, month.estoqueTablet.qtdVolumeVendas, lastMonth.estoqueTablet.qtdVolumeVendas);
        ChangeValue(es_tnVendasPerdidas, month.estoqueTablet.qtdVendasPerdidas, lastMonth.estoqueTablet.qtdVendasPerdidas, true, true);
        ChangeValue(es_tnEstoqueFinal, month.estoqueTablet.qtdEstoqueFinal, lastMonth.estoqueTablet.qtdEstoqueFinal);
        ChangeValue(inf_celSalario, month.infoCelular.salarioEncargos, lastMonth.infoCelular.salarioEncargos);
        ChangeValue(inf_celMateria, month.infoCelular.materiaPrimaOutrosInsumos, lastMonth.infoCelular.materiaPrimaOutrosInsumos);
        ChangeValue(inf_celCustoUni, month.infoCelular.custoUnitarioPadrao, lastMonth.infoCelular.custoUnitarioPadrao);
        ChangeValue(inf_celCustoMedio, month.infoCelular.custoMedioPadrao, lastMonth.infoCelular.custoMedioPadrao);
        ChangeValue(inf_celUsoFabril, month.infoCelular.usoCapacidadeFabril, lastMonth.infoCelular.usoCapacidadeFabril, false, false);
        ChangeValue(inf_smaSalario, month.infoSmartphone.salarioEncargos, lastMonth.infoSmartphone.salarioEncargos);
        ChangeValue(inf_smaMateria, month.infoSmartphone.materiaPrimaOutrosInsumos, lastMonth.infoSmartphone.materiaPrimaOutrosInsumos);
        ChangeValue(inf_smaCustoUni, month.infoSmartphone.custoUnitarioPadrao, lastMonth.infoSmartphone.custoUnitarioPadrao);
        ChangeValue(inf_smaCustoMedio, month.infoSmartphone.custoMedioPadrao, lastMonth.infoSmartphone.custoMedioPadrao);
        ChangeValue(inf_smaUsoFabril, month.infoSmartphone.usoCapacidadeFabril, lastMonth.infoSmartphone.usoCapacidadeFabril, false, false);
        ChangeValue(inf_tabSalario, month.infoTablet.salarioEncargos, lastMonth.infoTablet.salarioEncargos);
        ChangeValue(inf_tabMateria, month.infoTablet.materiaPrimaOutrosInsumos, lastMonth.infoTablet.materiaPrimaOutrosInsumos);
        ChangeValue(inf_tabCustoUni, month.infoTablet.custoUnitarioPadrao, lastMonth.infoTablet.custoUnitarioPadrao);
        ChangeValue(inf_tabCustoMedio, month.infoTablet.custoMedioPadrao, lastMonth.infoTablet.custoMedioPadrao);
        ChangeValue(inf_tabUsoFabril, month.infoTablet.usoCapacidadeFabril, lastMonth.infoTablet.usoCapacidadeFabril, false, false);

        ChangeValue(inf_salMedioMensal, month.salarioMedioMensal, lastMonth.salarioMedioMensal);
        ChangeValue(inf_beneficios, month.beneficiosAosTrabalhadores, lastMonth.beneficiosAosTrabalhadores);
        ChangeValue(inf_participacao, month.participacaoPorcentagem, lastMonth.participacaoPorcentagem);
        ChangeValue(inf_numeroAcoes, month.numeroAcoesMercado, lastMonth.numeroAcoesMercado);
        ChangeValue(inf_taxaJuros, month.taxaJurosParaEmprestimo, lastMonth.taxaJurosParaEmprestimo);
        ChangeValue(inf_taxaAplicacoes, month.taxaAplicacoesFinanceiras, lastMonth.taxaAplicacoesFinanceiras);
        ChangeValue(inf_capacidadeFabrica, month.capacidadeDaFabrica, lastMonth.capacidadeDaFabrica);
        ChangeValue(inf_forcaTrabalho, month.forcaTrabalho, lastMonth.forcaTrabalho);
        ChangeValue(inf_horasGreve, month.horasGreveTrabalhador, lastMonth.horasGreveTrabalhador);
        ChangeValue(inf_valorAcaoMercado, month.valorAcaoMercado, lastMonth.valorAcaoMercado);
    }
}
