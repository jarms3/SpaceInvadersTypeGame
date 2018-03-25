using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
	public GameObject enemy1;
	public GameObject enemy2;
	public int rand;
	public int rand2;
	public int count;
	float camWidth;
	float camHeight;

	public enum WeaponType
	{
		simple,
		blaster,
		rockets
		
	}
	// Use this for initialization
	void Start () 
	{
		
		camWidth = Camera.main.pixelWidth;
		camHeight = Camera.main.pixelHeight;
		StartEnemies ();
	}


	// Update is called once per frame
	void Update () 
	{
		count++;

		if (count % 200 == 0)
			StartEnemies ();
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

	public void Weapon(WeaponType weap)
	{
		/*switch (weap) 
		{
			case WeaponType.simple
			{
				
			}
		}*/
	}


}
