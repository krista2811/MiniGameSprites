﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineAttack : MonoBehaviour {

    public float downSpeed;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, -downSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		//ifgameover -> zero;
	}
}
