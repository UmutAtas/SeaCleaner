using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{
    public GameObject[] levelPrefabs;
    public EndGame endGame;
    
    public void SpawnLevel()
    {
        UIManager.Instance.DestroyCanvas();
        PlayerPrefs.SetInt("LevelIndex",EndGame.levelIndex);
        SceneManager.LoadScene(EndGame.levelIndex);

    }

    public void LoadFirstLevel()
    {
        
    }
}
