using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerName : MonoBehaviour
{
    [SerializeField] TMP_InputField nomePlayer;
    [SerializeField] Button setarNomeBT;

    public void SetarNickName()
    {
        if(nomePlayer.text.Length >2)
        {
            setarNomeBT.interactable = true;
        }
        else
        {
            setarNomeBT.interactable = false;
        }
    }

    public void SetarNoneBT()
    {
        PhotonNetwork.NickName = nomePlayer.text;
    }
}
