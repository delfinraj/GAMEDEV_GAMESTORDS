using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Shooting : MonoBehaviourPunCallbacks
{ }
/*    public Transform firepoint;
    public Transform firepoint1;
    public GameObject bulletprefab;
    public float bulletforce = 0.1f;
    public Button bt;
    PhotonView viwe;*/
  /*  private void Start()
    {
      
       viwe = GetComponent<PhotonView>();
    }
    // Update is called once per frame
   public void Called()
    {
      

       
        if (viwe.IsMine)
        {

            photonView.RPC("RCP_Shoot", RpcTarget.All);

        }
    }
*/
  //  [PunRPC]
/*    void RCP_Shoot()
    {
        shoot();
      
    }
    void shoot()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        GameObject bullet1 = Instantiate(bulletprefab, firepoint1.position, firepoint.rotation);
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
    rb.AddForce(firepoint.up* bulletforce, ForceMode2D.Impulse);
        rb1.AddForce(firepoint1.up* bulletforce, ForceMode2D.Impulse);       
    }
*/
 
