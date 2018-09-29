using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flagFala : MonoBehaviour {
    public GameObject painel;
    public string[] texto;
    public Text mensagem;

    // Use this for initialization
    void Start () {
        painel.SetActive(false);
        mensagem.text = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca") {
            painel.SetActive(true);
            mensagem.text = "Ola, Fale primeiro com o seu tio!!!";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
        }
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(2f);
        painel.SetActive(false);
        mensagem.text = null;
    }

}
