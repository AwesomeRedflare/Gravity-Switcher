using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;

    public bool horizontal;
    public bool vertical;

    public float xOffSet;
    public float yOffSet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        float x;
        float y;

        if(horizontal == true)
        {
            x = player.position.x;
        }
        else
        {
            x = transform.position.x;
        }

        if (vertical == true)
        {
            y = player.position.y;
        }
        else
        {
            y = transform.position.y;
        }

        transform.position = new Vector3(x + xOffSet, y + yOffSet, transform.position.z);
    }
}
