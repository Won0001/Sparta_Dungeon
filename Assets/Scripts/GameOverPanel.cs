using UnityEngine;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameOverPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void useGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
