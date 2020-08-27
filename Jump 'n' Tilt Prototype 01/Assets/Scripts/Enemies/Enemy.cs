﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private GameObject player;

    protected override void OnEnable()
    {
        base.OnEnable();
        whatIsEnemy = LayerMask.GetMask("Player");
        player = GameObject.Find("Player");
    }

    protected override void ComputeVelocity()
    {
        base.ComputeVelocity();

        if (isDead)
        {
            gameObject.SetActive(false);
            Debug.Log("Enemy ist tot!");
        }
    }
    public override void TakeDamage(int damage, Vector2 direction)
    {
        base.TakeDamage(damage, direction);
        Debug.Log("takeDamege von Enemy!!!!!!!!!");
    }

    /// <summary>
    /// Returns a Vector2 pointing to the transform of the player.
    /// </summary>
    public Vector2 playerDirection()
    {
        return player.transform.position - transform.position;
    }

}