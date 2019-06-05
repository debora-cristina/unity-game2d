﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnBolaFogo : MonoBehaviour
{
    public GameObject objeto;
    public float tempoRespawn = 0f;
    private float tempoCorrido = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempoCorrido += Time.deltaTime;
        if (tempoCorrido >= tempoRespawn)
        {
            Instantiate(objeto, transform.position, objeto.transform.rotation);
            tempoCorrido = 0f;
        }
    }
}
