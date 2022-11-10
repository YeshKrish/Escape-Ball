using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Transform ballTransform;

    [SerializeField] InvisibleController inviCont;

    private void Start()
    {
        ballTransform = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("InviWall"))
        {
            transform.position = new Vector3(ballTransform.position.x, ballTransform.position.y, ballTransform.position.z);

        }
    }
}
