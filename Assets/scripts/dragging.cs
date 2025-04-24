using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class dragging : MonoBehaviour
{ public bool draging;
   public points currentpoints;
  public bool placed;
private Vector3 originalpos,offset;

public bool[] allboolidean = new bool[5];
public float rad;

public LayerMask lm;
private Transform nearestslot;
//public GameObject gamemanager;
    void Awake()
    {
         originalpos = transform.position;
        
         

        // if(allboolidean.Any(a=>a == true))
        // {
        //   print("You win");
        // }


    }
    void Start()
    {
    }
    private void Update() {

      if(Input.GetKeyDown(KeyCode.LeftArrow) && currentpoints.left != null)
       {
        
        

         transform.position= currentpoints.left.transform.position;
         currentpoints = currentpoints.left;
       }

       else if(Input.GetKeyDown(KeyCode.RightArrow) && currentpoints.right != null)
       {
         transform.position= currentpoints.right.transform.position;
         currentpoints = currentpoints.right;
       }

       else if(Input.GetKeyDown(KeyCode.UpArrow) && currentpoints.up != null)
       {
         transform.position= currentpoints.up.transform.position;
         currentpoints = currentpoints.up;
       }
       else if(Input.GetKeyDown(KeyCode.DownArrow) && currentpoints.down != null)
       {
         transform.position= currentpoints.down.transform.position;
         currentpoints = currentpoints.down;
       }


       if(Input.GetKeyDown(KeyCode.Space))
       {
        
          Collider2D coll = Physics2D.OverlapCircle(transform.position,rad,lm);

          if(coll != null)
          {
              print(coll.name);
          }
          if(coll == null)
          {
            print("No Object FOund");
          }

        // foreach(bool a in allboolidean)
        //  {
        //     if(a == true)
        //     {
              
        //       print("YOu Win");
        //       break;
        //     }
            
        //  }
       }


    if(!draging) return;
    {
       var mousepos = getmousepos();
       transform.position = mousepos - offset;

       
    }

    
  }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position,rad);
    }
    private void OnMouseDown() {
        draging = true;
        offset = getmousepos() - transform.position;

    }
     private void OnMouseUp() {
       nearestslot = findnerestslot();
       if(nearestslot != null && Vector2.Distance(transform.position,nearestslot.position)< 1.5f && nearestslot.name == gameObject.name)
       {
         transform.position = nearestslot.position;
         if (!placed)
         {
          FindObjectOfType<gamemanage>().slotsfilled();
          placed = true;
          
         }
         
       }
       else
       {
        transform.position = originalpos;
       }
       draging = false;
    }
      
    
    Vector3 getmousepos()
    {
        Vector3 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseposition.z = 0f;
        return mouseposition;
    }
    Transform findnerestslot()
    {
      GameObject[] slots = GameObject.FindGameObjectsWithTag("slot");
      Transform nearst = null;
      float mindistant = Mathf.Infinity;

      foreach(GameObject slot in slots)
      {
        float dist = Vector2.Distance(transform.position,slot.transform.position);
        if(dist < mindistant)
        {
          mindistant = dist; 
          nearst = slot.transform;
        }
      }
      return nearst;
    }
    /*void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("slot"))
    {
      Debug.Log("tiggered");
        FindObjectOfType<gamemanage>().winfunction();
    }
}*/
    

}
