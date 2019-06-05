using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour {

    public Texture2D titulo;
    public float duracao;
    private float contagem;
    private GUIStyle fonte;
    // Use this for initialization
    void Start () {
        fonte = new GUIStyle();
        fonte.fontSize = 20;
        fonte.normal.textColor = Color.gray;
    }
	
	// Update is called once per frame
	void Update () {
        contagem += Time.deltaTime;
        if (contagem >= duracao)
        {
            SceneManager.LoadScene(0);
        }
    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(225, 150, 150, 40), titulo);

        GUI.BeginGroup(new Rect(175, 200, 250, 150));
        GUI.Label(new Rect(0, 0, 150, 20), "Tutorial de Unity 2D", fonte);
        GUI.Label(new Rect(0, 30, 150, 20), "Criador: Carlos W. Gama", fonte);
        GUI.Label(new Rect(0, 60, 150, 20), "Jogos Indie", fonte);
        GUI.EndGroup();
    }
}
