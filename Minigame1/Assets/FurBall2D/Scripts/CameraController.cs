﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	public Transform Player;
	public float m_speed = 0.1f;
	Camera mycam;

	public void Start()
	{
		mycam = GetComponent<Camera> ();
	}

	public void Update()
	{

		//mycam.orthographicSize = (Screen.height / 100f) / 0.7f;

		if (Player) 
		{
            transform.position = new Vector3(Player.position.x, 0, -10);
		}


	}
}
