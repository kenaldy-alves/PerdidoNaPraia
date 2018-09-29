using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class salvaVidas : MonoBehaviour {
    public GameObject painel;
    public GameObject crianca;
    public GameObject criancaCompetidor;
    public TextAsset arquivo;  // importar o arquivo com as falas
    public string[] texto;
    public Text mensagem;

    private int fimDaLinha;
    private int linhaAtual = 0;
    private int cont = 1; // verifica quantas linhas de dialagos sera armazenada
    public bool estaAtivo;

    public bool LiberaColeta = false;

     void Start(){
        painel.SetActive(false);
        estaAtivo = false;

        crianca = GameObject.Find("crianca");
        criancaCompetidor = GameObject.Find("crianca2");

        if (arquivo != null) {
            texto = (arquivo.text.Split('\n'));
        }

        if (fimDaLinha == 0) {
            fimDaLinha = texto.Length;
            
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaAtivo)
        {
            painel.SetActive(true);
            LiberaColeta = true; // libera a flag para movimentar os canos
            proximaFala();
        }

        if (linhaAtual > fimDaLinha && estaAtivo) {
            painel.SetActive(false);
            crianca.GetComponent<criancaMovimentacao>().velocidade = 2f;
            mensagem.text = null;
            estaAtivo = false;
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "crianca" && Input.GetKeyDown(KeyCode.Space))
        {
            estaAtivo = true;
            criancaCompetidor.GetComponent<criancaCompetidor>().liberaCorrida = true;
            crianca.GetComponent<criancaMovimentacao>().velocidade = 0; // enquanto estiver no dialogo a criança esta parada
        }
    }



    void proximaFala() {

        if (linhaAtual < fimDaLinha)
        {            
            mensagem.text = mensagem.text + '\n' + texto[linhaAtual]; // exibe na tela o texto linha atual do arquivo
            cont++; //controla o numero de linha que a variavel mensagem armazena
        }
        if (painel.activeSelf) {    //enquanto o painel estiver ativo a linha e incrementada;
            if (cont > 4){
                cont = 0;
                mensagem.text = null; // esvazia o buffer de mensagem
                mensagem.text = texto[linhaAtual]; 
            }
            linhaAtual++;
        }

    }


}
