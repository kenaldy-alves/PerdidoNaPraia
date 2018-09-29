using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class criancaMovimentacao : MonoBehaviour {
    public float velocidade = 1.0f;

    public Animator animator;

        // Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Movimentacao();

    }

    void Movimentacao(){ //funcao que controla a movimentacao do personagem

        if (Input.GetAxisRaw("Vertical") < 0){ // movimentacao da crianca andando para baixo
            transform.Translate(Vector2.down * velocidade * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Vertical") > 0){ // movimentacao da crianca andando para cima
            transform.Translate(Vector2.up * velocidade * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") > 0){ // movimentacao da crianca andando para direita
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }

        if (Input.GetAxisRaw("Horizontal") < 0){ // movimentacao da crianca (andando para esquerda)
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }

        animator.SetFloat("DirX", Input.GetAxis("Horizontal")); //animaçao horizontal 
        animator.SetFloat("DirY", Input.GetAxis("Vertical"));  //animação vertical

    }

}
