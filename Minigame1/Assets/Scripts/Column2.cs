using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column2 : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Bird>() != null)
        {
            if (other.GetComponent<Bird>().tag == "Player1")
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                other.GetComponent<Animator>().SetTrigger("die");
                GameControl.instance.Bird1Died();
            }
        }
        if (other.GetComponent<Bird2>() != null)
        {
            for (int i = 0; i < 10; i++)
            {
                GameControl.instance.Bird2Scored();
            }

        }
    }
}

