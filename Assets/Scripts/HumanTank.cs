using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTank : Tank
{
    protected override void Init()
    {

    }

    void Update()
    {

        if (Input.GetButtonUp(Constants.ShootInput))
        {
            Shoot();
        }
    }

    public override void TakeDamage()
    {
        GameController.instance.Restart();
    }

    void FixedUpdate()
    {
        float y = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Move(x, y);
    }
}
