using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            playerCondition.Die();
        }
    }
}
