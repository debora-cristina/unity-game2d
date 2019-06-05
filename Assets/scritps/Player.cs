using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float velocidade;
    public float forcaPulo;
    public Rigidbody2D rb;
    private bool estaNoChao;
    public Transform chaoVerificador;
    public Transform spritePlayer;
    private Animator animator;


    //Vida
    public GameObject vida;
    public int maxVida;
    private int vidaAtual;

    //Ataque Especial
    public GameObject ataqueEspecial;
    public float duracaoAtaque;
    private float contagemAtaque;
    public bool ativarAnimacaoAtaque = false;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = spritePlayer.GetComponent<Animator>();

        //Vida
    
        vidaAtual = maxVida;
        Debug.Log(vidaAtual);
        vida = GameObject.Find("Vida");
        GUI.depth = 1;
        vida.GetComponent<GUIText>().font.material.color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;

    }

  

    // Update is called once per frame
    void Update()
    {
        Movimentacao();
        Ataque();
        //FixarPosicaoEixoZ();

    }

    void FixarPosicaoEixoZ()
    {
        Vector3 v3Position = spritePlayer.transform.position;
        v3Position.z = 0;
        spritePlayer.transform.position = v3Position;
    }

    void Movimentacao()
    {


        animator.SetFloat("movimento", Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
        animator.SetBool("chao", estaNoChao);
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetButtonDown("Jump"))
        {
            estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));
            Debug.Log(estaNoChao);
            Debug.Log(chaoVerificador);
            GetComponent<Rigidbody2D>().AddForce(transform.up * forcaPulo);
        }

    }

    public void PerdeVida(int dano)
    {
        vidaAtual -= dano;


        if (vidaAtual <= 0)
        {
            SceneManager.LoadScene("game_over");
        }

        if ((vidaAtual * 100 / maxVida) < 30)
        {
            vida.GetComponent<GUIText>().color = Color.red;
        }

        vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
        Debug.Log(vidaAtual);
    }

    public void RecuperaVida(int recupera)
    {
        vidaAtual += recupera;
        if (vidaAtual > maxVida)
        {
            vidaAtual = maxVida;
        }

        if ((vidaAtual * 100 / maxVida) >= 30)
        {
            vida.GetComponent<GUIText>().color = new Vector4(0.25f, 0.5f, 0.25f, 1f);
        }

        vida.GetComponent<GUIText>().text = "HP: " + vidaAtual + "/" + maxVida;
    }

    void Ataque()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            ativarAnimacaoAtaque = true;
            ataqueEspecial.SetActive(true);
            contagemAtaque = 0f;
            PerdeVida(20);
        }

        if (Input.GetButton("Fire1"))
        {
            ativarAnimacaoAtaque = true;
            contagemAtaque += Time.deltaTime;
            if (contagemAtaque >= duracaoAtaque)
            {
                ataqueEspecial.SetActive(false);
            }
        }

        if (Input.GetButtonUp("Fire1"))
        {
            ataqueEspecial.SetActive(false);
            ativarAnimacaoAtaque = false;
        }
    }
}
