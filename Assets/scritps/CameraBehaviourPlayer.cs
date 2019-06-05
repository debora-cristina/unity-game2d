using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviourPlayer : MonoBehaviour
{

    private Vector2 velocity;

    public float delayX;
    public float delayY;

    public Transform player;

    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }


    void FixedUpdate()
    {
        float posX = Mathf.SmoothDamp(transform.position.x,
        player.position.x, ref velocity.x, delayX);
        float posY = Mathf.SmoothDamp(transform.position.y,
        player.position.y, ref velocity.y, delayY);

        transform.position = new Vector3(posX, posY, transform.position.z);
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
            Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
            Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

        }
    }

}
