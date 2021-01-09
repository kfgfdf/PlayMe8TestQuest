using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSlotsLeft : MonoBehaviour
{
    void OnTriggerStay2D (Collider2D other)
    {
        if(other.gameObject.tag == "Slot")
        {
           // _isEmptyLeft = true;
             //Destroy(other.gameObject);
            GameObject Child = other.gameObject.transform.Find("SlotMarket").gameObject;
            Child.SetActive(false);
        }
    }
     void OnTriggerExit2D (Collider2D other)
     {
         if(other.gameObject.tag == "Slot")
         {
            GameObject Child = other.gameObject.transform.Find("SlotMarket").gameObject;
            Child.SetActive(true);
         }
     }
}
