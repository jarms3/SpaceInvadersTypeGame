using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shieldy : MonoBehaviour {

	public float rotationsPerSecond = 0.1f;
	public int levelShown = 0;
	Material mat;
	// Use this for initialization
	void Start () {
		mat = GetComponent<Renderer> ().material;
	}
	
	// Update is called once per frame
	void Update () {
		int currLevel = Mathf.FloorToInt (ShipBehaviour.S.shieldLevel);
		if (levelShown != currLevel) {
			levelShown = currLevel;
			mat.mainTextureOffset = new Vector2 (0.2f * levelShown, 0);
		}
	}

	void OnTriggerEnter(Collider other) {

		// Otherwise announce the original other.gameObject
		Debug.Log("Triggered: " + other.gameObject.name);
	}
}
