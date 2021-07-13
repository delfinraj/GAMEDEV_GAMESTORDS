using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
public class Playerdetail : MonoBehaviourPunCallbacks,IPunObservable
{
    Renderer[] visuals; 
    public int dameg = 0;
    public int health = 100;
    public float movementfore = 5f;
    public Rigidbody2D rb;
    Vector2 movement;
    Vector2 mousepos;
    public Camera cam;
    PhotonView viwe;
   


    public Joystick movejoy;
    public Joystick aimejoy;
    //--------------
    public Transform firepoint;
    public Transform firepoint1;
    public GameObject bulletprefab;
    public float bulletforce = 0.1f;
    public Button bt;
    

    // Update is called once per frame
    private void Start()
    {
        foreach (Joystick go in FindObjectsOfType(typeof(Joystick)) as Joystick[])
        {
            if (go.name == "Fixed Joystick1")
            {
                movejoy = go;
            }
            if (go.name == "Fixed Joystick")
            {
                aimejoy = go;
            }
        }
       
        //  movejoy = FindObjectsOfType<Joystick>();
        // aimejoy = FindObjectOfType<Joystick>();
        // joybotton = FindObjectOfType<Joybotton>();

        viwe = GetComponent<PhotonView>();
        visuals = GetComponentsInChildren<Renderer>();
    }
    void Update()
    {
        if (viwe.IsMine)
            if (gameObject)
            {
                {
                   
                    movement.x = movejoy.Horizontal;
                    movement.y = movejoy.Vertical;
                    Debug.Log(movement.x);
                    mousepos = cam.ScreenToWorldPoint(Input.mousePosition);
                    if (aimejoy.Horizontal != 0 || aimejoy.Vertical != 0)
                    {
                        photonView.RPC("RCP_Shoot", RpcTarget.All);
                    }
                }
            }
        
        
    }
    void FixedUpdate()
    {
        if (viwe.IsMine)
        {
           // rb.velocity = new Vector3(movejoy.Horizontal * movementfore, rb.velocity.y, movejoy.Vertical * movementfore);
            rb.MovePosition(rb.position + movement * movementfore * Time.deltaTime);
            // Vector2 lookdr = mousepos - rb.position;
            Vector2 lookdr = aimejoy.Direction;
            if (lookdr.x != 0 & lookdr.y != 0)
            {
                float angle = Mathf.Atan2(lookdr.y, lookdr.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
            }
            Debug.Log("sdsdsdsdsd" + lookdr.x + "sasasas" + lookdr.y);
            
           
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("s"))
        {
            movementfore += 5;
        }
        if (collision.gameObject.CompareTag("bullet"))
        {

            health -= 10;
        }
        if (health == 0)
        {
            // Destroy(gameObject);
            StartCoroutine(Respawn());
        }

    }


    // sync health
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
       if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else 
        {
            health=(int)stream.ReceiveNext();
        }
    }

    // player respawn
    IEnumerator Respawn()
    {
        SetRenderers(false);
        health = 100;
        Vector2 randempos = new Vector2(Random.Range(-7, 7), Random.Range(-4, 4));
        transform.position = randempos;
        yield return new WaitForSeconds(1);
        SetRenderers(true);
       }
    void SetRenderers(bool state)
    {
        foreach(var renderer in visuals)
        {
            renderer.enabled = state;
        }
    }

    [PunRPC]
    void RCP_Shoot()
    {
        shoot();
      
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        GameObject bullet1 = Instantiate(bulletprefab, firepoint1.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletforce, ForceMode2D.Impulse);
        rb1.AddForce(firepoint1.up * bulletforce, ForceMode2D.Impulse);
    }


}
