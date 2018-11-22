using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Weapon")]
public class Weapon : Item
{
    public GameObject prefInHand;
    public TypeOfAnimation Animation;
    public GameObject AttackTrigger;
    public AudioClip Hit;
    

    public override void Use()
    {
        base.Use();
        //GameObject newWeapon = Instantiate(pref, hand.transform) as GameObject;
        EquipmentManager.instance.Equip(this);
        RemoveFromInventory();
    }
    
}
public enum TypeOfAnimation { WithoutWeapon, MeleeWeapon, PistolWeapon, RifleWeapon }