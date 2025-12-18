using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Comprar : MonoBehaviour
{
    [SerializeField] private int custoItem;

    private TMP_Text moedaText;
    private GerirEconomia gerirEconomia;

    const string CONTAGEM_DINHEIRO = "Quantidade de Moedas";

    private void Start() {
        // Obtém a referência ao script GerirEconomia
        gerirEconomia = FindObjectOfType<GerirEconomia>();
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            //if (hit.collider != null && hit.collider.gameObject == gameObject) {
                SpendMoney();
            //}
        }
    }

    public bool CanAfford() {
        return gerirEconomia.dinheiroAtual >= custoItem;
    }

    public void SpendMoney() {
        if (CanAfford()) {
            gerirEconomia.dinheiroAtual -= custoItem;

            if (moedaText == null) {
                moedaText = GameObject.Find(CONTAGEM_DINHEIRO).GetComponent<TMP_Text>();
            }

            moedaText.text = gerirEconomia.dinheiroAtual.ToString("D3");

            Debug.Log("Item comprado");
        } else {
            Debug.Log("Dinheiro insuficiente");
        }
    }
}
