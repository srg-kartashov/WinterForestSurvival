using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsUI : MonoBehaviour {

    private PlayerController _playerController;
	void Start () {
        _playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
    public void ClickButtonAttack()
    {
        _playerController.Attack();
    }
	
}
