using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    float[] rotation = {0,90,180,270};

    void Start()
    {    int rand = Random.Range(0,rotation.Length);
        transform.eulerAngles = new Vector3(0,0,rotation[rand]);
    }
    void OnMouseDown()
    {
        transform.Rotate(new Vector3(0,0,90));
    }
}
