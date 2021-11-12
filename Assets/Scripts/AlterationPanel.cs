using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class AlterationPanel : MonoBehaviour
{
    public GameManager gameManager;
    public Button openButton;
    public Button closeButton;
    public GameObject alterPanel;

    public InputField cPrecoVenda;
    public InputField sPrecoVenda;
    public InputField tPrecoVenda;
    public InputField cPropaganda;
    public InputField sPropaganda;
    public InputField tPropaganda;
    public InputField cTecnologia;
    public InputField sTecnologia;
    public InputField tTecnologia;
    public InputField cProduzir;
    public InputField sProduzir;
    public InputField tProduzir;
    public InputField numTrabalhadores;
    public InputField salarioMedio;
    public InputField beneficiosTrabalhadores;
    public InputField participacaoLucros;
    public InputField capacidadeFabril;
    public InputField emprestimo;
    public InputField aplicacao;
    public InputField dividendos;
    public InputField gastosDesign;

    public void OpenAlteration()
    {
        alterPanel.SetActive(true);
    }

    public void MinimizeAlteration()
    {
        //Calcula aqui!
        alterPanel.SetActive(false);
        gameManager.Calculate();
    }

    public void ChangeDouble(InputField inputField, double value, double lastValue, bool colorize = true, bool lessBetter = false)
    {
        inputField.interactable = !closeFields;
        string inputSanitized = string.Format("{0:0.00}", value);
        inputField.text = inputSanitized.Replace(',', '.');
        if (colorize)
        {
            if (value > lastValue)
            {
                inputField.textComponent.color = !lessBetter ? gameManager.green : gameManager.red;
            }
            else if (value < lastValue)
            {
                inputField.textComponent.color = !lessBetter ? gameManager.red : gameManager.green;
            }
            else
            {
                inputField.textComponent.color = Color.black;
            }
        }
    }

    public void ChangeInt(InputField inputField, int value, int lastValue, bool colorize = true, bool lessBetter = false)
    {
        inputField.interactable = !closeFields;
        inputField.text = value.ToString();
        if (colorize)
        {
            if (value > lastValue)
            {
                inputField.textComponent.color = !lessBetter ? gameManager.green : gameManager.red;
            }
            else if (value < lastValue)
            {
                inputField.textComponent.color = !lessBetter ? gameManager.red : gameManager.green;
            }
            else
            {
                inputField.textComponent.color = Color.black;
            }
        }
    }

    private bool closeFields;
    public void UpdateFields(MonthObject month, MonthObject lastMonth)
    {
        if (month == null) return;
        if (lastMonth == null) lastMonth = month;
        if (month.closed) closeFields = true;
        ChangeDouble(cPrecoVenda, month.decCelular.precoVenda, lastMonth.decCelular.precoVenda);
        ChangeDouble(cPropaganda, month.decCelular.promocaoPropaganda, lastMonth.decCelular.promocaoPropaganda);
        ChangeDouble(cTecnologia, month.decCelular.inovacaoTecnologia, lastMonth.decCelular.inovacaoTecnologia);
        ChangeInt(cProduzir, month.decCelular.unidadesProduzir, lastMonth.decCelular.unidadesProduzir);
        ChangeDouble(sPrecoVenda, month.decSmartphone.precoVenda, lastMonth.decSmartphone.precoVenda);
        ChangeDouble(sPropaganda, month.decSmartphone.promocaoPropaganda, lastMonth.decSmartphone.promocaoPropaganda);
        ChangeDouble(sTecnologia, month.decSmartphone.inovacaoTecnologia, lastMonth.decSmartphone.inovacaoTecnologia);
        ChangeInt(sProduzir, month.decSmartphone.unidadesProduzir, lastMonth.decSmartphone.unidadesProduzir);
        ChangeDouble(tPrecoVenda, month.decTablet.precoVenda, lastMonth.decTablet.precoVenda);
        ChangeDouble(tPropaganda, month.decTablet.promocaoPropaganda, lastMonth.decTablet.promocaoPropaganda);
        ChangeDouble(tTecnologia, month.decTablet.inovacaoTecnologia, lastMonth.decTablet.inovacaoTecnologia);
        ChangeInt(tProduzir, month.decTablet.unidadesProduzir, lastMonth.decTablet.unidadesProduzir);
        ChangeInt(numTrabalhadores, month.decNumTrabalhadores, lastMonth.decNumTrabalhadores);
        ChangeDouble(salarioMedio, month.decSalarioMedio, lastMonth.decSalarioMedio);
        ChangeDouble(beneficiosTrabalhadores, month.decBeneficios, lastMonth.decBeneficios);
        ChangeDouble(participacaoLucros, month.decParticipacao, lastMonth.decParticipacao);
        ChangeInt(capacidadeFabril, month.decCapacidadeFabril, lastMonth.decCapacidadeFabril);
        ChangeDouble(emprestimo, month.decEmprestimo, lastMonth.decEmprestimo);
        ChangeDouble(aplicacao, month.decAplicacao, lastMonth.decAplicacao);
        ChangeDouble(dividendos, month.decDividendos, lastMonth.decDividendos);
        ChangeDouble(gastosDesign, month.decGastosDesign, lastMonth.decGastosDesign);
        closeFields = false;
    }

    public void EndEdit(InputField input)
    {
        if (string.IsNullOrEmpty(input.text)) return;
        if (input.contentType != InputField.ContentType.IntegerNumber)
        {
            string inputSanitized = input.text;
            inputSanitized = inputSanitized.Replace('.', ',');
            double inputDouble = double.Parse(inputSanitized);
            //aqui o double ta pronto
            /*if (input == cPrecoVenda || input == sPrecoVenda || input == tPrecoVenda)
            {
                if (inputDouble < 0) inputDouble = 0;
            }
            else if (input == cPropaganda || input == sPropaganda || input == tPropaganda)
            {
                if (inputDouble < 0)
                {
                    inputDouble = 0;
                }
                else if (inputDouble > 500000)
                {
                    inputDouble = 500000;
                }
            }
            else if (input == cTecnologia || input == sTecnologia || input == tTecnologia)
            {
                if (inputDouble < 0)
                {
                    inputDouble = 0;
                }
                else if (inputDouble > 500000)
                {
                    inputDouble = 500000;
                }
            }
            else if (input == gastosDesign)
            {
                if (inputDouble < 0)
                {
                    inputDouble = 0;
                }
                else if (inputDouble > 500000)
                {
                    inputDouble = 500000;
                }
            }
            else if (input == cProduzir)
            {
                int sQtd = InputToInt(sProduzir);
                int tQtd = InputToInt(tProduzir);
                int cQtd = InputToInt(cProduzir);
                int tFabril = Mathf.CeilToInt(tQtd * 0.3f);
                int sFabril = Mathf.CeilToInt(sQtd * 0.8f);
                int cFabril = Mathf.CeilToInt(cQtd * 0.2f);
                int capacidadeFabril = gameManager.savedMonths[gameManager.currentMonth].capacidadeDaFabrica;
                int remainingCapacity = capacidadeFabril - sFabril - tFabril;
                int available = Mathf.FloorToInt(remainingCapacity / 0.2f);
                if (cQtd > available)
                {
                    //Vai usar 20% de aluguel
                    //cQtd = available;
                }

                //Check se tem mao de obra
                //TODO: Continuar conta aqui!!! Falta ver se a capacidade é o suficiente e se não for, limitar ao limite.
                //Calcular capacidade fabril para ver se é possivel
                inputSanitized = string.Format("{0:0.00}", inputDouble);
                Debug.Log(inputSanitized);
                input.text = inputSanitized.Replace(',', '.');
            }
            */

        }
        
        //AQUI vai o resultado do input sanitizado.
        //Calculo vai só no minimizar

    }

    public MonthObject AddDecisionsToMonth(MonthObject month)
    {
        month.decCelular.precoVenda = InputToDouble(cPrecoVenda);
        month.decCelular.promocaoPropaganda = InputToDouble(cPropaganda);
        month.decCelular.inovacaoTecnologia = InputToDouble(cTecnologia);
        month.decCelular.unidadesProduzir = InputToInt(cProduzir);
        month.decSmartphone.precoVenda = InputToDouble(sPrecoVenda);
        month.decSmartphone.promocaoPropaganda = InputToDouble(sPropaganda);
        month.decSmartphone.inovacaoTecnologia = InputToDouble(sTecnologia);
        month.decSmartphone.unidadesProduzir = InputToInt(sProduzir);
        month.decTablet.precoVenda = InputToDouble(tPrecoVenda);
        month.decTablet.promocaoPropaganda = InputToDouble(tPropaganda);
        month.decTablet.inovacaoTecnologia = InputToDouble(tTecnologia);
        month.decTablet.unidadesProduzir = InputToInt(tProduzir);
        month.decNumTrabalhadores = InputToInt(numTrabalhadores);
        month.decSalarioMedio = InputToDouble(salarioMedio);
        month.decBeneficios = InputToDouble(beneficiosTrabalhadores);
        month.decParticipacao = InputToDouble(participacaoLucros);
        month.decCapacidadeFabril = InputToInt(capacidadeFabril);
        month.decEmprestimo = InputToDouble(emprestimo);
        month.decAplicacao = InputToDouble(aplicacao);
        month.decDividendos = InputToDouble(dividendos);
        month.decGastosDesign = InputToDouble(gastosDesign);

        return month;
    }

    double InputToDouble(InputField field)
    {
        string inputSanitized = field.text;
        inputSanitized = inputSanitized.Replace('.', ',');
        return double.Parse(inputSanitized);
    }

    int InputToInt(InputField field)
    {
        int value = int.Parse(field.text);
        return value;
        
    }
}
