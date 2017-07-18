using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingColumns : MonoBehaviour
{

    private Rigidbody2D Column;
    private float groundHorizontalLength; //store the x position

    // Use this for initialization
    void Awake()
    {
        Column = GetComponent<Rigidbody2D>();
        groundHorizontalLength = 20.48f; //get size of the collider.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -12)
        {
            RepositionBackground();
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}