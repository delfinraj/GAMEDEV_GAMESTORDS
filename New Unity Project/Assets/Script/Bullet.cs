using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(SelfDestruct());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
