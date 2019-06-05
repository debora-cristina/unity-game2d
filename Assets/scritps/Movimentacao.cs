using UnityEngine;
using System.Collections;

public class Movimentacao : MonoBehaviour
{

    public float velocidade;
    public float duracaoPosicao;
    private float tempo;
    public bool posicao;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Aumenta o tempo que esta na posicaçao atual
        tempo += Time.deltaTime;

        //Se o tempo 
        if (tempo >= duracaoPosicao)
        {
            //Zera contagem
            tempo = 0;

            //Muda a posiçao
            if (posicao)
            {
                posicao = false;
            }
            else
            {
                posicao = true;
            }
        }
        //movimenta
        if (posicao)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
        }
        else
        {
            transform.Translate(-Vector2.right * velocidade * Time.deltaTime);
        }


    }

    void OnCollisionStay2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            colisor.gameObject.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D colisor)
    {
        if (colisor.gameObject.name == "Player")
        {
            colisor.gameObject.transform.parent = null;
        }
    }
}