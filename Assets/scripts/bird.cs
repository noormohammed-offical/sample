using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class bird : MonoBehaviour {
	public Text scoretext;
	public List<GameObject> spawnedPipess;
	public float score;
     private  Rigidbody2D rb;
	 public float jumpfroce;
	// Use this for initialization
	void Start () {
		score = 0f;
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.X))
		{
          rb.velocity = new Vector2(rb.velocity.x,jumpfroce);
		}
	}
	 void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "pipe")
		{
			spawnedPipess = GameObject.FindGameObjectsWithTag("pipe").ToList();
			foreach(GameObject s in spawnedPipess)
			 	Destroy(s);
				spawnedPipess.Clear();
				score = 0;
				scoretext.text = score.ToString();
		}
	}
	public void updatescore()
	{
		print("Func Called");
		score +=1;
		scoretext.text = score.ToString();
	}
}
