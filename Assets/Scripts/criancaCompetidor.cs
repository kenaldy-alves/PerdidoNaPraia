using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class criancaCompetidor : MonoBehaviour {
    public GameObject crianca;
    public GameObject painel;

    public string[] texto;
    public Text mensagem;

    public float temporizador = 0;
    public float tempo = 0;
    public bool liberaCorrida;
    public bool flag = true; //flag para mudar o comentario
    public bool flag2 = false; //flag para disparar o contador somente uma vez


    // Use this for initialization
    void Start () {
        crianca = GameObject.Find("crianca");
        liberaCorrida = false;
    }

    void Update()
    {
        temporizador = temporizador + Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca" && liberaCorrida) {

            if (flag && (flag2 == false))
            {
                crianca.GetComponent<criancaMovimentacao>().velocidade = 0f;
                painel.SetActive(true);
                mensagem.text = "Ola, Voce quer competir comigo?\n" + "    OK, para ganhar voce precisa correr ate a chegada \n em menos de 10 segundos";
                StartCoroutine(Volta());
                flag = false;
            }
            if((flag == false) && flag2) {
                crianca.GetComponent<criancaMovimentacao>().velocidade = 0f;
                painel.SetActive(true);
                mensagem.text = "Ha ha ha ha, Voce perdeu!!! Vai tentar de novo?\n" + "Lembre-se,\n para ganhar voce deve chegar em menos de 10 segundos";
                StartCoroutine(Volta());
            }
        }
    }



    IEnumerator Volta()
    {
        yield return new WaitForSeconds(2f);
        painel.SetActive(false);
        gameObject.GetComponent<AudioSource>().Play();
        mensagem.text = null;
        crianca.GetComponent<criancaMovimentacao>().velocidade = 2f;
        tempo = temporizador;
    }
}
