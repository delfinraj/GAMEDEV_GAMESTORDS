using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Playerdetail : MonoBehaviour
{
    public int dameg = 0;
    public float movementfore = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    PhotonView viwe;
    // Update is called once per frame
    private void Start()
    {
        viwe = GetComponent<PhotonView>();
    }
    void Update()
    {
        if (viwe.IsMine)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * movementfore * Time.deltaTime);
        Vector2 lookdr = mousepos - rb.position;
        float angle = Mathf.Atan2(lookdr.y, lookdr.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("s"))
        {
            Debug.Log(movementfore);
            movementfore += 5;
        }
        if (collision.gameObject.CompareTag("bullet"))
        {

            dameg++;
        }
        if (dameg == 10)
        {
            Destroy(gameObject);
        }

    }
}
