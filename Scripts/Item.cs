using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private enum TipoItem   
    {
        Moeda,
        Enlatado,
        Agua
    }

    [SerializeField] private TipoItem tipoItem;
    [SerializeField] private float distanciaItem = 5f;
    [SerializeField] private float acelaracaoItem = .2f;
    [SerializeField] private float velMov = 3f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuracao = 1f;

    private Vector3 movDir;
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        StartCoroutine(AnimCurveSpawnRound());
    }

    private void Update() {
        Vector3 playerPos = Player.Instance.transform.position;

        if (Vector3.Distance(transform.position, playerPos) < distanciaItem) {
            movDir = (playerPos - transform.position).normalized;
            velMov += acelaracaoItem;
        } else {
            movDir = Vector3.zero;
            velMov = 0;
        }
    }

    private void FixedUpdate() {
        rb.velocity = movDir * velMov * Time.deltaTime;
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.GetComponent<Player>()) {
            DetectaTipoItem();
            Destroy(gameObject);
        }
    }

    private IEnumerator AnimCurveSpawnRound() {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(randomX, randomY);

        float tempoPassado = 0f;

        while (tempoPassado < popDuracao)
        {
            tempoPassado += Time.deltaTime;
            float linearT = tempoPassado/ popDuracao;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);
            yield return null;
        }
    }

    private void DetectaTipoItem() {
    switch (tipoItem) {
        case TipoItem.Moeda:
            GerirEconomia.Instance.AddDinheiro();
            Debug.Log("Moeda");
            break;
        case TipoItem.Enlatado:
            Debug.Log("Enlatado");
            break;
        case TipoItem.Agua:
            VidaPlayer.Instance.VidaDoPlayer();
            Debug.Log("Água");
            break;
    }
}

}
