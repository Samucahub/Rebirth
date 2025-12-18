using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool rcbKnockback { get; private set; }

    [SerializeField] private float Tempoknockback = .2f;

    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void RcbKnockedback(Transform dano, float impulso) {
        rcbKnockback = true;
        Vector2 difference = (transform.position - dano.position).normalized * impulso * rb.mass;
        rb.AddForce(difference, ForceMode2D.Impulse);
        StartCoroutine(KnockRound());
    }

    private IEnumerator KnockRound() {
        yield return new WaitForSeconds(Tempoknockback);
        rb.velocity = Vector2.zero;
        rcbKnockback = false;
    }
}
