using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class HeroMobileController : MonoBehaviour
{
    public HeroStateMachine Hero;
    bool isMoving;
    private void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
    }
    public void SetVerticalAxisValue(int vertical)
    {
        Hero.verticalInput = vertical;
    }
    public void SetHorizontalAxisValue(int horizontal)
    {
        Hero.horizontalInput = horizontal;
    }
    public void Jump()
    {
        if(Hero.currentState != Hero.jumpState) Hero.SwitchState(Hero.jumpState);
    }

    public void Shoot(bool isShooting)
    {
        Hero.isShooting = isShooting;
        Hero.anim.SetBool("isShooting", isShooting);
    }
}
