using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliderScript : MonoBehaviour
{
    private Player_Movements _Player;
    

    private void Start()
    {
        _Player = transform.parent.GetComponent<Player_Movements>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _Player._TriggerObject = other.gameObject;
        if (other.CompareTag("Observer"))
        {
            
        }

        if (other.CompareTag("Deplacer"))
        {

        }

        if (other.CompareTag("Recuperer"))
        {

        }
    }
    private void OnTriggerExit(Collider other)
    {
        _Player._TriggerObject = null;
    }
}
