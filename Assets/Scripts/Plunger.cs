using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour {
	public GameObject target; // Pengy
	public bool ret = false;
	public float step = 0.8f;
	public bool comeBack = false;
	public int counter = 0;

	// Use this for initialization
	void Start () {
		// Finds all entities labeled as Pengy
		target = GameObject.Find("Pengy");
	}
	
	// Update is called once per frame
	void Update () {
		if (ret) { // Hit pengy
			transform.position = Vector3.MoveTowards (transform.position, target.transform.position, step);
		} 
		else 
		{
			// Missed pengy
			this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
			counter++;
		}
		if (counter == 2) 
		{
			this.gameObject.GetComponent<Rigidbody> ().AddForce (transform.forward * (-200));	
		}
	}

	public void OnCollisionEnter(Collision col)
	{
		// Brings plunger back
		if (col.gameObject.CompareTag("Pengy"))
		{
			ret = true;
			// move plunger and pengy back
			this.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (-200));
			col.gameObject.GetComponent<Rigidbody>().AddForce(transform.forward * (-200));
		}
	}

}
