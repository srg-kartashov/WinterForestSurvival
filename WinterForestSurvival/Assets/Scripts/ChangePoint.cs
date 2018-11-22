using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePoint : MonoBehaviour
{

    public bool isRun;
    private BoxCollider _boxCollider;
    public GameObject _player;
    private int distanseToNewPoint;
    public GameObject obj;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        isRun = false;
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.name == obj.name)
        {
            if (!isRun)
            {
                distanseToNewPoint = 5;
                Invoke("ChangePosition", 5);
            }

        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.name == obj.name)
        {
            if (isRun)
            {
                distanseToNewPoint = 10;
                ChangePosition();
            }
        }
    }
    void ChangePosition()
    {
        Vector3 newPosition = new Vector3();
        do
        {

            newPosition = new Vector3(gameObject.transform.position.x + Random.Range(-distanseToNewPoint, distanseToNewPoint), 0, gameObject.transform.position.z + Random.Range(-distanseToNewPoint, distanseToNewPoint));
        }
        while (!CheckPosition(newPosition));
        gameObject.transform.position = newPosition;
    }

    bool CheckPosition(Vector3 newPosition)
    {
        if (Physics.Raycast(newPosition, Vector3.down))
        {
            return true;
        }
        return false;
    }

}
