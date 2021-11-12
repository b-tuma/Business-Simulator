using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonthObject : MonoBehaviour
{
    public bool calculated;
    public bool closed;
    //Fluxo de Caixa
    public double saldoInicial;

    public double devolucaoDeAplicacao; //+
    public double pagamentoDeEmprestimos; //-
    public double pagamentoDeCreditoRotativo; //-

    public double novoSaldo;

    public double totalDeEntradas;

    public double receitaDeVendas; //+
    public double receitaFinanceira; //+
    public double outrasReceitas; //+

    public double totalDeSaidas;

    public double custoDeProdutosProduzidos; //-
    public double promocaoEPropaganda; //-
    public double inovacaoETecnologia; //-
    public double gastosEmDesign; //-
    public double despesasAdicionais; //-
    public double maoDeObraOciosa; //-
    public double custoComHoraExtra; //-
    public double aluguelDeMaquinas; //-
    public double estocagem; //-
    public double reinvestimentoNaFabrica; //-
    public double informacoesEPesquisas; //-
    public double beneficiosAosTrabalhadores; //-
    public double despesaFinanceira; //-
    public double impostoDeRenda; //-
    public double participacaoNosLucros; //-
    public double dividendosDistribuidos; //-
    public double outrasDespesas; //-

    public double saldoFinalAntes;

    public double emprestimos; //+
    public double creditoRotativo; //+
    public double aplicacoesFinanceiras; //+

    public double saldoFinal;

    //Especifico ao DRE

    public double custoDosProdutosVendidos; //-

    public double lucroBruto;

    public double depreciacao;

    public double lucroOperacional;

    public double lucroAntesDoImposto;

    public double lucroLiquidoDoExercicio;

    public double resultadosAnteriores;

    public double resultadoAcumuladoAtual;

    //Especifico ao Balanco

    [System.Serializable]
    public struct Ativo
    {
        public double caixa;
        public double aplicacoesFinanceiras;
        public double celular;
        public double smartphone;
        public double tablet;
        public double imobilizado;
        public double total;
    }

    
    public Ativo ativo;

    [System.Serializable]
    public struct Passivo
    {
        public double emprestimos;
        public double creditoRotativo;
        public double capitalSocial;
        public double lucroPrejuizoAcumulado;
        public double total;
    }

    public Passivo passivo;

    [System.Serializable]
    public struct ContaImobilizado
    {
        public double fabricaInicioDoMes;
        public double depreciacao;
        public double reinvestimentoNaFabrica;
        public double fabricaAtual;
    }

    public ContaImobilizado contaImobilizado;

    //Especifico a Conta Estoque

    [System.Serializable]
    public struct EstoqueProduto
    {
        public double estoqueInicial;
        public double produzidos;
        public double vendidos;
        public double estoqueFinal;

        public int qtdEstoqueInicial;
        public int qtdVolumeProduzido;
        public int qtdVolumeVendas;
        public int qtdVendasPerdidas;
        public int qtdEstoqueFinal;
    }

    public EstoqueProduto estoqueCelular;
    public EstoqueProduto estoqueSmartphone;
    public EstoqueProduto estoqueTablet;

    //Especifico a Outras Informacoes
    [System.Serializable]
    public struct InfoProduto
    {
        public float salarioEncargos;
        public float materiaPrimaOutrosInsumos;
        public float custoUnitarioPadrao;
        public float custoMedioPadrao;
        public double usoCapacidadeFabril;
    }

    public InfoProduto infoCelular;
    public InfoProduto infoSmartphone;
    public InfoProduto infoTablet;

    public double salarioMedioMensal;
    public int numeroAcoesMercado;
    public float taxaJurosParaEmprestimo;
    public float taxaAplicacoesFinanceiras;
    public bool initialized;

    public float participacaoPorcentagem;
    public int capacidadeDaFabrica;
    public int forcaTrabalho;
    public int horasGreveTrabalhador;
    public double valorAcaoMercado;

    //Especifico as decisoes

    [System.Serializable]
    public struct DecProduto
    {
        public double precoVenda;
        public double promocaoPropaganda;
        public double inovacaoTecnologia;
        public int unidadesProduzir;
    }
    public DecProduto decCelular;
    public DecProduto decSmartphone;
    public DecProduto decTablet;

    public int decNumTrabalhadores;
    public double decSalarioMedio;
    public double decBeneficios;
    public double decParticipacao;
    public int decCapacidadeFabril;
    public double decEmprestimo;
    public double decAplicacao;
    public double decDividendos;
    public double decGastosDesign;

}
