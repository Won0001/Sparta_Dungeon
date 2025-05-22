using System;
using System.Collections;
using UI;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{   
    public UICondition uiCondition;
    public PlayerController playerController;

    private float originJumpForce;
    private bool isBuffActive = false;
    
    Condition health {get{return uiCondition.Health;}}
    Condition buff {get{return uiCondition.Buff;}}

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Start()
    {
        originJumpForce = playerController.jumpForce;
    }

    public void ActivateJumpBuff()
    {
        if (!isBuffActive)
        {
            StartCoroutine(JumpBuffCoroutine());
        }
    }

    private IEnumerator JumpBuffCoroutine()
    {
        isBuffActive = true;
        buff.gameObject.SetActive(true);
        buff.curValue = buff.startValue;
        playerController.jumpForce = originJumpForce * Mathf.Sqrt(2f);

        float elapsedTime = 0f;
        float buffDuration = 10f;

        while (elapsedTime < buffDuration)
        {
            elapsedTime += Time.deltaTime;
            buff.curValue = Mathf.Lerp(buff.startValue, 0, elapsedTime / buffDuration);
            yield return null;
        }
        
        playerController.jumpForce = originJumpForce;
        isBuffActive = false;
        buff.gameObject.SetActive(false);
    }

    public void Eat(float amount)
    {
        health.Add(amount);
    }

    public void FallDamage()
    {
        
    }

    public void Die()
    {
        if (CharacterManager.Instance.Player.playerCondition.health.curValue <= 0)
        {
            Destroy(gameObject);
            GameManager.Instance.EndGame();
        }
    }
}
