using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaInimigo : MonoBehaviour
{
     [SerializeField] private int vidainicial = 3;
     [SerializeField] private GameObject deathVFXPrefab;

    private int vidaatual;
    private Knockback kb;
    private Flash flash;

    private void Awake() {
        flash = GetComponent<Flash>();
        kb = GetComponent<Knockback>();
    }

    private void Start() {
        vidaatual = vidainicial;
    }

    public void SofrerDano(int dano) {
        vidaatual -= dano;
        kb.RcbKnockedback(Player.Instance.transform, 15f);
        StartCoroutine(flash.FlashRound());
    }

    public void DetetaMorte() {
        if (vidaatual <= 0) {
            GetComponent<SpawnerItem>().DropItems();
            Instantiate(deathVFXPrefab, transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
    }

}
