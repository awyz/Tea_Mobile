using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject[] penguinTypes;

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawnP", 1.0f, 3.5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnP(){
		int spawnidx = Random.Range (0, spawnPoints.Length);
		int objectidx = Random.Range (0, penguinTypes.Length);
		Instantiate (penguinTypes [objectidx], spawnPoints [spawnidx].position, spawnPoints [spawnidx].rotation);
	}
}
