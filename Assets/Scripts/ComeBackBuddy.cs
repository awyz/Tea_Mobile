using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComeBackBuddy : MonoBehaviour {
	public GameObject target;
	private bool amWalking;
	private bool amFlying;
	private bool killMe;
	private bool amCaptured;
	public float step = 0.8f;
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Target");
	}

	void Awake()
	{
		amWalking = false;
		amFlying = false;
		amCaptured = false;
		killMe = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (amCaptured)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
		}

		if (amWalking)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.1f);
		}

		if (amCaptured)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.4f);
		}

		if (killMe)
		{
			transform.position = new Vector3(0, -50, 0);
			if (transform.position.y <= -10)
				Destroy(this.gameObject);
		}

	}

	public void OnTriggerEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy(other.gameObject);
		}
	}

	public void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{

			killMe = true;
			//Debug.Log("GONE");

			//this.GetComponent<MeshRenderer>().enabled = false;
			Destroy(this.gameObject);
		}
		if (col.gameObject.tag == "Plunger")
		{
			amCaptured = true;
		}
		//Debug.Log(col.gameObject.name);
		if (col.gameObject.tag == "Enemy" && !amCaptured)
		{
			Destroy(col.gameObject);
			amFlying = true;
		}
		if (col.gameObject.tag == "ground" && !amCaptured && !amWalking)
		{
			amWalking = true;
			//Debug.Log(col.gameObject.name);
			//transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
		}

	}
}
