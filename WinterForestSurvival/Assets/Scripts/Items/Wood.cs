using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : Enemy
{
    private Animator wood_animator;
    private Rigidbody wood_rigidbody;
    public AudioClip[] chop;
    private AudioSource wood_audio;
    private MeshCollider wood_MeshCollider;
   

    // Use this for initialization
    private void Start()
    {
       
        wood_animator = GetComponentInParent<Animator>();
        wood_rigidbody = GetComponentInParent<Rigidbody>();
        wood_audio = GetComponentInParent<AudioSource>();
        wood_MeshCollider = GetComponent<MeshCollider>();
    }

    public override void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Axe")
        {
            Health -= other.GetComponent<AttackTrigger>().Attack;
            wood_animator.SetTrigger("Chop");
            wood_audio.PlayOneShot(chop[Random.Range(0, 2)]);
        }

        if (Health <= 0)
        {
            Died();
        }

    }
    //public void hideObj()
    //{
    //    wood_rigidbody.isKinematic = true;
    //    wood_animator.enabled = true;
    //    wood_animator.SetTrigger("Died");
    //}
    public override void DestroyObj()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public override void Died()
    {
        base.Died();
        wood_rigidbody.isKinematic = false;
        wood_animator.enabled = false;
        wood_MeshCollider.enabled = false;

        //wood_animator.SetTrigger("Died");
        //wood_MeshCollider.enabled = false;
        //Invoke("hideObj", 5);
        Invoke("DestroyObj", 10);
        
    }




}
