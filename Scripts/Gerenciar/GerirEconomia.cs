using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GerirEconomia : Unico<GerirEconomia>
{
    private TMP_Text moedaText;
    public int dinheiroAtual = 0;

    const string CONTAGEM_DINHEIRO = "Quantidade de Moedas";

    public void AddDinheiro() {
        dinheiroAtual += 1;
        
        if (moedaText == null) {
            moedaText = GameObject.Find(CONTAGEM_DINHEIRO).GetComponent<TMP_Text>();
        }

        moedaText.text = dinheiroAtual.ToString("D3");
    }
}
