using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lixo : MonoBehaviour {
    private GameObject lixeira;
    private GameObject salvaVidas;

    // Use this for initialization
    void Start () {
        lixeira = GameObject.Find("Coletor");
        salvaVidas = GameObject.Find("SalvaVidas");
    }
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerStay2D(Collider2D collision){

        if ((collision.tag == "crianca") && (Input.GetButton("Jump")) && (lixeira.GetComponent<coletorLixo>().flag == false) && (salvaVidas.GetComponent<salvaVidas>().LiberaColeta)) { //verifica se a criança esta sobre o objeto e se o gatilho do comando e disparado
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject);
            lixeira.GetComponent<coletorLixo>().flag = true;
            VerificaTipo(); 
        }

    }

    void VerificaTipo() {// verifica qual o tipo do objeto foi pego
        if (gameObject.tag == "garrafa")
            lixeira.GetComponent<coletorLixo>().verificador = "plastico";

        if (gameObject.tag == "lata")
            lixeira.GetComponent<coletorLixo>().verificador = "metal";

        if (gameObject.tag == "pizza")
            lixeira.GetComponent<coletorLixo>().verificador = "organico";

        if (gameObject.tag == "maca")
            lixeira.GetComponent<coletorLixo>().verificador = "organico";

    }
}
