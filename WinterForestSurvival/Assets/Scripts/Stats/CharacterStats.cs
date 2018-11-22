using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;
using System.IO;

public class CharacterStats : MonoBehaviour
{
    public PlayerController _playerController;
    public PlayerStatsUI _playerStatsUI;
    void Start()
    {
        _playerStatsUI = GameObject.Find("PlayerStats").GetComponent<PlayerStatsUI>();
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("ChangeStats", 0, 1);//GameTime.instance.coefficient);
        Health = Health;
    }

    #region ИзменениеХарактеристик
    public float hungerPerMin = 0.1f;
    public float thirstPerMin = 0.3f;
    //public float tirednessPerMin = 0.5f; усталость
    public float coldPerMin = 0.5f;

    public float health = 100;
    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            if (value > 100)
            {
                health = 100;
            }
            else if (value < 0)
            {
                CancelInvoke();
                _playerController.Death();
                health = 0;
            }
            else
            {
                health = value;
            }
            _playerStatsUI.setHalthUI(Health / 100f);

        }
    }

    public float hunger = 100;
    public float Hunger
    {
        get
        {
            return hunger;
        }
        set
        {


            if (value > 100)
            {
                hunger = 100;
            }
            else if (value < 0)
            {
                hunger = 0;
                Health -= hungerPerMin;
            }
            else
            {
                hunger = value;
            }
            _playerStatsUI.setHungerUI(hunger / 101f);
            //HungerUI.color = Color.green;
        }
    }

    //public float thirst = 100;
    //public float Thirst
    //{
    //    get
    //    {
    //        return thirst;
    //    }
    //    set
    //    {
    //        if (value > 100)
    //        {
    //            thirst = 100;
    //        }
    //        else if (value < 0)
    //        {
    //            thirst = 0;
    //            Health -= thirstPerMin;
    //        }
    //        else
    //        {
    //            thirst = value;
    //        }
    //        _playerStatsUI.setThirstUI(thirst / 100f);
    //    }
    //}


    public float cold = 100;
    public float Cold
    {
        get
        {

            return cold;

        }
        set
        {
            if (value > 100)
            {
                cold = 100;
            }
            else if (value < 0)
            {
                cold = 0;
                Health += GameTemperature.instance.Temperature / coldPerMin;
            }
            else
            {
                cold = value;
            }
            _playerStatsUI.setColdUI(Cold / 100f);

        }
    }

    //public float tiredness = 100;
    //public float Tiredness
    //{
    //    get
    //    {
    //        return tiredness;
    //    }
    //    set
    //    {
    //        if (value > 100)
    //        {
    //            tiredness = 100;
    //        }
    //        else
    //        {
    //            tiredness = value;
    //        }
    //    }
    //}


    private void ChangeStats()
    {
        Hunger -= hungerPerMin;
        //Thirst -= thirstPerMin;
        //Tiredness -= tirednessPerMin;
        Cold += GameTemperature.instance.Temperature / coldPerMin;


    }
    #endregion ИзменениеХарактеристик




}
