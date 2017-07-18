using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

	/**
	 * isDead
	 */
	private bool isDead = false;
	private Rigidbody2D rb2d;
	public float upForce = 50;
	private Animator anim;
    private bool isJumping = false;

	// Use this for initialization
	void Start ()
    {
		rb2d = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isDead == false && GameControl.instance.game1Over == false)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (Input.GetKey(KeyCode.UpArrow))
            {
                isJumping = true;
			}
		}
        rb2d.constraints = RigidbodyConstraints2D.None;
    }

    private void FixedUpdate()
    {
        Jump();
    }
    void Jump()
    {
        if (!isJumping)
            return;
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(new Vector2(0, upForce));
        anim.SetTrigger("Flap");
        isJumping = false;
    }
	void OnCollisionEnter2D (Collision2D col)
    {
        if(col.gameObject.tag != "Player2" && col.gameObject.tag != "Coin") {
            rb2d.velocity = Vector2.zero;
		    isDead = true;
            GameControl.instance.game1Over = true;
            anim.SetTrigger ("die");
		    GameControl.instance.Bird1Died ();
        }

	}
}
