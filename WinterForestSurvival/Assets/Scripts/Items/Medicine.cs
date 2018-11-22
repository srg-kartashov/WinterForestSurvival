using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName="New medicine", menuName="Inventory/Medicine")]
public class Medicine : Item {

    public int treatment;

    public override void Use()
    {
        base.Use();
        GameObject.FindWithTag("GameManager").GetComponent<CharacterStats>().Health += treatment;
        RemoveFromInventory();
    }

}
