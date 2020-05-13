﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{

    // Author: Nicole Mynarek

    public int jumpCount = 2;           // Possible amount of jumps
    public int jumpCountLeft;           // Amount of jumps that are left

    // Author: Nicole Mynarek
    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveDirection = Input.GetAxisRaw("Horizontal");
            Movement();
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveDirection = Input.GetAxisRaw("Horizontal");
            Movement();
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        // If jump button is pressed shortly, the jump is not as high as possible
        if (Input.GetButtonUp("Jump"))
        {
            velocity = new Vector2(velocity.x, velocity.y * jumpHeightReducer);
        }
    }

    // Author: Nicole Mynarek
    // Method overridden, double jump is possible now
    protected override void Jump()
    {
        if (grounded && velocity.y <= 0)
        {
            jumpCountLeft = jumpCount;
        }

        if (jumpCountLeft <= 0)
        {
            jumpable = false;
            //Debug.Log("Boden springbar? " + jumpable);
        }
        else
        {
            jumpable = true;
            //Debug.Log("Boden springbar? " + jumpable);
        }

        base.Jump();
        jumpCountLeft--;
    }
}