using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public GamePanelController gamePanelController;
    private void Awake()
    {
        if (Instance == null && Instance != this)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        gamePanelController.useGameOverPanel();
        Time.timeScale = 0;
    }

    public void GameClear()
    {
        gamePanelController.useGameClearPanel();
        Time.timeScale = 0;
    }
}
