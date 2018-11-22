using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentManager : MonoBehaviour
{

    #region Singleton

    public static EquipmentManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of GameTemperature found!");
            return;
        }

        instance = this;
    }

    #endregion


    public TypeOfAnimation currentType;
    public Transform _handWeap;//где оружие
    public Transform _handTrigger;//где триггер
    public Weapon currentWeapon;//текущее оружие(итем) 
    GameObject weapon;//текущее оружие(префаб)
    GameObject weaponTrigger;//триггер атаки(для ближнего)
    public Animator ch_animator;
    public Image img_CurrWeap;

    private void Start()
    {
        ch_animator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _handWeap = GameObject.FindGameObjectWithTag("RightHand").transform.GetChild(0).transform;
        _handTrigger = GameObject.FindGameObjectWithTag("RightHand").transform.GetChild(1).transform;
        img_CurrWeap = GameObject.FindGameObjectWithTag("butAttack").transform.GetChild(0).GetComponent<Image>();


    }


    public void Equip(Weapon newWeapon)
    {
        //смена иконки кнопки атаки
        img_CurrWeap.enabled = true;
        img_CurrWeap.sprite = newWeapon.icon;

        if (currentWeapon != null)
        {
            Inventory.instance.Add(currentWeapon);
            currentWeapon = null;
            Destroy(weapon);
        }
        currentWeapon = newWeapon;

        weapon = Instantiate(newWeapon.prefInHand, _handWeap) as GameObject;

        if (newWeapon.Animation == TypeOfAnimation.MeleeWeapon)
        {
            weaponTrigger = Instantiate(newWeapon.AttackTrigger, _handTrigger) as GameObject;
        }
        currentType = newWeapon.Animation;
        ch_animator.SetInteger("Weapon", (int)currentType);
    }
    public void UnEquip(bool removeWeapon)
    {
        if (!removeWeapon)
        {
            Inventory.instance.Add(currentWeapon);
        }
        if (img_CurrWeap != null)
        {
            img_CurrWeap.enabled = false;
        }
        currentWeapon = null;
        Destroy(weapon);
        Destroy(weaponTrigger);
        ch_animator.SetInteger("Weapon", (int)TypeOfAnimation.MeleeWeapon);

    }

}
