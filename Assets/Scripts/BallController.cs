using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Vector3 ballTransform;

    [SerializeField] InvisibleController inviCont;

    float spwanDistance;
    static float count = 0;

    private void Start()
    {
        ballTransform = GameObject.FindGameObjectWithTag("SpawnPoint").GetComponent<Transform>().position;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Count Ball:" + count);
        if (other.gameObject.CompareTag("InviWall"))
        {  
            if(count == 0)
            {
                transform.position = new Vector3(ballTransform.x + (count * 1), ballTransform.y, ballTransform.z);
            }        
            else if(count >= 1)
            {
                transform.position = new Vector3(ballTransform.x + (count * 2), ballTransform.y, ballTransform.z);
            }
            Debug.Log("Ball Transform:" + ballTransform.x + count);
            count++;
        }
    }
}
