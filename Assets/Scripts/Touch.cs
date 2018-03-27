using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{

	// Use this for initialization
	void Start()
	{

	}
	public GameObject particle;

	public int damage = 100;
	public Rigidbody[] theBullet;
	public double timeLimit = 1;
	public Transform target;
	public Rigidbody thePlunger;
	private int objectidx = 0;
	public Transform barrel;

	// Update is called once per frame
	void Update()
	{
		timeLimit -= Time.deltaTime;
		//Debug.Log(timeLimit);
		if (timeLimit <= 0 && Input.touchCount > 0)
		{
			//right screen action
			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
			var touch = Input.touches [0];

			// Right side stuffs
			if (touch.position.x > Screen.width/2)
			{
				Rigidbody clone = Instantiate(theBullet[objectidx], barrel.transform.position, transform.rotation);
				objectidx = (	objectidx + 1) % theBullet.Length;
				clone.AddForce(transform.forward * 200);
				System.Random rnd = new System.Random();
				int spin = rnd.Next(1, 5);
				int speedOfRot = 1000;
				if (spin == 1)
				{
					clone.AddTorque(transform.up * speedOfRot);
				}
				else if (spin == 2)
				{
					clone.AddTorque(transform.right * speedOfRot);
					clone.AddTorque(transform.up * speedOfRot);
				}
				else if (spin == 3)
				{
					clone.AddTorque(-transform.up * speedOfRot);
				}
				else
				{
					clone.AddTorque(-transform.right * speedOfRot);
					clone.AddTorque(-transform.up * speedOfRot);
				}
				//Destroy(clone.gameObject, 3);
				timeLimit = 1;
			}

			// Left screen action
			RaycastHit hit2 = new RaycastHit();
			Ray ray2 = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2 , Screen.height, 0));

			if(touch.position.x < Screen.width/2)
			{
				Rigidbody clone2 = Instantiate (thePlunger, thePlunger.transform.position, thePlunger.transform.rotation);
				// Shoots plunger forward
				clone2.AddForce(transform.forward * 50);

			}
		}
	}
		
}