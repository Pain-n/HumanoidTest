using System;
using System.Collections.Generic;
using UnityEngine;

public class HeroStateMachine : MonoBehaviour
{
    [Header("Parameters")]
    public Animator anim;
    public Rigidbody rb;
    public float walkSpeed, jumpHeight;
    public float turnSmoothTime;

    [HideInInspector]
    public float horizontalInput;
    [HideInInspector]
    public float verticalInput;
    [HideInInspector]
    public Vector3 direction;
    [HideInInspector]
    public float turnSmoothVelocity;
    [HideInInspector]
    public bool isShooting;

    public FootPrintSystem FootPrintSystem;
    public HeroBaseState currentState { get; private set; }

    public HeroIdleState idleState = new();
    public HeroMoveState moveState = new();
    public HeroJumpState jumpState = new();

    private void Start()
    {
        currentState = idleState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    private void FixedUpdate()
    {
        currentState.FixedUpdateState(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnterState(this, collision);
    }
    public void SwitchState(HeroBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
}
