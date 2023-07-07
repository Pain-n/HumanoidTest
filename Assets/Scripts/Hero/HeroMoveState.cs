using System.Collections;
using UnityEngine;

public class HeroMoveState : HeroBaseState
{
    public override void EnterState(HeroStateMachine heroSM)
    {
        heroSM.FootPrintSystem.StartShowing();
    }

    public override void ExitState(HeroStateMachine heroSM)
    {
        heroSM.FootPrintSystem.StopShowing();
    }

    public override void FixedUpdateState(HeroStateMachine heroSM)
    {
        if (heroSM.horizontalInput != 0 || heroSM.verticalInput != 0)
        {
            heroSM.direction = new Vector3(heroSM.horizontalInput, 0f, heroSM.verticalInput).normalized;
            float targetAngle = Mathf.Atan2(heroSM.direction.x, heroSM.direction.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(heroSM.transform.eulerAngles.y, targetAngle, ref heroSM.turnSmoothVelocity, heroSM.turnSmoothTime);
            heroSM.transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            heroSM.rb.AddForce(moveDir * heroSM.walkSpeed, ForceMode.Force);
        }
        else
        {
            heroSM.SwitchState(heroSM.idleState);
            return;
        }
        heroSM.anim.SetFloat("Velocity", heroSM.rb.velocity.magnitude);

        if (heroSM.isShooting)
        {
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
