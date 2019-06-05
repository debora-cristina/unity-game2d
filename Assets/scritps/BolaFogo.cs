using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaFogo : MonoBehaviour
{

    private Rigidbody2D rigidBody2D;
    private float posicaoY = 0f;

    // Use this for initialization
    /* Aqui estamos dizendo que depois que este objeto foi criado(Start),
     ele será destruído em 2 segundos(Destroy) e que assim que for criado(Start), 
     ele irá da um salto(rigidbody2D.AddForce). O 2f, é equivalente aos segundos de atraso para objeto ser destruído e 
    o 400f, é o equivalente a força do pulo.Caso você queira controlar isto fora do script, basta criar as variáveis public para fazer essas funções.
     */
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2f);

        rigidBody2D.AddForce(transform.up * 400f);
        //só temos agora que fazer nossa bola de fogo, mudar de direção, quando estiver caindo.
        posicaoY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (posicaoY > transform.position.y)
        { //Descendo
            transform.eulerAngles = new Vector2(180, 0);
        }
        posicaoY = transform.position.y;
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {
            var player = colisor.gameObject.GetComponent<Player>();
            player.PerdeVida(10);
        }
       

    }
}
