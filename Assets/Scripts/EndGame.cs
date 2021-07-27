using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class EndGame : MonoBehaviour
{
    public bool gameEnd = false;
    public static int levelIndex = 0;
    public int _collectedTrash;

    private void Awake()
    {
        gameEnd = false;
        PlayerPrefs.GetInt("LevelIndex", levelIndex);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameEnd)
        {
            gameEnd = true;
            DOVirtual.DelayedCall(3f, () => _collectedTrash=TeleportManager.Instance.collectedTrash).OnComplete((() =>
            {
                print(_collectedTrash);
                UIManager.Instance.CallUI();
                if (_collectedTrash != 0)
                {
                    levelIndex += 1;
                }

                if (levelIndex == 3)
                {
                    levelIndex = 0;
                }
            }));
        }
    }
}
