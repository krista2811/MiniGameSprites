using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackHit : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player1")
        {
            GameController.instance.player1Hit();
        }
        if(collision.gameObject.tag == "Player2")
        {
            GameController.instance.player2Hit();
        }
    }
}
