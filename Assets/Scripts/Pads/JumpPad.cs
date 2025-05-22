using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                float boostedJumpForce = player.playerController.jumpForce * jumpMultiplier;

                Rigidbody playerRb = player.GetComponent<Rigidbody>();
                if (playerRb != null)
                {
                    playerRb.velocity = Vector3.zero;
                    playerRb.AddForce(Vector3.up * boostedJumpForce, ForceMode.Impulse);
                }
            }
        }
    }
}
