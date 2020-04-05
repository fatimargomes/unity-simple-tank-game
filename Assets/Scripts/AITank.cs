using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITank : Tank
{
    protected override void Init()
    {
        StartCoroutine(ShootCoroutine());
    }

    void FixedUpdate()
    {
        Move(0, 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == Constants.TagWall)
        {
            transform.Rotate(0, 180 - (Random.value * 90 - 45), 0);
        }
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            //Shoot();

            yield return new WaitForSeconds(Constants.EnemyTimeShoots);
        }
    }

}
