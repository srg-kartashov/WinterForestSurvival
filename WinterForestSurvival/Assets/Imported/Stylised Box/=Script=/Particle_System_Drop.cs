using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle_System_Drop : MonoBehaviour {

	public GameObject Drop;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
		Instantiate(Drop, transform.position, Drop.transform.rotation);
	}

}
