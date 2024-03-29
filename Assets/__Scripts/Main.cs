﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum WeaponType {none,simple,blaster,explosion,seeker};

public class Main : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	static public Main s;
	public Button simpleButton;
	public Button blasterButton;
	public Button explosiveButton;
	public Button seekerButton;
	public int rand;
	public int rand2;
	public int count;
	float camWidth;
	float camHeight;

	public WeaponType _type = WeaponType.simple;



	// Use this for initialization
	void Start () 
	{
		s = this;
		camWidth = Camera.main.pixelWidth;
		camHeight = Camera.main.pixelHeight;
		simpleButton.gameObject.SetActive(false);
		blasterButton.gameObject.SetActive (false);
		explosiveButton.gameObject.SetActive (false);
		seekerButton.gameObject.SetActive (false);
		StartEnemies ();
	}


	// Update is called once per frame
	void Update () 
	{
		count++;

		if (count % 200 == 0)
			StartEnemies ();

		if (Input.GetKey (KeyCode.E)) {
			simpleButton.gameObject.SetActive(true);
			blasterButton.gameObject.SetActive (true);
			explosiveButton.gameObject.SetActive (true);
			seekerButton.gameObject.SetActive (true);

		}
	}

	public void StartEnemies()
	{
		rand = Random.Range (-28, 28);
		rand2 = Random.Range (-28, 28);
		GameObject gObj1 = Instantiate<GameObject> (enemy1);
		GameObject gObj2 = Instantiate<GameObject> (enemy2);
		gObj1.transform.position = new Vector3(rand, 41f, 0f);
		gObj1.transform.rotation = Quaternion.Euler (90, -90, 90);
		gObj2.transform.position = new Vector3(rand2, 41f, 0f);
	}


	void OnDrawGizmos ()
	{
		if (!Application.isPlaying) return;
		Vector3 boundSize = new Vector3(camWidth* 2, camHeight* 2, 0.1f); 
		Gizmos.DrawWireCube(Vector3.zero, boundSize);
	}


	public void setSimple()
	{
		_type = WeaponType.simple;
		simpleButton.gameObject.SetActive(false);
		blasterButton.gameObject.SetActive (false);
		explosiveButton.gameObject.SetActive (false);
		seekerButton.gameObject.SetActive (false);
	}

	public void setBlaster()
	{
		_type = WeaponType.blaster;
		simpleButton.gameObject.SetActive(false);
		blasterButton.gameObject.SetActive (false);
		explosiveButton.gameObject.SetActive (false);
		seekerButton.gameObject.SetActive (false);
	}

	public void setExplosive()
	{
		_type = WeaponType.explosion;
		simpleButton.gameObject.SetActive(false);
		blasterButton.gameObject.SetActive (false);
		explosiveButton.gameObject.SetActive (false);
		seekerButton.gameObject.SetActive (false);
	}

	public void setSeeker()
	{
		_type = WeaponType.seeker;
		simpleButton.gameObject.SetActive(false);
		blasterButton.gameObject.SetActive (false);
		explosiveButton.gameObject.SetActive (false);
		seekerButton.gameObject.SetActive (false);
	}

	public void DelayedRestart(float delay){
		Invoke ("Restart", delay);
	}

	public void Restart(){
		Scene scene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (scene.name);

		if (ShipBehaviour.highScore < ShipBehaviour.S.score) {
			ShipBehaviour.highScore = ShipBehaviour.S.score;
			ShipBehaviour.highScoreText.text = "Highscore: " + ShipBehaviour.highScore;
		}
	}
}


