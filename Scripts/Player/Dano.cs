using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dano : MonoBehaviour
{
    [SerializeField] private int danorcb = 1;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<VidaInimigo>()) {
            VidaInimigo vidaInimigo = other.gameObject.GetComponent<VidaInimigo>();
            vidaInimigo.SofrerDano(danorcb);
        }
    }
}
