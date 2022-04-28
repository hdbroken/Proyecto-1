using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Tutorial;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int lastSavePoint = 0;
    public int tries = 1;
    public bool playerIsAlive = true;

    public Dictionary<TutorialData, bool> tutorialSeen = new Dictionary<TutorialData, bool>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddTutorial(TutorialData tutorial)
    {
        tutorialSeen.Add(tutorial, false);
    }
}
