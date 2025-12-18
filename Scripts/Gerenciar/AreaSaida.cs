using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaSaida : MonoBehaviour
{
    public string NomeCena;
    public Vector3 PosObj;

    private float esperaCarregar = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            UIDesvanecer.Instance.Escurecer();
            StartCoroutine(RoundCarregarCena());
        }
    }

    private IEnumerator RoundCarregarCena() {
        while (esperaCarregar >= 0)
        {
            esperaCarregar -= Time.deltaTime;
            yield return null;
        }

         GerenciaCena.LoadScene(NomeCena, PosObj);
    }
}
