using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class bala : MonoBehaviourPunCallbacks
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "borda")
        {
            PhotonNetwork.Destroy(gameObject);
        }
    }
}
