using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material FlashBranco;
    [SerializeField] private float voltanormal = 0.2f;

    private Material matoriginal;
    private SpriteRenderer sr;
    private VidaInimigo vi;

    private void Awake() {
        vi = GetComponent<VidaInimigo>();
        sr = GetComponent<SpriteRenderer>();
        matoriginal = sr.material;
    }

    public IEnumerator FlashRound() {
        sr.material = FlashBranco;
        yield return new WaitForSeconds(voltanormal);
        sr.material = matoriginal;
        vi.DetetaMorte();
    }
}
