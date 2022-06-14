using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameContrroler : MonoBehaviourPunCallbacks
{
    public GameObject player;
    Rigidbody2D rig;
    [SerializeField] float velocidade = 5;
    // Start is called before the first frame update
    void Start()
    {
        rig =   GetComponent<Rigidbody2D>();  
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        float RandomPos = Random.Range(2, 2);
        PhotonNetwork.Instantiate(player.name, new Vector2(player.transform.position.x * RandomPos, player.transform.position.y), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        if(photonView.IsMine)
        {
            ProcessInput();
        }
        else
        {
            SmoothMovement();
        }
    }
    void SmoothMovement()
    {
        //transform.position = Vector3.Lerp(transform.position, clientePos, Time.fixedDeltaTime);
        //void Start()
        //{
        //    rig = GetComponent<Rigidbody2D>();
        //}
    }
    private void ProcessInput()
    {
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * velocidade, rig.velocity.y);
        //if(movement <0)
        //{
        //    transform.eulerAngles = new Vector3(0, 180, 0);
        //}
        //if(movement>0)
        //{
        //    transform.eulerAngles = new Vector3(0, 0, 0);
        //}
        if(movement>0)
        {
            this.photonView.RPC("ChangeRight", RpcTarget.Others);
        }
        if(movement>0)
        {
            this.photonView.RPC("ChangeLeft", RpcTarget.Others);
        }
    }
    [PunRPC]
    private void ChangeLeft()
    {
        transform.eulerAngles = new Vector3(0, 180, 0);
    }
    [PunRPC]
    private void ChangeRight()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
}
