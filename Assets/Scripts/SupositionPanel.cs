using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SupositionPanel : MonoBehaviour
{
    public GameManager gameManager;
    public Button openButton;
    public Button closeButton;
    public GameObject supoPanel;

    public InputField cVendidos;
    public InputField sVendidos;
    public InputField tVendidos;
    public InputField cSalario;
    public InputField sSalario;
    public InputField tSalario;
    public InputField cMateria;
    public InputField sMateria;
    public InputField tMateria;
    public InputField taxaEmprestimo;
    public InputField taxaAplicacao;
    public InputField HorasGreve;
    public InputField informacoes;
    public InputField outrasReceitas;
    public InputField outrasDespesas;
    public InputField despesaFinanceira;

    public void MinimizeSupo()
    {
        supoPanel.SetActive(false);
        gameManager.Calculate();
    }

    public void OpenSupo()
    {
        supoPanel.SetActive(true);
    }

    public MonthObject AddSupositionsToMonth(MonthObject month)
    {
        month.estoqueCelular.qtdVolumeVendas = InputToInt(cVendidos);
        month.estoqueSmartphone.qtdVolumeVendas = InputToInt(sVendidos);
        month.estoqueTablet.qtdVolumeVendas = InputToInt(tVendidos);
        month.horasGreveTrabalhador = InputToInt(HorasGreve);
        month.infoCelular.salarioEncargos = InputToFloat(cSalario);
        month.infoSmartphone.salarioEncargos = InputToFloat(sSalario);
        month.infoTablet.salarioEncargos = InputToFloat(tSalario);
        month.infoCelular.materiaPrimaOutrosInsumos = InputToFloat(cMateria);
        month.infoSmartphone.materiaPrimaOutrosInsumos = InputToFloat(sMateria);
        month.infoTablet.materiaPrimaOutrosInsumos = InputToFloat(tMateria);
        month.taxaJurosParaEmprestimo = InputToFloat(taxaEmprestimo);
        month.taxaAplicacoesFinanceiras = InputToFloat(taxaAplicacao);
        month.informacoesEPesquisas = InputToDouble(informacoes);
        month.outrasReceitas = InputToDouble(outrasReceitas);
        month.outrasDespesas = InputToDouble(outrasDespesas);
        month.despesaFinanceira = InputToDouble(despesaFinanceira);
        return month;
    }

    int InputToInt(InputField field)
    {
        int value = int.Parse(field.text);
        return value;
    }

    float InputToFloat(InputField field)
    {
        string inputSanitized = field.text;
        inputSanitized = inputSanitized.Replace('.', ',');
        return float.Parse(inputSanitized);
    }

    double InputToDouble(InputField field)
    {
        string inputSanitized = field.text;
        inputSanitized = inputSanitized.Replace('.', ',');
        return double.Parse(inputSanitized);
    }
    private bool closeFields;
    public void ChangeInt(InputField inputField, int value)
    {
        inputField.interactable = !closeFields;
        inputField.text = value.ToString();
    }
    public void ChangeFloat(InputField inputField, float value)
    {
        inputField.interactable = !closeFields;
        string inputSanitized = string.Format("{0:0.00}", value);
        inputField.text = inputSanitized.Replace(',', '.');
    }
    public void ChangeDouble(InputField inputField, double value)
    {
        inputField.interactable = !closeFields;
        string inputSanitized = string.Format("{0:0.00}", value);
        inputField.text = inputSanitized.Replace(',', '.');

    }

    public void UpdateFields(MonthObject month)
    {
        if (month == null) return;

        if (month.closed) closeFields = true;
        ChangeInt(cVendidos, month.estoqueCelular.qtdVolumeVendas);
        ChangeInt(sVendidos, month.estoqueSmartphone.qtdVolumeVendas);
        ChangeInt(tVendidos, month.estoqueTablet.qtdVolumeVendas);
        ChangeFloat(cSalario, month.infoCelular.salarioEncargos);
        ChangeFloat(sSalario, month.infoSmartphone.salarioEncargos);
        ChangeFloat(tSalario, month.infoTablet.salarioEncargos);
        ChangeFloat(cMateria, month.infoCelular.materiaPrimaOutrosInsumos);
        ChangeFloat(sMateria, month.infoSmartphone.materiaPrimaOutrosInsumos);
        ChangeFloat(tMateria, month.infoTablet.materiaPrimaOutrosInsumos);
        ChangeFloat(taxaEmprestimo, month.taxaJurosParaEmprestimo);
        ChangeFloat(taxaAplicacao, month.taxaAplicacoesFinanceiras);
        ChangeInt(HorasGreve, month.horasGreveTrabalhador);
        ChangeDouble(informacoes, month.informacoesEPesquisas);
        ChangeDouble(outrasDespesas, month.outrasDespesas);
        ChangeDouble(outrasReceitas, month.outrasReceitas);
        ChangeDouble(despesaFinanceira, month.despesaFinanceira);
        closeFields = false;

    }
    public void EndEdit(InputField input)
    {
        if (string.IsNullOrEmpty(input.text)) return;
        if(input.contentType == InputField.ContentType.IntegerNumber)
        {
            // E INT
        }
        else
        {
            string inputSanitized = input.text;
            inputSanitized = inputSanitized.Replace('.', ',');
            double inputDouble = double.Parse(inputSanitized);
            //aqui o double ta pronto
            inputSanitized = string.Format("{0:0.00}", inputDouble);
            input.text = inputSanitized.Replace(',', '.');
        }
        
        //AQUI vai o resultado do input sanitizado.
        //Calculo vai só no minimizar

    }
}
