using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Campfire : MonoBehaviour
{
    public GameObject campFire;
    public float Heat;
    public GameObject Fire;
    public GameObject PointLight;
    public int HP = 100;
    private Animator campFire_animator;
    public GameObject HPUI;

    
    void Start()
    {

        campFire_animator = GetComponentInParent<Animator>();
        InvokeRepeating("TimeTick", 0, 0.5f);


    }
    void TimeTick()
    {
        HP--;
        HPUI.GetComponent<Slider>().value = HP;
        if (HP <= 0)
        {
            OffFire();
            Invoke("DestroyObject", 20);
        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.tag == "Player")
        {
            GameObject.FindWithTag("GameManager").GetComponent<CharacterStats>().Cold += Time.deltaTime / Heat;
        }
    }
    void OffFire()
    {
        gameObject.GetComponent<CapsuleCollider>().enabled = false;
        HPUI.SetActive(false);
        Fire.SetActive(false);
        campFire.GetComponent<AudioSource>().enabled = false;
        PointLight.SetActive(false);
        Invoke("HideAnimation", 10);



    }

    void HideAnimation()
    {
        campFire_animator.SetTrigger("OffFire");
    }

    void DestroyObject()
    {

        Destroy(campFire);
    }


}
