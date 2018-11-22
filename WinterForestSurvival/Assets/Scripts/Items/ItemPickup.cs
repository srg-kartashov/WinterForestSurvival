using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class ItemPickup : MonoBehaviour
{

    public Item item;
    public GameObject parent;
    //private Image imgOfItem;
    private Button buttonPickUp;



    void Start()
    {
        buttonPickUp = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Button>();
    }

    void PickUp()
    {
        
        buttonPickUp.interactable = false;
        //imgOfItem.enabled = false;
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
        {
            Destroy(parent);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonPickUp.onClick.RemoveAllListeners();
            buttonPickUp.onClick.AddListener(PickUp);

            //imgOfItem.sprite = item.icon;
            buttonPickUp.interactable = true;
            //imgOfItem.enabled = true;

            //buttonPickUp.onClick.AddListener(delegate { PickUp(); });
            //PickUp();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            buttonPickUp.onClick.RemoveListener(PickUp);
            buttonPickUp.interactable = false;
            //imgOfItem.enabled = false;
            //PickUp();
        }
    }

}
