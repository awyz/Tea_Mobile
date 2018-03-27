using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Timer());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds (3.0f);
		SceneManager.LoadScene ("PinguinoHealth");
	}
}
