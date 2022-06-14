using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class PhotonPT : MonoBehaviourPunCallbacks
{
    InputField Entrada, Saida;
    void Start()
    {
        
    }

    public void ConectarUsandoConfigs() // Função utilizada para se conectar ao servidor! Deve ser chamada no start.
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void CriarSala(string nomedasala)
    {
        PhotonNetwork.CreateRoom(nomedasala);
    }

    public void EntrarNaSala(string nomedasala)
    {
        PhotonNetwork.JoinRoom(nomedasala);
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
