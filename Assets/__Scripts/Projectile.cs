using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	public BoundsCheck bndCheck;
	public Rigidbody rigid;



	void Awake (){

		bndCheck = GetComponent<BoundsCheck> ();
		rigid = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		/*if (bndCheck.LetsGo) {
			Destroy (this.gameObject);
		}*/



	}
	void OnCollisionEnter (Collision coll) {

		GameObject otherGO = coll.gameObject;
		if (otherGO.tag == "Enemy") {
			Destroy (otherGO);
			Destroy (gameObject);

		} else {
			print ("Enemy hit by non-ProjectileHero: " + otherGO.name);
		}

	}


		
}
