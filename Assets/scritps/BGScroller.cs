using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float speed = 0; // velocidade fundo se move pro lado oposto do nosso jogador
    private Material mat;
    private GameObject pl;

    private float pos = 0;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
        pl = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        var vel = pl.GetComponent<Rigidbody2D>().velocity.x;

        if (vel != 0f)
        {
            var side = pl.transform.localScale.x;
            pos += speed * side;
            mat.mainTextureOffset = new Vector2(pos, 0);
        }
    }
}
