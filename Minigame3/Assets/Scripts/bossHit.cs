using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHit : MonoBehaviour {

    public AudioClip shotSound;

    private Animator anim;
    private Rigidbody2D rb2d;
    private AudioSource shot;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        shot = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "attack")
        {
            if (GameController.instance.BossHp > 0)
            {
                float vol = 1.0f;
                shot.PlayOneShot(shotSound, vol);
                anim.SetTrigger("hit");
                GameController.instance.bossHit();
            }
            else
            {
                GameController.instance.win = true;
                GameController.instance.Win();
                rb2d.constraints = RigidbodyConstraints2D.None;
            }
        }
    }
}
