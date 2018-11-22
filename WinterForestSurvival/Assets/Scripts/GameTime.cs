using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{

    #region Singleton

    public static GameTime instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameTime found!");
            return;
        }

        instance = this;
    }

    #endregion

    [SerializeField]
    private EnvironmentStatsUI _environmentStatsUI;
    public GameObject sun;
    private int coefficient = 25;
    public int days = 0;
    public bool isDay()
    {
        if (gameHours > 7 && gameHours < 17)
        {
            return true;
        }
        else
            return false;
    }
    private int gameMinutes = 0;
    public int GameMinutes
    {
        get
        {
            return gameMinutes;
        }
        set
        {
            if (value > 59)
            {
                GameHours++;
                gameMinutes = 0;
            }
            else
            {
                gameMinutes = value;
            }
        }
    }
    public int gameHours = 9;
    public int GameHours
    {
        get
        {
            return gameHours;
        }
        set
        {
            if (value > 23)
            {
                days++;
                gameHours = 0;
            }
            else
            {
                gameHours = value;
            }
            sun.transform.rotation = Quaternion.Euler(270 + gameHours * 15, 0, 0);
        }
    }

    void Start()
    {
        _environmentStatsUI = GameObject.Find("EnvironmentStats").GetComponent<EnvironmentStatsUI>();
        InvokeRepeating("Tick", 0, coefficient);
    }

    void Tick()
    {
        GameHours++;
        print("tick");
        _environmentStatsUI.setTimeUI(GameHours.ToString());
    }

}