using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramove : MonoBehaviour
{

    private Transform player;
    private Vector3 temppos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        temppos = transform.position;
        temppos.y = player.position.y;
        temppos.x = player.position.x; 
        transform.position = temppos;
       
    }
}
