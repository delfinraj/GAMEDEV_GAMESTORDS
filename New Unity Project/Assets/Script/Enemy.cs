using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform point;
    int dameg = 0;
    public Rigidbody2D r;
    public Rigidbody2D rb;
    public float movementfore = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            
            dameg++;
        }
        if (dameg == 10)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
     //   rb.MovePosition(rb.position + movement * movementfore * Time.deltaTime);
        Vector2 lookdr = r.position - rb.position;
        float angle = Mathf.Atan2(lookdr.y, lookdr.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        rb.AddForce(point.up * movementfore, ForceMode2D.Force);


    }

}
