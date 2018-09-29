using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reinicio : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Volta());
    }

    IEnumerator Volta()
    {
        yield return new WaitForSeconds(5f);
        PlayerPrefs.DeleteAll();
        SceneManager.LoadSceneAsync("MenuPrincipal", LoadSceneMode.Single);

    }
}
