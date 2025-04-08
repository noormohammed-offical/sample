using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipe : MonoBehaviour 
{

	// Use this for initialization
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.left *1 * Time.deltaTime);
		Destroy(gameObject,4f);
		
	}
}
