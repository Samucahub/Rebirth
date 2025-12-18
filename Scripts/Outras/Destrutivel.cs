using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destrutivel : MonoBehaviour
{
    [SerializeField] private GameObject destroiVFX;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.GetComponent<Dano>()) {
            GetComponent<SpawnerItem>().DropItems();
            Instantiate(destroiVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
