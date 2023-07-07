using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HeroBaseState
{
    public abstract void EnterState(HeroStateMachine heroSM);
    public abstract void UpdateState(HeroStateMachine heroSM);
    public abstract void FixedUpdateState(HeroStateMachine heroSM);
    public abstract void OnCollisionEnterState(HeroStateMachine heroSM, Collision collision);
    public abstract void ExitState(HeroStateMachine heroSM);
}
