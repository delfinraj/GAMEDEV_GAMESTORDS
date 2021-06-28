using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class Creatandjoinroom : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField Joininput;
    public void creatRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(Joininput.text);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("GamePlay");
    }
}
