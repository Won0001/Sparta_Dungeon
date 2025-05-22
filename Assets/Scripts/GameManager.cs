using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance{get; private set;}
    public GameOverPanel gameOverPanel;
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
        gameOverPanel.useGameOverPanel();
        Time.timeScale = 0;
    }
}
