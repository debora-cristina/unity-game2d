using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamasAzuis : MonoBehaviour {

    public float velocidade;
    public int dano;

    // Use this for initialization
    void Start()
    {
        //Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            var player = colisor.gameObject.transform.GetComponent<Player>();
            player.PerdeVida(dano);
        }

        //Destroy(gameObject);
    }
}
