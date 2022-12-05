using UnityEngine;

public class CreatureWanderState : CreatureBaseState
{
    public So_Creature so;


    public override void EnterState(CreatureStateManager creature)
    {
        so = Resources.Load<So_Creature>("Creature/Creature");
        Debug.Log(so.creatureGauge);
    }

    public override void UpdateState(CreatureStateManager creature)
    {
        if (so.creatureGauge >= 100)
            creature.SwitchState(creature.SearchState);
    }

    public override void OnCollisionEnter(CreatureStateManager creature)
    {

    }
}
