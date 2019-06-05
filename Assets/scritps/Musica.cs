
using UnityEngine;

public class Musica : MonoBehaviour {

    public Texture2D musicOn;
    public Texture2D musicOff;
    public bool ativo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ativo)
        {
            gameObject.GetComponent<AudioSource>().mute = false;
            GetComponent<GUITexture>().texture = musicOn;
        }
        else
        {
            gameObject.GetComponent<AudioSource>().mute = true;
            GetComponent<GUITexture>().texture = musicOff;
        }
    }

    void OnMouseDown()
    {
        ativo = !ativo;
    }

}
