using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject pickup1;
	public GameObject pickup2;
	public int rand;
	public int rand2;
	public int rand3;
	public int rand4;
	float camWidth;
	float camHeight;
	// Use this for initialization
	void Start () 
	{
		rand = Random.Range (-28, 28);
		rand2 = Random.Range (-28, 28);
		rand3 = Random.Range (-28, 28);
		rand4 = Random.Range (-28, 28);
		camWidth = Camera.main.pixelWidth;
		camHeight = Camera.main.pixelHeight;
		StartEnemies ();
	}


	// Update is called once per frame
	void Update () 
	{

	}

	public void StartEnemies()
	{
		GameObject gObj1 = Instantiate<GameObject> (pickup1);
		GameObject gObj2 = Instantiate<GameObject> (pickup2);
		gObj1.transform.position = new Vector3(rand, 35f, 0f);
		gObj1.transform.rotation = Quaternion.Euler (90, -90, 90);
		gObj2.transform.position = new Vector3(rand2, 35f, 0f);
	}

	void OnDrawGizmos ()
	{
		if (!Application.isPlaying) return;
		Vector3 boundSize = new Vector3(camWidth* 2, camHeight* 2, 0.1f); 
		Gizmos.DrawWireCube(Vector3.zero, boundSize);
	}

}
