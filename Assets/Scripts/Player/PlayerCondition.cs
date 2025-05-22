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
    
    public float fallDamageThreshold = 10f;
    public float fallDamageMultiplier = 1.1f;
    
    private float fallVelocity;
    private Rigidbody _rigidbody;
    private bool isGrounded;
    
    Condition health {get{return uiCondition.Health;}}
    Condition buff {get{return uiCondition.Buff;}}

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
    }
    
    private void Start()
    {
        originJumpForce = playerController.jumpForce;
    }

    private void Update()
    {
        fallVelocity = _rigidbody.velocity.y;
        isGrounded = playerController.IsGrounded();
        if (isGrounded && fallVelocity < -fallDamageThreshold)
        {
            float fallDamage = CalculateFallDamage(fallVelocity);
            TakeDamage(fallDamage);
        }
    }

    private float CalculateFallDamage(float velocity)
    {
        // 음수 속도를 양수로 변환
        float fallSpeed = Mathf.Abs(velocity);
        
        // 임계값을 넘는 속도에 대해서만 데미지 계산
        float excessSpeed = fallSpeed - fallDamageThreshold;
        
        // 데미지 계산 (속도가 빠를수록 더 큰 데미지)
        return excessSpeed * fallDamageMultiplier;
    }

    private void TakeDamage(float damage)
    {
        health.Sub(damage);

        if (health.curValue <= 0)
        {
            Die();
        }
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

    public void Die()
    {
        GameManager.Instance.GameOver();
    }
}
