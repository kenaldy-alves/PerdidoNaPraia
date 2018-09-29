﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanoJoelho2Movimento : MonoBehaviour {
    public bool verificadorCanoJoelho2 = false; //variavel de controle do puzzle
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

        if (gameObject.transform.rotation.eulerAngles.z.Equals(0)) //verifica se esta na posiçao correta
            verificadorCanoJoelho2 = true;
        else
            verificadorCanoJoelho2 = false;

    }
}