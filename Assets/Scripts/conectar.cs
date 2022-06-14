using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class conectar : MonoBehaviourPunCallbacks
{
    //bool conectou = false;
    [Header("Linkar UI")]
    //[SerializeField] GameObject conectarBT;
    [SerializeField] GameObject connectedScreen;
    [SerializeField] GameObject disconnectScreen;

    //conectando ao servidor
    //lendo 01 objeto punServer

    public void ConectBT()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public void OnDisconected(DisconnectCause cause)
    {
        //conectarBT.SetActive(false);
        disconnectScreen.SetActive(true);
        SceneManager.LoadScene(1);
    }
    public void OnJoinedLobby()
    {
        //conectarBT.SetActive(false);
        connectedScreen.SetActive(true);
        SceneManager.LoadScene(2);
    }
}
