using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipesgenerator : MonoBehaviour {
    public GameObject piep;
	public Vector3 pos;
	// Use this for initialization
	void Start () {
		StartCoroutine(generatorpipes());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator generatorpipes()
	{   while(true){
		yield return new WaitForSeconds(4f);
		float randy = Random.Range(-1f,3.5f);
		pos = new Vector3(4f,randy,0);
		Instantiate(piep,pos,Quaternion.identity);
	}
	}
}