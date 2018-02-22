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
		if (gameObject.transform.position.x < -Camera.main.orthographicSize + 13f)
			gameObject.transform.position = new Vector3(-28, gameObject.transform.position.y, 0);
		else if(gameObject.transform.position.x > Camera.main.orthographicSize - 13f)
			gameObject.transform.position = new Vector3(28, gameObject.transform.position.y, 0);
		else if(gameObject.transform.position.y < -Camera.main.orthographicSize + 2f)
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, -35, 0);
		else if(gameObject.transform.position.y > Camera.main.orthographicSize - 2f)
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, 35, 0);
		
		float xAxis = Input.GetAxis ("Horizontal");
		float yAxis = Input.GetAxis ("Vertical");

		Vector3 move = transform.position;

		move.x += xAxis * speed * Time.deltaTime;
		move.y += yAxis * speed * Time.deltaTime;
		transform.position = move;

		transform.rotation = Quaternion.Euler (yAxis * rotate2, xAxis * rotate1, 0);
		
	}
}
