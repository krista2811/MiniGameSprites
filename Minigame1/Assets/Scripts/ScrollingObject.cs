using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		rb2d.velocity = new Vector2 (GameControl.instance.scrollSpeed, 0);
        //if isjump, scroll velocity will be higher.
	}
	
	// Update is called once per frame
	void Update () {
		//if game is over
		if (GameControl.instance.game1Over == true && GameControl.instance.game2Over == true) {
			rb2d.velocity = Vector2.zero;
		}
	}
}
