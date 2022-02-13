using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject explosionEffect;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Death"))
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Goal"))
        {
            FindObjectOfType<AudioManager>().Play("Win");

            FindObjectOfType<GameManager>().StartCoroutine("Goal");
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }

    public void Death()
    {
        FindObjectOfType<AudioManager>().Play("Death");

        FindObjectOfType<GameManager>().StartCoroutine("Death");
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
