using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpion : MonoBehaviour, IInimigo
{
    [SerializeField] private GameObject grapeProjectilePrefab;
    [SerializeField] private float spawnInterval = 7f;

    private SpriteRenderer spriteRenderer;

    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start() {
        StartCoroutine(SpawnProjectilesLoop());
    }

    public void Ataque() {
        if (transform.position.x - Player.Instance.transform.position.x < 0) {
            spriteRenderer.flipX = false;
        } else {
            spriteRenderer.flipX = true;
        }
    }

    public void SpawnProjectileAnimEvent() {
        Instantiate(grapeProjectilePrefab, transform.position, Quaternion.identity);
    }

    private IEnumerator SpawnProjectilesLoop() {
        while (true) {
            SpawnProjectileAnimEvent();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
