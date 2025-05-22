using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearPad : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.GameClear();
        }
    }
}
