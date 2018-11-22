using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New food", menuName = "Inventory/Food")]
public class Food : Item{

    public int satiety;

    public override void Use()
    {
        base.Use();
        GameObject.FindWithTag("GameManager").GetComponent<CharacterStats>().Hunger += satiety;
        RemoveFromInventory();
    }
}
