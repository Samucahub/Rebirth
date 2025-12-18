using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Transparencia : MonoBehaviour
{
    [Range(0, 1)]
    [SerializeField] private float quanttransp = 0.8f;
    [SerializeField] private float tempdesaparec = .4f;

    private SpriteRenderer sr;
    private Tilemap tm;

    private void Awake() {
        sr = GetComponent<SpriteRenderer>();
        tm = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>()) {
            if (sr) {
                StartCoroutine(DesaparecRound(sr, tempdesaparec, sr.color.a, quanttransp));
            } else if (tm) {
                StartCoroutine(DesaparecTmRound(tm, tempdesaparec, tm.color.a, quanttransp));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>()) {
            if (sr) {
                StartCoroutine(DesaparecRound(sr, tempdesaparec, sr.color.a, 1f));
            } else if (tm) {
                StartCoroutine(DesaparecTmRound(tm, tempdesaparec, tm.color.a, 1f));
            }
        }
    }

    private IEnumerator DesaparecRound(SpriteRenderer sr, float tempdesaparec, float valorini, float alvotransp) {
        float tempdecor = 0;
        while (tempdecor < tempdesaparec)
        {
            tempdecor += Time.deltaTime;
            float newAlpha = Mathf.Lerp(valorini, alvotransp, tempdecor / tempdesaparec);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }

    private IEnumerator DesaparecTmRound(Tilemap tm, float tempdesaparec, float valorini, float alvotransp) {
        float tempdecor = 0;
        while (tempdecor < tempdesaparec)
        {
            tempdecor += Time.deltaTime;
            float newAlpha = Mathf.Lerp(valorini, alvotransp, tempdecor / tempdesaparec);
            tm.color = new Color(tm.color.r, tm.color.g, tm.color.b, newAlpha);
            yield return null;
        }
    }
}
