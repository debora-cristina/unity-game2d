using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueEspecial : MonoBehaviour {
    Player player;
    public GameObject vida;
    // Use this for initialization
    void Start()
    {
        vida = GameObject.Find("Player");
        player = vida.GetComponent<Player>();
      
        GetComponent<Animator>().Stop();
        GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //var player = GetComponent<Player>();
        if(player.ativarAnimacaoAtaque)
        {
            GetComponent<Animator>().Play("ataque_especial");
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D colisor)
    {
        if (colisor.gameObject.tag == "Inimigo" && player.ativarAnimacaoAtaque)
        {
            Destroy(colisor.gameObject);
        }
    }
}
