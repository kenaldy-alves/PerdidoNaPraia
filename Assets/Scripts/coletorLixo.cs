using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coletorLixo : MonoBehaviour {
    public bool flag;
    public string verificador;
    public int qtlixo = 4;

    public GameObject painel;
    public GameObject fitaBloqueadora;
    public Text mensagem;

    // Use this for initialization
    void Start()
    {
        flag = false;
        fitaBloqueadora = GameObject.Find("fita");
    }

    private void OnTriggerStay2D(Collider2D collision){
        if ((collision.tag == "crianca") && Input.GetButton("Jump")){ //verifica se a criança esta sobre o objeto e se o gatilho do comando e disparado
            flag = false; //Deixa a crianca apta a pegar um novo objeto
            imprimeMensagem();
            gameObject.GetComponent<AudioSource>().Play();
            if (qtlixo == 0) {
                Destroy(fitaBloqueadora); //destroi objeto da fita para passar a fase
            }
        }
    }

    void imprimeMensagem(){
        if (verificador == "plastico") {
            painel.SetActive(true);
            mensagem.text = "Muito bem,\n Lembre-se lixo de plastico se joga na lixeira vermelha";
            qtlixo--;
            verificador = null;
            StartCoroutine(Volta()); // espera 2 segundo antes de desabilitar o painel
            
        }

        if (verificador == "metal")
        {
            painel.SetActive(true);
            qtlixo--;
            verificador = null;
            mensagem.text = "Muito bem,\n Lembre-se, jogue metais na lixeira amarela";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
        }

        if (verificador == "organico")
        {
            painel.SetActive(true);
            qtlixo--;
            verificador = null;
            mensagem.text = "Muito bem,\n Lembre-se, jogue comidas na lixeira marrom";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
        }

        if (verificador == "papel")
        {
            painel.SetActive(true);
            qtlixo--;
            verificador = null;
            mensagem.text = "Muito bem,\n Lembre-se, jogue papeis na lixeira azul";
            StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
        }

    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(2f);
        painel.SetActive(false);
    }
}
