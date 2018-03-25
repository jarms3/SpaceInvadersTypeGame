using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
	static public ShipBehaviour S;
	public float speed = 30;
	public float rotate1 = 45;
	public float rotate2 = -30;
	public float _shieldLevel = 1;
	public GameObject projectilePrefab;
	public float projectileSpeed = 40;
	public GameObject lastTriggerGo;
	// Use this for initialization
	void Start ()
	{
		if (S == null) {
			S = this;
		} else {
			Debug.LogError ("Cant do two ships man");
		}
		gameObject.transform.eulerAngles = new Vector3(
			gameObject.transform.eulerAngles.x + 90,
			gameObject.transform.eulerAngles.y + 90,
			gameObject.transform.eulerAngles.z
		);
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

		//float xAxis = 0f;		
		//float yAxis = 0f;

		Vector3 move = transform.position;

		move.x += xAxis * speed * Time.deltaTime;
		move.y += yAxis * speed * Time.deltaTime;
		transform.position = move;

		transform.rotation = Quaternion.Euler ((yAxis * rotate2*-1)-90, (xAxis * rotate1), 0);
		if (Input.GetKeyDown(KeyCode.Space) ){
			TempFire ();
		}
	}
	void TempFire(){
		GameObject projGO = Instantiate<GameObject> (projectilePrefab);
		projGO.transform.position = transform.position;
		Rigidbody rigidB = projGO.GetComponent<Rigidbody> ();
		rigidB.velocity = Vector3.up * projectileSpeed;
	}

	void OnTriggerEnter(Collider other) {
		Transform rootT = other.gameObject.transform.root;
		GameObject go = rootT.gameObject;

		if (go == lastTriggerGo){
			return;
	}
		lastTriggerGo = go;

		if (go.tag == "Enemy") {
			shieldLevel--;
			Destroy (go);
		}
		else{
			// Otherwise announce the original other.gameObject
		print("Triggered: " + other.gameObject.name);
	}
	}

	public float shieldLevel {
		get {
			return (_shieldLevel);
		}
		set {
			_shieldLevel = Mathf.Min (value, 4);
			if (value < -1) {
				Destroy (this.gameObject);
			}
		}
	}
}

