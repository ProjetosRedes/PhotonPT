using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviourPunCallbacks
{
    [Header("Configurações - Player")]
    [SerializeField] float velocidade = 10;
    [SerializeField] float forcaPulo = 10;
    [SerializeField] int vida = 3;

    [Header("Configurações da Bala")]
    [SerializeField] GameObject bala;
    [SerializeField]Transform instancia;
    [SerializeField] float velocidadeBala = 300;
    [SerializeField] float tempoDeVidaBala = 3;


    [Header("Canvas")]
    [SerializeField] Image vidaUI;
    [SerializeField] GameObject canvasPlayer;
    [SerializeField] TextMeshProUGUI nomePlayer;

    PhotonView pv;
    Rigidbody2D rig;
    SpriteRenderer sr;
    CircleCollider2D col;

    float movement;
    float dirX, dirY;
    bool respawn = false;
    bool olhandoParaFrente = true;

    void Start()
    {
        respawn = false;
        pv = GetComponent<PhotonView>();
        rig = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<CircleCollider2D>();

        if (photonView.IsMine)
        {
            nomePlayer.text = PhotonNetwork.NickName;
        }
       else
        {
            nomePlayer.text = pv.Owner.NickName;
            nomePlayer.color = Color.yellow;
        }
    }

    private void Update()
    {
        vidaUI.fillAmount = vida / 3f;
        desktop();
        //Mobile();
    }

    private void FixedUpdate() //se tiver usando mobile
    {
        //rig.velocity = new Vector2(dirX * velocidade, dirY * velocidade);
    }

    void desktop()
    {

        if (photonView.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            movement = Input.GetAxis("Horizontal");
            transform.position += input.normalized * velocidade * Time.deltaTime;
            if (movement < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                olhandoParaFrente = false;
            }
            if (movement > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                olhandoParaFrente = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && !respawn)
            {
                GameObject balaAtiva = PhotonNetwork.Instantiate(bala.name, instancia.position, instancia.rotation);
                if (!olhandoParaFrente)
                {
                    balaAtiva.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * velocidadeBala, 0);
                }
                else
                {
                    balaAtiva.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeBala, 0);
                }
                Destroy(balaAtiva, tempoDeVidaBala);
            }
        }
    }

    void Mobile()
    {
        if (photonView.IsMine)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        if (touch.deltaPosition.x > 10)
                        {
                            dirX = 2;
                            olhandoParaFrente = true;
                            transform.eulerAngles = new Vector3(0f, 0, 0f);
                        }
                        if (touch.deltaPosition.x < -10)
                        {
                            dirX = -2;
                            olhandoParaFrente = false;
                            transform.eulerAngles = new Vector3(0f, 180f, 0f);
                        }
                        if (touch.deltaPosition.y > 10)
                        {
                            dirY = 2;
                        }
                        if (touch.deltaPosition.y < -10)
                        {
                            dirY = -2;
                        }
                        break;
                    case TouchPhase.Ended:
                        dirX = 0;
                        dirY = 0;
                        break;
                }
                if (Input.touchCount == 2 && !respawn)
                {
                    GameObject balaAtiva = PhotonNetwork.Instantiate(bala.name, instancia.position, instancia.rotation);
                    if (!olhandoParaFrente)
                    {
                        balaAtiva.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * velocidadeBala, 0);
                    }
                    else
                    {
                        balaAtiva.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeBala, 0);
                    }
                    Destroy(balaAtiva, tempoDeVidaBala);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bala")
        {
            vida--;
            if(vida <1 && !respawn)
            {
                vida = 3;
                StartCoroutine(RespawnDeep());
                //PhotonNetwork.Destroy(gameObject);
                //PhotonNetwork.LoadLevel("Game");
            }
        }
    }

    IEnumerator RespawnDeep()
    {
        respawn = true;
        transform.position = new Vector2(200, 200);
        sr.enabled = false;
        col.enabled = false;
        canvasPlayer.SetActive(false);
        yield return new WaitForSeconds(2);
        transform.position = new Vector2(Random.Range(-7, 7), Random.Range(-3.8f, 3.8f));
        sr.enabled = true;
        col.enabled = true;
        canvasPlayer.SetActive(true);
        vida = 3;
        respawn = false;
    }
}
