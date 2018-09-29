using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class criancaGoleiro : MonoBehaviour {
    public GameObject bola;
    public GameObject flagChute;
    public GameObject paineltexto;
    public GameObject salvaVidas;

    private bool flag = true;
    public string[] texto;
    public Text mensagem;
    private  float tempo;
    public float duracaoPosicao;
    public float velocidade = 1f;
    public int position; //direçao da posiçao;

    // Use this for initialization
    void Start () {
        flagChute = GameObject.Find("flagChute");
        bola = GameObject.Find("bola");
        salvaVidas = GameObject.Find("SalvaVidas");


        position = Random.Range(0, 1);
        duracaoPosicao = 0.6f;
        paineltexto.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flagChute.GetComponent<flagChute>().liberaChute)
        {
            tempo += Time.deltaTime; //guarda o tempo atual 


            //controle do tempo
            if (tempo >= duracaoPosicao)
            {
                tempo = 0;

                if (position == 1) // muda a direçao da movimentação do goleiro
                    position = 0;
                else
                    position = 1;
            }

            //movimentação
            if (position == 1)
                transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            if (position == 0)
                transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "crianca" && salvaVidas.GetComponent<salvaVidas>().LiberaColeta && flag)
        {
            mensagem.text = null;
            paineltexto.SetActive(true);
            mensagem.text = "Ola, voce que jogar comigo?\nMuito bem, fique atras da bola e escolha com o mouse o lugar do chute\nPara ganhar, voce deve fazer 3 gols seguidos";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
        }
        else if(collision.gameObject.name == "crianca" && flag == false)
        {
            paineltexto.SetActive(true);
            mensagem.text = "...";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel

        }
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(5f);
        paineltexto.SetActive(false);
        mensagem.text = null;
        flag = false;
    }
}
