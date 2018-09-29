using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mecanico : MonoBehaviour {
    private GameObject canoT1;
    private GameObject canoT2;
    private GameObject salvaVidas;
    private GameObject canoJoelho1;
    private GameObject canoJoelho2;
    public GameObject painel;
    public GameObject crianca;
    public GameObject fitaBloqueadora; // objeto que trava a sala

    public TextAsset arquivo;  // importar o arquivo com as falas
    public string[] texto;
    public Text mensagem;

    private int fimDaLinha;
    private int linhaAtual = 0;
    private int cont = 1; // verifica quantas linhas de dialagos sera armazenada
    public bool estaAtivo = true; // variavel que controla qual dialogo sera usado

    public bool puzzleLigado = false;

    public Animator animator;
    public Animator animator2;

    // Use this for initialization
    void Start () {
        salvaVidas = GameObject.Find("SalvaVidas");
        canoJoelho1 = GameObject.Find("CanoJoelho1");
        canoJoelho2 = GameObject.Find("CanoJoelho2");
        canoT1 = GameObject.Find("CanoT1");
        canoT2 = GameObject.Find("CanoT2");
        fitaBloqueadora = GameObject.Find("fita");

        painel.SetActive(false);

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
            proximaFala();
        }

        if ((linhaAtual > fimDaLinha) && estaAtivo)
        {
            painel.SetActive(false);
            crianca.GetComponent<criancaMovimentacao>().velocidade = 1.5f; //libera a movimentaçao da criança
            estaAtivo = false;
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "crianca"))
        {
            if ((canoT1.GetComponent<CanoT1Movimento>().verificadorCanoT1) && (canoT2.GetComponent<CanoT2Movimento>().verificadorCanoT2) && (canoJoelho1.GetComponent<CanoJoelho1Movimento>().verificadorCanoJoelho1) && (canoJoelho2.GetComponent<CanoJoelho2Movimento>().verificadorCanoJoelho2))
            {
                animator.SetBool("Acabou", true);
                puzzleLigado = false;
                animator2.SetBool("RegistroParado", true);
                Destroy(fitaBloqueadora);//libera a proxima fase

                mensagem.text = null;
                painel.SetActive(true);
                mensagem.text = "Muito Obrigado,\n Mais tarde os sprinklers serao ligados para molhar as plantas";
                StartCoroutine(Volta()); // espera 2 segundos antes de desabilitar o painel
                
            }

            else if(salvaVidas.GetComponent<salvaVidas>().LiberaColeta){
                puzzleLigado = true;
                estaAtivo = true;
                crianca.GetComponent<criancaMovimentacao>().velocidade = 0f; //trava a movimentação da criança
            }
        }
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(4f);
        painel.SetActive(false);

    }
}
