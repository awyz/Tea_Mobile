using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Healthy : MonoBehaviour {
	public Transform target;
	private float speed = 3.0f;

	public AudioClip music;
	public AudioSource source;
	private float volume = 1.0f;

	private int life = 5;
	public SpriteRenderer five;
	public SpriteRenderer four;
	public SpriteRenderer three;
	public SpriteRenderer two;
	public SpriteRenderer one;
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		five = GameObject.Find("grey_p").GetComponent<SpriteRenderer>();
		four = GameObject.Find("red_p").GetComponent<SpriteRenderer>();
		three = GameObject.Find("green_p").GetComponent<SpriteRenderer>();
		two = GameObject.Find("blue_p").GetComponent<SpriteRenderer>();
		one = GameObject.Find("black_p").GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (life == 4)
		{
			five.enabled = false;
		}
		if (life == 3)
		{
			four.enabled = false;
		}
		if (life == 2)
		{
			three.enabled = false;
		}
		if (life == 1)
		{
			two.enabled = false;
		}
		if (life == 0)
		{
			one.enabled = false;
			SceneManager.LoadScene("GameOver");
		}
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			source.PlayOneShot(music);
			life = life - 1;
			Debug.Log(life);
			Destroy(other.gameObject);
		}
	}
}
