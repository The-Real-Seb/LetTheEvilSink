using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    public So_Player _Player;
      

    private void OnTriggerStay(Collider other)
    {
        if (!other.CompareTag("Untagged"))
        {
            _Player._TriggerObject = other.gameObject;
        }
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        _Player._TriggerObject = null;
    }
}
