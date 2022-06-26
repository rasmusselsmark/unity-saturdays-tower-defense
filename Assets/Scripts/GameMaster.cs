using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    [System.NonSerialized] public int towerSelected = 0;
    [System.NonSerialized] public bool gameOver;
    public UnityEngine.UI.Text TimeText;

    float timeUsed;
    
    void Update()
    {
        if (!gameOver)
        {
            timeUsed += Time.deltaTime;
        }

        int minutes, seconds;
        minutes = (int)(timeUsed / 60);
        seconds = (int)(timeUsed % 60);
        
        TimeText.text = "Time : " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    private static GameMaster instance = null;

    public static GameMaster Instance
    {
        get 
        {
            if (instance == null)
            {
                instance = GameObject.Find("GameMaster").GetComponent<GameMaster>();
            }

            return instance;
        }
    }
}
