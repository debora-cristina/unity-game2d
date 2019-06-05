using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour {

    public float velocidade;
    public bool direcao;
    public float duracaoDirecao;

    private float tempoNaDirecao;
    private Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (direcao)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
        }
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);

        tempoNaDirecao += Time.deltaTime;
        if (tempoNaDirecao >= duracaoDirecao)
        {
            tempoNaDirecao = 0;
            direcao = !direcao;
        }
    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Player")
        {

            gameObject.GetComponent<AudioSource>().Play();

            Debug.Log("encostou");
            animator.SetTrigger("atacou");

            var player = colisor.gameObject.transform.GetComponent<Player>();
            player.PerdeVida(30);

            colisor.gameObject.transform.Translate(-Vector2.right);

        }

    }
}
