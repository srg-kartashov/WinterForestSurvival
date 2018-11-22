using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerAttack : MonoBehaviour {
    public int Attack;
    public CharacterStats _characterStats;
    private void Start()
    {
        _characterStats = GameObject.FindWithTag("GameManager").GetComponent<CharacterStats>();
      
    }
    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            _characterStats.Health -= Attack;
        }
    }
}
