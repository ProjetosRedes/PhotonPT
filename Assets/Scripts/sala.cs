using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class sala : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField criarSala;
    [SerializeField] InputField entrarSala;
    //[SerializeField] string createRoom;
    //[SerializeField] string joinRoom;
    //RoomOptions roomOptions;

    public void createsalaBT()
    {
        PhotonNetwork.CreateRoom(criarSala.text);
    }

    public void JoinSalaBT()
    {
        PhotonNetwork.JoinRoom(entrarSala.text);
    }
    public void OnJoinRoom()
    {
        //SceneManager.LoadScene(1);
        PhotonNetwork.LoadLevel(1);
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("Sala falhou, error: " + returnCode + "menssagem: " + message);
    }
}
