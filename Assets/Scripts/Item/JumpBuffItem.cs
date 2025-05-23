using UnityEngine;

public class JumpBuffItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCondition playerCondition = other.GetComponent<PlayerCondition>();
            if (playerCondition != null)
            {
                playerCondition.ActivateJumpBuff();
                gameObject.SetActive(false);
            }
        }
    }
}
