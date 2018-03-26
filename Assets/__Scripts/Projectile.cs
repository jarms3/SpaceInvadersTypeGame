using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	public BoundsCheck bndCheck;
	public Rigidbody rigid;
	//public int score;
	//public Text scoreText;
	public static int chub = 0;
	public int holder = 0;


	void Awake (){

		bndCheck = GetComponent<BoundsCheck> ();
		rigid = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		
		ShipBehaviour.S.scoreText.text = "Score: " + ShipBehaviour.S.score;
		ShipBehaviour.S.highScoreText.text = "Highscore: " + ShipBehaviour.highScore;

	}

	// Update is called once per frame
	void Update () {

		if (bndCheck.LetsGo) {
			Destroy (this.gameObject);
		}



	}
	void OnCollisionEnter (Collision coll) {

		holder = Enemy0Movement.counter;
		GameObject otherGO = coll.gameObject;
		if (otherGO.tag == "Enemy") {
			
			Destroy (otherGO);
			Destroy (gameObject);
			ShipBehaviour.S.score++;
			ShipBehaviour.S.scoreText.text = "Score: " + ShipBehaviour.S.score;
		} 
		if (otherGO.tag == "StrongEnemy"){
			chub++;
			ShipBehaviour.S.score++;
			ShipBehaviour.S.scoreText.text = "Score: " + ShipBehaviour.S.score;
			Destroy (gameObject);
			if (chub % 2 ==0 && chub!=0 && holder == Enemy0Movement.counter) {
				ShipBehaviour.S.score++;
				ShipBehaviour.S.scoreText.text = "Score: " + ShipBehaviour.S.score;
				Destroy (otherGO);
				chub = 0;
			}
		
				
			/*if (chub != 0) {
				
				Debug.Log ("titties");
				chub = 0;
				Destroy (otherGO);
				Destroy (gameObject);
			}
			if (gameObject != null) {
				Debug.Log ("boobies");
				Destroy (gameObject);
			}
			Debug.Log ("dicks");
			score++;
			chub++;

			*/
		}


		/*else {
			print ("The non-ProjectileHero that was hit was: " + otherGO.name);
			chub = 1;
			print ("Chub: " + chub);

		}
		//print ("Chub: " + chub);*/

	}


		
}
