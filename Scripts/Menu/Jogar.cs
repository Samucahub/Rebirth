using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogar : MonoBehaviour
{
    [SerializeField] private string nomeCena; // Nome da próxima cena a ser carregada

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);
            
            CarregarProximaCena();
        }
    }

    public void CarregarProximaCena() {

        Debug.Log("Carregando a próxima cena: " + nomeCena);
        SceneManager.LoadScene(nomeCena);
    }
}
