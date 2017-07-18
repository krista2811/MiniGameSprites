﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {

	private BoxCollider2D groundCollider;
	private float groundHorizontalLength; //store the x position

	// Use this for initialization
	void Awake () {
		groundCollider = GetComponent<BoxCollider2D> ();
		groundHorizontalLength = groundCollider.size.x; //get size of the collider.
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -groundHorizontalLength) {
			RepositionBackground ();
		}
	}

	private void RepositionBackground (){
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2f, 0);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
