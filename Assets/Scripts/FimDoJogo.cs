using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FimDoJogo : MonoBehaviour {
    public GameObject npc1;
    public GameObject fita;
    public GameObject npc2;
    public GameObject npc3;
    public GameObject painel;
    public GameObject npc4;

    public string[] texto;
    public Text mensagem;

    // Use this for initialization
    void Start () {
        npc1 = GameObject.Find("SalvaVidas");
        npc2 = GameObject.Find("Mecanico 1_3");
        npc3 = GameObject.Find("ProfessorEF");
        npc4 = GameObject.Find("juiz");
        fita = GameObject.Find("fita");
        painel.SetActive(false);
        mensagem.text = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (npc1.GetComponent<Quiz>().respondeu &&
            npc2.GetComponent<Quiz>().respondeu &&
            npc3.GetComponent<Quiz>().respondeu &&
            npc4.GetComponent<Quiz>().respondeu)
        {
            if (Quiz.contadorRespostasCertas == 4)
            {
                Destroy(fita);
                painel.SetActive(true);
                mensagem.text = "Parabens!!!!, voce acertou todas";
                StartCoroutine(Volta());
            }
            else {
                painel.SetActive(true);
                mensagem.text = "GAME OVER!!!!, voce nao respondeu as questoes corretamente.\n Tente outra vez";
                StartCoroutine(Volta());
            }



        }
	}

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(5f);
        painel.SetActive(false);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync("MenuPrincipal", LoadSceneMode.Single);
        mensagem.text = null;
    }
}
