using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bandeira : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D colisor)
    {
        Debug.Log("acabou fase 1");
        if (colisor.gameObject.tag == "Player")
        {
            Debug.Log("acabou fase 1");
            SceneManager.LoadScene("scene_2");
        }
    }
}
