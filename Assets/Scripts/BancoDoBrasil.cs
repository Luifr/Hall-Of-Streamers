﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BancoDoBrasil : MonoBehaviour {

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

	int Emprestar(int quantia){
		if (quantia <= 0)
			return 1;
		if (quantia > emprestimoMax)
			return 2;
		if (dinheiroEmprestado > 0)
			return 3;
		diaEmprestimo = Relogio.data.Day;
		tempoDecorrido = 0;
		dinheiroEmprestado = Mathf.RoundToInt(quantia * (1.0f + taxaEmprestimo / 100.0f));

		Atributos.dinheiro += quantia;

		return 0;
	}

	int PagarEmprestimo() {
		if (Atributos.dinheiro < dinheiroEmprestado)
			return 1;

		Atributos.dinheiro -= dinheiroEmprestado;
		dinheiroEmprestado = 0;

		return 0;
	}
}