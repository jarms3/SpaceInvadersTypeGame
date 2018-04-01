using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Weapon : MonoBehaviour {


	public GameObject projectilePrefab;
	public float projectileSpeed = 40;
	public float delayTime = 0.2f;
	public float shotDelay = 0;




	// Use this for initialization
	void Start () {

		GameObject rootGO = transform.root.gameObject;

		if (rootGO.GetComponent<ShipBehaviour> () != null) 
		{
			rootGO.GetComponent<ShipBehaviour> ().fireDelegate += Fire;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Fire()
	{

		Projectile p;
		Vector3 v = Vector3.up * 50;
		GameObject enemy0 = GameObject.Find ("Enemy_0(Clone)");
		GameObject enemy1 = GameObject.Find ("Enemy_1(Clone)");

		switch (Main.s._type) 
		{
			case WeaponType.simple:
			{
				p = makeProjectile();
				p.rigid.velocity = v;
				break;
			}
			case WeaponType.blaster:
			{
				p = makeProjectile ();
				p.rigid.velocity = v;
				p = makeProjectile ();
				p.transform.rotation = Quaternion.AngleAxis (30, Vector3.back);
				p.transform.position = p.transform.position + new Vector3 (0.4f, 0, 0);
				p.rigid.velocity = p.transform.rotation * v;
				p = makeProjectile ();
				p.transform.rotation = Quaternion.AngleAxis (-30, Vector3.back);
				p.transform.position = p.transform.position + new Vector3 (-0.4f, 0, 0);
				p.rigid.velocity = p.transform.rotation * v;
				break;
			}
			case WeaponType.explosion:
			{
				
				if (enemy0 != null)
					Destroy (enemy0);
				if (enemy1 != null)
					Destroy (enemy1);
				break;
			}
			case WeaponType.seeker:
			{
				Transform target;

				if (enemy0.transform.position.y < enemy1.transform.position.y)
					target = enemy0.transform;
				else
					target = enemy1.transform;

				break;
			}
		}
	}


	public Projectile makeProjectile()
	{
		GameObject go = Instantiate (projectilePrefab);
		go.transform.position = gameObject.transform.position;
		Projectile p = go.GetComponent<Projectile> ();

		return(p);
	}

}
