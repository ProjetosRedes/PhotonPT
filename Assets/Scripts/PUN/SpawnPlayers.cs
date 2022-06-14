using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour//PunCallbacks
{
    [SerializeField] GameObject playerPrefab;

    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] Color[] cores = new Color[10];

    [SerializeField] Text pingUI;


    void Start()
    {
        SpriteRenderer cor = playerPrefab.GetComponent<SpriteRenderer>();
        //cor.color = cores[Random.Range(0,cores.Length)];
        Vector2 randomPos = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(playerPrefab.name, randomPos, Quaternion.identity);
        //cor.color = Random.ColorHSV();
    }

    private void Update()
    {
        pingUI.text = "PING: " + PhotonNetwork.GetPing();
    }

}
