using UnityEngine;

namespace UI
{
    public class UICondition : MonoBehaviour
    {
        public Condition Health;
        public Condition Buff;

        private void Start()
        {
            CharacterManager.Instance.Player.playerCondition.uiCondition = this;
            Buff.gameObject.SetActive(false);
        }
    }
}
