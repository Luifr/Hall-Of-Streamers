using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class BancoDoBrasil : MonoBehaviour {

	[SerializeField]
	private GameObject tax;
	public int taxaEmprestimo;
	public int taxaJuros;
	public int emprestimoMax;
	public int dinheiroEmprestado;
	public int prazoPagamento;
	public int diaEmprestimo;
	private int tempoDecorrido;

	// Use this for initialization
	void Start () {
		taxaEmprestimo = 10;	// Taxa de emprestimo inicial
		taxaJuros = 1; 		// Taxa de juros de 1% ao dia após o prazo de pagamento
		emprestimoMax = 5000;
		prazoPagamento = 5;	// Prazo de pagamento de 5 dias (após esse tempo, aplica a taxa de juros a cada dia não pago)
	}

	// Update is called once per frame
	void Update () {
		AplicarTaxa ();		// Aplica as possíveis taxas
	}

	void AplicarTaxa(){
		// Caso haja dinheiro emprestado e ainda não tenha atualizado o dia (aplicado as possiveis taxas referentes a este dia)
		if (dinheiroEmprestado > 0 && diaEmprestimo + tempoDecorrido != Relogio.data.Day) {
			// Caso o tempo decorrido seja maior que o prazo, adiciona a taxa de juros =D
			if (tempoDecorrido++ > prazoPagamento)
				dinheiroEmprestado *= Mathf.RoundToInt(1.0f + taxaJuros / 100.0f);
		}
	}

	public void Emprestar(Text text){
		float quantia;
		try{
			quantia = float.Parse(text.text.Replace(",","."),System.Globalization.CultureInfo.InvariantCulture);
		}
		catch {
			return;
		}
		Debug.Log(quantia);
		if (quantia <= 0)
			return;
		if (quantia > emprestimoMax)
			return;
		if (dinheiroEmprestado > 0)
			return;
		diaEmprestimo = Relogio.data.Day;
		tempoDecorrido = 0;
		dinheiroEmprestado = Mathf.RoundToInt(quantia * (1.0f + taxaEmprestimo / 100.0f));

		Atributos.dinheiro += quantia;
		string s = GameObject.Find("dec2 (5)").GetComponent<Text>().text;
		tax.SetActive(true);
		tax.GetComponentInChildren<Text>().text = "Valor Emprestado:\nR$: " + dinheiroEmprestado + "\n\nDevolucao:\n" + s.Substring(s.Length-5);
		//Atributos.
		return;
	}

	public void PagarEmprestimo(GameObject box) {
		if (Atributos.dinheiro < dinheiroEmprestado)
			return ;

		Atributos.dinheiro -= dinheiroEmprestado;
		dinheiroEmprestado = 0;
		box.SetActive(true);
		return ;
	}

	public void SetEmprestimoValue(Text text){
		text.text = "R$ " + dinheiroEmprestado; 
	}

	public void SetEmprestimoDate(Text text){
		string s = Relogio.data.AddDays(prazoPagamento).ToShortDateString();
		string[] s1 = s.Substring(0,s.Length-5).Split('/');
		text.text = "Data pagamento: " + s1[1] + "/" + s1[0]; 
	}


}