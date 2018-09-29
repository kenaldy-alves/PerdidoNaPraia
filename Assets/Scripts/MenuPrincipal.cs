using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {
    public GameObject painel;

    void Start(){
        painel.SetActive(false);
    }

    public void Configuracao()
    {
        painel.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(Volta());
    }

    public void IniciarJogo()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
        gameObject.GetComponent<AudioSource>().Play();
    }

    public void TerminarJogo()
    {
        gameObject.GetComponent<AudioSource>().Play();
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(4f);
        painel.SetActive(false);
    }
}
