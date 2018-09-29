using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaJogo : MonoBehaviour {
    private static MusicaJogo instance = null;
    public GameObject musica;
    public bool valor = false;
    public Scene cena;


    public static MusicaJogo Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        gameObject.GetComponent<AudioSource>().Play();
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);

    }

    private void Update()
    {
        cena = SceneManager.GetActiveScene();
        Debug.Log("Active scene is '" + cena.name + "'.");

        if (cena.name == "fase4") // veerfica as cenas com diferentes musicas
        {
            valor = true;
        }
        else {
            valor = false;
        }

        //valor = PlayerPrefs.GetInt("VarMusica");
        if (valor == true)
        {
            gameObject.GetComponent<AudioSource>().Pause();
        //    PlayerPrefs.SetInt("VarMusica", 0);
        }
        else
        {
            gameObject.GetComponent<AudioSource>().UnPause();
        }

    }
}
