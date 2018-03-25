using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	private BoundsCheck bndCheck;


	void Awake (){

		bndCheck = GetComponent<BoundsCheck> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		if (bndCheck.LetsGo) {
			Destroy (gameObject);
		}

	}
	void OnCollisionEnter (Collision coll) {

		Debug.Log ("Enter called");

		print ("Collision");

		GameObject otherGO = coll.gameObject;
		if (otherGO.tag == "Enemy") {
			Destroy (otherGO);
			Destroy (gameObject);

		} else {
			print ("Enemy hit by non-ProjectileHero: " + otherGO.name);
		}

	}
}
