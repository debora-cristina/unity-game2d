using UnityEngine;
using System.Collections;
public class Cogumelo : MonoBehaviour
{
    public float forcaPulo = 500f;
    private bool pulo = false;
    // Use this for initialization
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
    }
    void OnCollisionStay2D(Collision2D colisor)
    {

        if (!pulo)
        {
            Debug.Log("colidiu");
            colisor.rigidbody.AddForce(transform.up * forcaPulo);
            pulo = true;
        }

    }
    void OnCollisionExit2D(Collision2D colisor)
    {
        pulo = false;

        Debug.Log("Saiu");
        Debug.Log(forcaPulo);

    }
}