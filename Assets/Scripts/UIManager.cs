using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<UIManager>();
            }

            return _instance;
        }
    }
    #endregion
    public GameObject threeStars,twoStars,oneStar,noStar;

    public void CallUI()
    {
        print("CallUI");
        switch(TeleportManager.Instance.collectedTrash) 
        {
            case 0:
                noStar.SetActive(true);
                break;
            case 1:
                if (EndGame.levelIndex == 0)
                {
                    threeStars.SetActive(true);
                }
                else
                {
                    oneStar.SetActive(true);
                }
                break;
            case 2:
                twoStars.SetActive(true);
                break;
            case 3:
                threeStars.SetActive(true);
                break;
            
        }
    }

    public void DestroyCanvas()
    {
        noStar.SetActive(false);
        oneStar.SetActive(false);
        twoStars.SetActive(false);
        threeStars.SetActive(false);
    }
}
