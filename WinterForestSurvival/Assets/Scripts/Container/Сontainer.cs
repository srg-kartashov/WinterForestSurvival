using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Сontainer : MonoBehaviour
{
    private GameObject InventoryUI;
    public List<Item> Items;
    private Button buttonPickUp;
    public GameObject containerUI;
    private GameObject content;
    public GameObject containerSlotUI;
    public GameObject tempContainerUI;
    private GameObject mainCanvas;
    // Use this for initialization
    void Start()
    {
        buttonPickUp = GameObject.FindGameObjectWithTag("PickUp").GetComponent<Button>();
        mainCanvas = GameObject.FindGameObjectWithTag("MainCanvas");
        InventoryUI = mainCanvas.transform.Find("Inventory").gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(tempContainerUI);
            buttonPickUp.onClick.RemoveAllListeners();
            buttonPickUp.onClick.AddListener(OpenContainer);
            buttonPickUp.interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(tempContainerUI);
            buttonPickUp.onClick.RemoveAllListeners();
            InventoryUI.SetActive(false);
            buttonPickUp.interactable = false;

        }
    }

    void OpenContainer()
    {

        InventoryUI.SetActive(true);
        

        tempContainerUI = Instantiate(containerUI, GameObject.FindGameObjectWithTag("MainCanvas").transform);
        tempContainerUI.GetComponent<CurrentContainer>().currentContainer = this;
        content = GameObject.FindGameObjectWithTag("ContainerContent");
        for (int i = 0; i < Items.Count; i++)
        {

            Instantiate(containerSlotUI, content.transform);
            content.GetComponentsInChildren<ContainerSlot>()[i].AddItem(Items[i]);
        }
        buttonPickUp.onClick.RemoveAllListeners();
        buttonPickUp.onClick.AddListener(CloseCont);
        //buttonPickUp.interactable = false;
    }
    void CloseCont()
    {
        tempContainerUI.SetActive(false);
        InventoryUI.SetActive(false);
        Destroy(tempContainerUI);
        buttonPickUp.onClick.RemoveAllListeners();
        buttonPickUp.onClick.AddListener(OpenContainer);
    }


}
