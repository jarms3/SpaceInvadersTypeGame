using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy0Movement : Main {

	public float speed = 0.1f;
	public static int counter = 0;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 move = Vector3.zero;

		move = Vector3.down;

		gameObject.transform.position = move * speed + gameObject.transform.position;

		if (gameObject.GetComponent<BoundsCheck> ().LetsGo && this.gameObject.tag == "StrongEnemy") 
		{
				
			counter++;
			print (counter);
			Destroy (this.gameObject);
			Projectile.chub = 0;
		}

	}
}

