using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour 
{
	public bool LetsGo = false;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	public void Update () 
	{
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);

		if (pos.x < 0.0 || pos.x > 1.0 || pos.y < 0.0 || pos.y > 1.0)
		{
			LetsGo = true;
		}
	}
}
