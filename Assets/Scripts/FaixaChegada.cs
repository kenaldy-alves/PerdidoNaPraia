using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaixaChegada : MonoBehaviour {
    public GameObject criancaCompetidor;
    public GameObject fita;
    public GameObject crianca;

    public float valor = 0;

    // Use this for initialization
    void Start () {
        criancaCompetidor = GameObject.Find("crianca2");
        fita = GameObject.Find("fita");
        crianca = GameObject.Find("crianca");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        valor = criancaCompetidor.GetComponent<criancaCompetidor>().temporizador - criancaCompetidor.GetComponent<criancaCompetidor>().tempo;

        if (collision.tag == "crianca"){
            if (valor <= 11) // verifica se o jogador chegou a tempo
            {
                Destroy(fita);
                Destroy(gameObject);
            }
            else
            {
                crianca.transform.position = criancaCompetidor.transform.position;
                criancaCompetidor.GetComponent<criancaCompetidor>().tempo = 0;
                criancaCompetidor.GetComponent<criancaCompetidor>().flag2 = true;
            }
                
        }
    }

}
