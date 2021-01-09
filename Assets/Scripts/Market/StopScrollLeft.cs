using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScrollLeft : MonoBehaviour
{
    public bool _isEmptyLeft;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Slot")
        {
            _isEmptyLeft = false;
             //Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if(other.gameObject.tag == "Slot")
        {
            _isEmptyLeft = true;
             //Destroy(other.gameObject);
        }
    }
}
