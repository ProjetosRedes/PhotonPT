using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadingAnim : MonoBehaviour
{
    [SerializeField] float tempoDeEspera = 0.1f;
    bool animar = false;
    TextMeshProUGUI texto;
    // Start is called before the first frame update
    void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
        animar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(animar)
        {
            StartCoroutine(AnimLoading());
        }
    }
    IEnumerator AnimLoading()
    {
        animar = false;
        texto.text = "LOADING.";
        yield return new WaitForSeconds(tempoDeEspera);
        texto.text = "LOADING..";
        yield return new WaitForSeconds(tempoDeEspera);
        texto.text = "LOADING...";
        yield return new WaitForSeconds(tempoDeEspera);
        animar = true;

    }
}
