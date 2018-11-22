using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int Health;
    public int DropCount;
    public Transform DropTrigger;
    public Loot[] Drop;


    public virtual void OnTriggerEnter(Collider other)
    {

    }

    public virtual void Died()
    {
        DropAfterDeath(DropCount);

    }
    public virtual void DestroyObj()
    {
        

    }

    public void DropAfterDeath(int DropCount)
    {
        //for (int i = 0; i < DropCount; i++)
        //{
        //    Debug.Log("Rand");
        int rand = Random.Range(0, 100);
        for (int j = 0; j < Drop.Length; j++)
        {
            if (rand < Drop[j].chance)
            {
                Instantiate(Drop[j].lootPrefab.prefOutHand, DropTrigger.position, Quaternion.identity);
                break;
            }
        }
        //}
    }


}

[System.Serializable]
public class Loot
{
    public Item lootPrefab;
    public int chance;
}