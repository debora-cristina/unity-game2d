using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour {

    public Texture2D background;
    public Texture2D titulo;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), background);
        GUI.DrawTexture(new Rect(225, 50, 150, 40), titulo);

        GUI.BeginGroup(new Rect(240, 150, 120, 120));
        GUI.Box(new Rect(0, 0, 120, 120), "Menu");
        if (GUI.Button(new Rect(20, 30, 50, 20), "Iniciar"))
        {
            SceneManager.LoadScene("scene_1");
        }
        if (GUI.Button(new Rect(20, 60, 70, 20), "Continuar"))
        {
            Debug.Log("Fica para o proximo tutorial de Save/Load");
        }
        if (GUI.Button(new Rect(20, 90, 50, 20), "Sair"))
        {
            Application.Quit();
        }
        GUI.EndGroup();


    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
