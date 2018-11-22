using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New device", menuName = "Inventory/Device")]
public class Devices : Item {


	// Use this for initialization
	void Start () {
      
	}
	
	// Update is called once per frame
    public override void Use()
    {
        base.Use();
      
        /*
         * Что происходит при использовании
         * 
         * 
         * 
         * 
         */
        Instantiate(prefOutHand, GameObject.FindGameObjectWithTag("Player").transform.Find("CraftPlace").transform.position, Quaternion.identity);


        RemoveFromInventory();
    }
}
