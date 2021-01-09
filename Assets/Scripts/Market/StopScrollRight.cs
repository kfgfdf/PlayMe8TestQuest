using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopScrollRight : MonoBehaviour
{
    public bool _isEmptyRight;

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Slot")
        {
            _isEmptyRight = false;
             //Destroy(other.gameObject);
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if(other.gameObject.tag == "Slot")
        {
            _isEmptyRight = true;
             //Destroy(other.gameObject);
        }
    }
}
