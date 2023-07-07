using UnityEngine;

public class HeroJumpState : HeroBaseState
{
    public override void EnterState(HeroStateMachine heroSM)
    {
        heroSM.rb.AddForce(new Vector3(0, heroSM.jumpHeight, 0), ForceMode.Impulse);
        heroSM.anim.SetBool("isJumping", true);
    }

    public override void ExitState(HeroStateMachine heroSM)
    {
    }

    public override void FixedUpdateState(HeroStateMachine heroSM)
    {
    }

    public override void OnCollisionEnterState(HeroStateMachine heroSM, Collision collision)
    {
        if (collision.collider.tag == "Ground")
        {
            heroSM.anim.SetBool("isJumping", false);
            heroSM.SwitchState(heroSM.idleState);
        }
    }

    public override void UpdateState(HeroStateMachine heroSM)
    {
    }
}
