using System;
using System.Collections;
using UnityEngine;

public class PlayerCondition : MonoBehaviour
{   
    public UICondition uiCondition;
    public PlayerController playerController;

    private float originSpeed;
    private bool isBuffActive = false;
    
    Condition health {get{return uiCondition.Health;}}
    Condition buff {get{return uiCondition.Buff;}}

    private void Start()
    {
        originSpeed = playerController.speed;
        buff.gameObject.SetActive(false);
    }

    public void ActivateSpeedBuff()
    {
        if (!isBuffActive)
        {
            StartCoroutine(SpeedBuffCoroutine());
        }
    }

    private IEnumerator SpeedBuffCoroutine()
    {
        isBuffActive = true;
        buff.gameObject.SetActive(true);
        buff.curValue = buff.startValue;
        playerController.speed = originSpeed * 1.5f;

        float elapsedTime = 0f;
        float buffDuration = 10f;

        while (elapsedTime < buffDuration)
        {
            elapsedTime += Time.deltaTime;
            buff.curValue = Mathf.Lerp(buff.startValue, 0, elapsedTime / buffDuration);
            yield return null;
        }
        
        playerController.speed = originSpeed;
        isBuffActive = false;
        buff.gameObject.SetActive(false);
    }
}
