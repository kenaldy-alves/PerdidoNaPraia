using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    public GameObject painel;
    public GameObject painel2;

    public GameObject crianca;
    public GameObject flag1;
    public GameObject flag2;
    public TextAsset arquivo;  // importar o arquivo com as falas
    public string[] texto;
    public Text mensagem;


    public bool respondeu = false; //variavel que armazena se o jogador respondeu a pergunta
    private int fimDaLinha;
    public static int contadorRespostasCertas = 0; //conta o numero de respostas certas
    private int linhaAtual = 0;
    private int cont = 1; // verifica quantas linhas de dialagos sera armazenada
    public bool estaAtivo;

    public bool LiberaConversa = true;

    void Start()
    {
        painel.SetActive(false);
        painel2.SetActive(false);

        estaAtivo = false;

        crianca = GameObject.Find("crianca");
        flag1   = GameObject.Find("flagFala");
        flag2   = GameObject.Find("flagFala2");

        if (arquivo != null)
        {
            texto = (arquivo.text.Split('\n'));
        }

        if (fimDaLinha == 0)
        {
            fimDaLinha = texto.Length;

        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && estaAtivo)
        {
            painel.SetActive(true);
            crianca.GetComponent<criancaMovimentacao>().velocidade = 0f;
            proximaFala();
        }

        if (linhaAtual > fimDaLinha && estaAtivo)
        {   

            painel.SetActive(false);
            painel2.SetActive(true);
            
            crianca.GetComponent<criancaMovimentacao>().velocidade = 2f;
            mensagem.text = null;
            estaAtivo = false;
            Destroy(flag1);
            Destroy(flag2);
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.tag == "crianca" && Input.GetKeyDown(KeyCode.Space))
        {
            estaAtivo = true;
            if (LiberaConversa == true)
            { // Flag utilizada para conversar somente uma vez
                crianca.GetComponent<criancaMovimentacao>().velocidade = 0; // enquanto estiver no dialogo a criança esta parada
                LiberaConversa = false;
            }
        }
    }



    void proximaFala()
    {

        if (linhaAtual < fimDaLinha)
        {
            mensagem.text = mensagem.text + '\n' + texto[linhaAtual]; // exibe na tela o texto linha atual do arquivo
            cont++; //controla o numero de linha que a variavel mensagem armazena
        }
        if (painel.activeSelf)
        {    //enquanto o painel estiver ativo a linha e incrementada;
            if (cont > 4)
            {
                cont = 0;
                mensagem.text = null; // esvazia o buffer de mensagem
                mensagem.text = texto[linhaAtual];
            }
            linhaAtual++;
        }

    }

    public void RespostaCertaQuiz() { // funçao que executa açoes quando a resposta e a correta
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(painel2);
        respondeu = true;
        contadorRespostasCertas++;
        mensagem.text = null;
        painel.SetActive(true);
        mensagem.text = "Parabéns, voce Acertou!!!!";
        StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
    }

    public void RespostaErradaQuiz()
    { // funçao que executa açoes quando a resposta e a errada
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(painel2);
        respondeu = true;
        mensagem.text = null;
        painel.SetActive(true);
        mensagem.text = "Sinto muito, mas voce errou!!!!";
        StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(2f);
        painel.SetActive(false);
        mensagem.text = null;
    }
}
