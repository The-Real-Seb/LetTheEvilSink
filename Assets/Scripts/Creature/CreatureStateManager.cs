using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureStateManager : MonoBehaviour
{

    CreatureBaseState currentState;
    public CreatureWanderState WanderState = new CreatureWanderState();
    public CreatureSearchState SearchState = new CreatureSearchState();
    public CreatureChaseState ChaseState = new CreatureChaseState();


    void Start()
    {
        currentState = WanderState;

        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(CreatureBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
}
