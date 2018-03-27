using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGuy : MonoBehaviour {
		
		public int damage = 100;
		public Rigidbody theBullet;

		// Update is called once per frame
		void Update () {

			RaycastHit hit = new RaycastHit();
			Ray ray = Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0));

			if(Input.GetMouseButtonDown(0))
			{
			Rigidbody clone = Instantiate (theBullet, transform.position, transform.rotation);
			clone.AddForce(transform.forward * 200);
			Destroy (clone.gameObject, 3);
			}
		}
	}﻿