using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenPool : MonoBehaviour {

    public float poolTime;
    public float deltaPool;
    public GameObject PenPrefab;
    public float xMin, xMax;
    public float yMin, yMax;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > poolTime)
        {
            poolTime = Time.time + deltaPool;
            float xPosition = Random.Range(xMin, xMax);
            float yPosition = Random.Range(yMin, yMax);

            Instantiate(PenPrefab, new Vector2(xPosition, yPosition), Quaternion.identity);
        }
	}
}
