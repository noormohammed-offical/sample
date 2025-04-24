using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class dragging : MonoBehaviour
{
    public bool draging;
     private Vector3 offset, originalpos;
     private Transform nearslot;

    // Update is called once per frame
    void Awake()
    {
        originalpos = transform.position;
    }
    void Update()
    {
        if(!draging)return;

        var mousepos = funmousepos();
        transform.position = mousepos - offset;
    }
    void OnMouseDown()
    {
        draging = true;
        offset = funmousepos() - (Vector3)transform.position;
    }
    private void OnMouseUp() {
     
       if(Vector2.Distance(transform.position,)< 3)
       {

       }
         transform.position = originalpos;
        draging = false;

        
    }
    Vector3 funmousepos()
    {
       return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    Transform findnearsetslot()
    {
        GameObject[] slots = GameObject.FindGameObjectWithTag("slot");
        Transform nearest = null;
        float mindistant = Mathf.Infinity;

        foreach(GameObject slot in slots)
        {
           float dist = Vector2.Distance(transform.position,slot.transform.position);
           if(dist < mindistant)
           {
             mindistant = dist;
             nearest = slot.transform;
           }
        }
        return nearest;
    }
}*/
public class dragging : MonoBehaviour
{
    public bool draging;
    private Vector3 offset, originalpos;
    private Transform nearestSlot;

    void Awake()
    {
        originalpos = transform.position;
    }

    void Update()
    {
        if (!draging) return;

        var mousepos = GetMouseWorldPosition();
        transform.position = mousepos - offset;
    }

    void OnMouseDown()
    {
        draging = true;
        offset = GetMouseWorldPosition() - transform.position;
    }

    private void OnMouseUp()
    {
        nearestSlot = FindNearestSlot();

        if (nearestSlot != null && Vector2.Distance(transform.position, nearestSlot.position) < 1.5f)
        {
            transform.position = nearestSlot.position;
        }
        else
        {
            transform.position = originalpos;
        }

        draging = false;
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Ensure it's on the same plane
        return mousePos;
    }

    Transform FindNearestSlot()
    {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("slot");
        Transform nearest = null;
        float minDistance = Mathf.Infinity;

        foreach (GameObject slot in slots)
        {
            float dist = Vector2.Distance(transform.position, slot.transform.position);
            if (dist < minDistance)
            {
                minDistance = dist;
                nearest = slot.transform;
            }
        }

        return nearest;
    }
}

