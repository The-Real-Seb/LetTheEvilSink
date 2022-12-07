using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureManager : MonoBehaviour
{
    CreatureStateManager creature;


    void Start()
    {
        creature = GameObject.FindWithTag("Creature").GetComponent<CreatureStateManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (creature.currentState == creature.SearchState)
            creature.SearchState.OnCollisionEnter(creature, collision);
        else if (creature.currentState == creature.ChaseState)
            creature.ChaseState.OnCollisionEnter(creature, collision);
    }

    void OnTriggerEnter(Collider other)
    {
        if (creature.currentState == creature.SearchState)
            creature.SearchState.OnTriggerEnter(creature, other);
        else if (creature.currentState == creature.ChaseState)
            creature.ChaseState.OnTriggerEnter(creature, other);
    }
}
