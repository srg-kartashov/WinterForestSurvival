using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    private Animator _animator;

    void Start()
    {
        _animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider other)
    {

        //if (other.tag == "Player")
        //{
        //    _animator.SetBool("Close", true);
        //    GameObject.FindWithTag("GameManager").GetComponent<CharacterStats>().Health -= 100;
        //}
        if (other.tag == "Enemy")
        {
            _animator.SetBool("Close", true);
            other.GetComponent<Enemy>().Health -= 100;
        }
    }
}
