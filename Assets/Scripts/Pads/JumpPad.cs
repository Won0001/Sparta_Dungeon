using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        
        float boostedJumpForce = player.playerController.jumpForce * jumpMultiplier;

        if (other.CompareTag("Player"))
        {
            playerRb.velocity = Vector3.zero;
            playerRb.AddForce(Vector3.up * boostedJumpForce, ForceMode.Impulse);
        }
    }
}
