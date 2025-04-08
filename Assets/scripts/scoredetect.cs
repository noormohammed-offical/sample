using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoredetect : MonoBehaviour {
     public bird birds;
	// Use this for initialization
	private void Start() 
	{
		 birds = GameObject.Find("bird").GetComponent<bird>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player")
		{
          birds.updatescore();
		}
	}
}
