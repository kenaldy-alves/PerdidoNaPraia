﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Termina : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "crianca") {
            SceneManager.LoadSceneAsync("Fim", LoadSceneMode.Single);
        }
    }
}
