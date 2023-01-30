using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    public GameObject player;

    private float xVelocity=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player)
        {
            Vector3 playerposition = player.transform.position;
            Vector3 cameraposition = transform.position;

            //cameraposition.x = playerposition.x;

            if (playerposition.x > cameraposition.x)
            {
                cameraposition.x = Mathf.SmoothDamp(cameraposition.x, playerposition.x, ref xVelocity, 0.5f);
            }

            if (playerposition.y > cameraposition.y)
            {
                cameraposition.y = Mathf.SmoothDamp(cameraposition.y, playerposition.y, ref xVelocity, 0.5f);
            }

            if (playerposition.y < cameraposition.y)
            {
                cameraposition.y = Mathf.SmoothDamp(cameraposition.y, playerposition.y, ref xVelocity, 0.0f);
            }


            transform.position = cameraposition;
        }
    }
}
