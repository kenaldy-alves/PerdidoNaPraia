using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaFase : MonoBehaviour {
    public int[] vetorFases;
    public List<int> numerosSorteados = new List<int>();
    public int valor;
    public int tamanhoDaLista;
    public bool flag;

    void Start()
    {
        vetorFases = new int[6];
        flag = true;
        vetorFases[0] = 1;
        vetorFases[1] = 1;
        vetorFases[2] = PlayerPrefs.GetInt("pos1");
        vetorFases[3] = PlayerPrefs.GetInt("pos2");
        vetorFases[4] = PlayerPrefs.GetInt("pos3");
        vetorFases[5] = 1;

        inicilizaLista();
        tamanhoDaLista = numerosSorteados.Count;
    }

    void Update()
    {
        if (tamanhoDaLista < 3)
            valor = numeroAleatorio();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerPrefs.DeleteAll();
            Application.Quit();
        }
    }

    void inicilizaLista() { //inicializa a lista com as fases ja resolvidas 

        for (int i = 2; i < 5; i++)
        {
            if (vetorFases[i] == 1)
            {
                numerosSorteados.Add(i);
            }
        }
    }

    int numeroAleatorio() { // gera a cena randomica
        int aux;

        while (true)
        {
            aux = Random.Range(2, 5);
            if (!(numerosSorteados.Contains(aux)))
                break;

        }
        return aux;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca")
        {
          
            if(tamanhoDaLista >= 3)
                SceneManager.LoadSceneAsync(5, LoadSceneMode.Single);

            if (vetorFases[valor] == 0)
            {
                flag = false;

                if (valor == 2)
                    PlayerPrefs.SetInt("pos1", 1);
                if (valor == 3)
                    PlayerPrefs.SetInt("pos2", 1);
                if (valor == 4)
                    PlayerPrefs.SetInt("pos3", 1);

                SceneManager.LoadSceneAsync(valor, LoadSceneMode.Single);
            }
        }
    }

}
