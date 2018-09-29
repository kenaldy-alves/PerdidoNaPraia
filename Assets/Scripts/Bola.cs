using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour {
    private Vector3 position;
    private float rotacao;
    private int contador = 0;
    private bool flag = true;

    public string[] texto;
    public Text mensagem;

    public GameObject salvaVidas;
    public GameObject fita;
    public GameObject crianca;
    public GameObject flagChute;
    public GameObject painel;
    public GameObject paineltexto;
    public GameObject criancaGol;

    public Rigidbody2D corpo ;

    void Start()
    {
        crianca = GameObject.Find("crianca");
        fita = GameObject.Find("fita");
        flagChute = GameObject.Find("flagChute");
        criancaGol = GameObject.Find("criança2");
        salvaVidas = GameObject.Find("SalvaVidas");
        mensagem.text = null;

        corpo = GetComponent<Rigidbody2D>();
        painel.SetActive(false);
        paineltexto.SetActive(false);
        rotacao = gameObject.transform.rotation.z;
        position = gameObject.transform.position;
    }

    private void Update()
    {
        if (flagChute.GetComponent<flagChute>().liberaChute) {
            painel.SetActive(true);
            crianca.GetComponent<criancaMovimentacao>().velocidade = 0f;
        }
    }

    public void chuteNoMeio() {
        corpo.AddForce(transform.up * 150f);
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void chuteNoLadoEsquerdo()
    {
        corpo.AddForce(transform.up * 150f);
        corpo.AddForce(-transform.right * 150f);
        gameObject.GetComponent<AudioSource>().Play();

    }

    public void chuteNoLadoDireito()
    {
        corpo.AddForce(transform.up * 150f);
        corpo.AddForce(transform.right * 150f);
        gameObject.GetComponent<AudioSource>().Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Controle de quando a crianca goleiro colide com objeto bola
        if (collision.gameObject.name == "criança2")
        {
            flagChute.GetComponent<flagChute>().liberaChute = false;
            paineltexto.SetActive(true);
            painel.SetActive(false);
            mensagem.text = "Ha HA, voce errou!!!\nLembre-se, voce tem que fazer 3 gols seguidos.";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
            contador = 0;

            gameObject.transform.position = position;
            corpo.velocity = Vector3.zero;
            gameObject.transform.Rotate(Vector3.zero);
            corpo.angularVelocity = 0.0f;
        
        }

        //controle quando acriança fizer um gol
        if (collision.gameObject.name == "gol")
        {
            flagChute.GetComponent<flagChute>().liberaChute = false;
            paineltexto.SetActive(true);
            painel.SetActive(false);
            mensagem.text = "Goooooooooooooool!!!!";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
            contador++;

            gameObject.transform.position = position;
            corpo.velocity = Vector3.zero;
            gameObject.transform.Rotate(Vector3.zero);

            if (contador == 3)
            {
                flagChute.GetComponent<flagChute>().liberaChute = false;
                paineltexto.SetActive(true);
                painel.SetActive(false);
                flag = false;
                mensagem.text = "Pfffffffft!!! voce venceu.";
                StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
                Destroy(painel);
                Destroy(corpo);
                Destroy(fita);

                crianca.GetComponent<criancaMovimentacao>().velocidade = 2f;
            }
        }

    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(2f);
        paineltexto.SetActive(false);
        mensagem.text = null;
        if (flag)
            flagChute.GetComponent<flagChute>().liberaChute = true;

        painel.SetActive(true);   
    }

}
