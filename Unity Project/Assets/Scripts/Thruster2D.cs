using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Thruster2D : Thruster
{
    private Rigidbody2D myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    public override void ApplyThrottle()
    {
        myRigidBody.AddForce(transform.up * Throttle * power);
    }
}
