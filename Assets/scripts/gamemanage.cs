using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanage : MonoBehaviour
{
    public GameObject youwintext;
    public int slotfilled = 0;
    public int totalslot = 2;
    public dragging draging;
    public void slotsfilled()
    {
       slotfilled++;
       if(slotfilled >= totalslot)
       {
        winfunction();
        
       }
    }
    public void winfunction()
    {
        youwintext.SetActive(true);
        
    }
}
