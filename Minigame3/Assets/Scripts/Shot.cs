using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    public float vanishRate = 3;

    private Rigidbody2D rb2d;
    private float remainTime;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        remainTime = 3;
	}
	/*
	// Update is called once per frame
	void Update () {
        if (Time.time > remainTime)
        {
            remainTime = Time.time + vanishRate;
            //Destroy(gameObject);
        }

    }
    */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Boss>())
        {
            GameController.instance.bossHit();
            this.gameObject.SetActive(false);
        }
    }

}
