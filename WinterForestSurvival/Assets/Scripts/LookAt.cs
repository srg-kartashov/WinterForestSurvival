using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {

    private Transform _camera;
	// Use this for initialization
	void Start () {
        _camera = GameObject.FindGameObjectWithTag("Camera").transform;
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.LookAt(new Vector3(gameObject.transform.position.x,_camera.position.y,_camera.position.z));
	}
}
