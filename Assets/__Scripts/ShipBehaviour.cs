using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
	public float speed = 30;
	public float rotate1 = -45;
	public float rotate2 = 30;

	// Use this for initialization
	void Start ()
	{
		
	}
	// Update is called once per frame
	void Update () 
	{
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp(pos.x, 0.04f, 0.96f);
		pos.y = Mathf.Clamp(pos.y, 0.04f, 0.96f);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
		
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 move = transform.position;

		move.x += xAxis * speed * Time.deltaTime;
		move.y += yAxis * speed * Time.deltaTime;
		transform.position = move;

		transform.rotation = Quaternion.Euler ((yAxis * rotate2) - 90, xAxis * rotate1, 0);
		
	}
}
