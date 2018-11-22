using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Wolf : Enemy
{
    //public EnemySpawn _enemySpawn;
    //public int attackForce;
    public Transform endPoint;
    public NavMeshAgent _navMeshAgent;
    public Animator _animator;
    public GameObject _player;
    public BoxCollider _boxCollider;
    private AudioSource _audioSource;
    public AudioClip Attack;
    public AudioClip Walk;
    public AudioClip Death;
    public Slider HPUI;

    // Use this for initialization
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _audioSource = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Axe")
        {
            Health -= other.GetComponent<AttackTrigger>().Attack;

        }

        if (Health <= 0)
        {
            Died();
        }


    }

    // Update is called once per frame
    void Update()
    {
        HPUI.value = Health;
        if (Health > 0)
        {
            if (Vector3.Distance(gameObject.transform.position, _player.transform.position) > 5)
            {

                _navMeshAgent.SetDestination(endPoint.position);
                _navMeshAgent.speed = 2;
                if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                {
                    if (!_audioSource.isPlaying)
                    {
                        _audioSource.PlayOneShot(Walk);
                    }
                    _animator.SetInteger("State", 0);
                    //transform.LookAt(endPoint);
                }
                else
                {
                    _animator.SetBool("Attack", false);
                    _animator.SetInteger("State", 3);
                }
            }
            else
            {
                _navMeshAgent.SetDestination(_player.transform.position);
                _navMeshAgent.speed = 2.5f;
                if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
                {
                    _animator.SetBool("Attack", false);
                    _animator.SetInteger("State", 1);

                }
                else
                {
                    if (!_audioSource.isPlaying)
                    {
                        _audioSource.PlayOneShot(Attack);
                    }
                    _animator.SetInteger("State", 3);
                    _animator.SetBool("Attack", true);
                    transform.LookAt(_player.transform);
                }

                //transform.LookAt(_player.transform);



            }
        }


    }
    public override void Died()
    {
        gameObject.transform.parent.transform.parent.GetComponent<EnemySpawn>().Spawn(5);
        _audioSource.PlayOneShot(Death);
        base.Died();
        _animator.SetTrigger("Dead");
        _navMeshAgent.enabled = false;
        _boxCollider.enabled = false;

        //wood_animator.SetTrigger("Died");
        //wood_MeshCollider.enabled = false;
        //Invoke("hideObj", 5);
        Invoke("DestroyObj", 10);


    }
    public override void DestroyObj()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
