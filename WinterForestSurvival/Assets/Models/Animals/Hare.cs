using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Hare : Enemy {

    public Transform endPoint;
    public NavMeshAgent _navMeshAgent;
    public Animator _animator;
    public ChangePoint _changePoint;
    public GameObject _player;

	// Use this for initialization
	void Start () {
        _changePoint = endPoint.GetComponent<ChangePoint>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (_navMeshAgent.remainingDistance > _navMeshAgent.stoppingDistance)
        {
            _animator.SetBool("Walk", true);
            transform.LookAt(endPoint);
        }
        else
        {
            _animator.SetBool("Walk", false); //выбирается
        }
        if(Vector3.Distance(gameObject.transform.position,_player.transform.position)<3)
        {
            _navMeshAgent.speed = 5;
            _changePoint.isRun = true;
        }
        else
        {
            _navMeshAgent.speed = 2;
            _changePoint.isRun = false;
        }
        _navMeshAgent.SetDestination(endPoint.position);
	}

  
}
