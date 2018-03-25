using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : Main 
{

	public float speed = 0.0001f;
	public float i = 0;
	public int random;
	GameObject holder;
	// Use this for initialization
	void Start () 
	{
		random = Random.Range (0, 2);
	}
	
	// Update is called once per frame
	void Update () 
	{
		i = i + 0.5f;

		if (random == 1) 
		{
			gameObject.transform.position = new Vector3 (i * speed, -i * speed, 0) + gameObject.transform.position;
			gameObject.transform.rotation = Quaternion.Euler (-60, 80, -80);
		}
		else 
		{
			gameObject.transform.position = new Vector3 (-i * speed, -i * speed, 0) + gameObject.transform.position;
			gameObject.transform.rotation = Quaternion.Euler (47, 90, -95);
		}
			
		if (gameObject.GetComponent<BoundsCheck> ().LetsGo && this.gameObject.tag == "Enemy") 
		{
			Destroy (this.gameObject);
		}

	}
}