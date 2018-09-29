using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoT1Movimento : MonoBehaviour {
    public bool verificadorCanoT1 = false; //variavel de controle do puzzle
    public float RotacaoAtual;
    private GameObject mecanico;

    void Start()
    {
        mecanico = GameObject.Find("Mecanico");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca" && (mecanico.GetComponent<Mecanico>().puzzleLigado == true))
        {
            gameObject.transform.Rotate(Vector3.forward * 90); //rotaciona o game object em 90 graus
            RotacaoAtual = transform.rotation.eulerAngles.z;
        }

        if (gameObject.transform.rotation.eulerAngles.z.Equals(180)) //verifica se esta na posiçao correta
            verificadorCanoT1 = true;
        else
            verificadorCanoT1 = false;

    }
}
