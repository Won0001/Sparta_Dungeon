using UnityEngine;

public class GamePanelController : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject gameClearPanel;

    private void Start()
    {
        gameOverPanel.SetActive(false);
        gameClearPanel.SetActive(false);
    }

    public void useGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
    
    public void useGameClearPanel()
    {
        gameClearPanel.SetActive(true);
    }
}
