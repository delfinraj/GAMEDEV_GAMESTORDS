using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Spawnplayer : MonoBehaviour
{
    public GameObject playerprefab;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    void Start()
    {
        Vector2 randempos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerprefab.name, randempos, Quaternion.identity);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
