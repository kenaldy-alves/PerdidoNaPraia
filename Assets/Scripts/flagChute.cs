using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flagChute : MonoBehaviour {
    public GameObject salvaVidas;
    public bool liberaChute;
    private bool libera;
    // Use this for initialization
    void Start () {
        salvaVidas = GameObject.Find("SalvaVidas");
        liberaChute = false;
        libera = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca" && salvaVidas.GetComponent<salvaVidas>().LiberaColeta && libera) {
            liberaChute = true;
            libera = false;
        }
    }
}
