using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {
    public GameObject Roof;

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Roof.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Roof.SetActive(true);
          
        }
    }

}
