using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroIdleState : HeroBaseState
{
    public override void EnterState(HeroStateMachine heroSM)
    {
        heroSM.anim.SetFloat("Velocity", 0);
    }

    public override void ExitState(HeroStateMachine heroSM)
    {
    }

    public override void FixedUpdateState(HeroStateMachine heroSM)
    {
        if (heroSM.horizontalInput != 0 || heroSM.verticalInput != 0)
        {
            heroSM.SwitchState(heroSM.moveState);
        }

        if (heroSM.isShooting)
        {
            //€ затрудн€юсь выделить стрельбу в отдельный стейт, так как она должа работать вместе с другими стейтами, а не отдельно от них, дл€ тестового придумал такое вот простое решение.
            //хот€ это скорее небольша€ наработка решени€.
            ShootLogic.Shoot(heroSM);
        }
    }

    public override void OnCollisionEnterState(HeroStateMachine heroSM, Collision collision)
    {
    }

    public override void UpdateState(HeroStateMachine heroSM)
    {
    }
}
