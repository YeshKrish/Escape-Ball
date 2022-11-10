using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public GameObject player;

    public Renderer ballColour;

    [HideInInspector]
    public List<GameObject> ballCount = new List<GameObject>();
    int maxBalls = 10;

    int count = 0;

    void Start()
    {
        ballColour = player.GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update()
    {
     
        if (Input.GetMouseButtonDown(0))
        {

            Vector3 mousePos = Input.mousePosition;

            mousePos.z = 25f;

            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(mousePos);

            if(spawnPos.z > 13f)
            {
                spawnPos.z = 14f;
            } 
            if(spawnPos.y < 3f)
            {
                spawnPos.y = 3f;
            }
            if(spawnPos.x >-9 && spawnPos.x < 9)
            {
                SpawnPoint(spawnPos);
            }
        }

    }

    public void SpawnPoint(Vector3 spawnPosParm)
    {
        count++;
        GameObject thing = Instantiate(player, spawnPosParm, Quaternion.identity) as GameObject;
        ballColour = thing.GetComponent<Renderer>();
        for(int i =1; i<maxBalls; i++)
        {
            if (count <= 3)
            {
                ballColour.material.color = Color.red;
            }
            else if (count <= 6)
            {
                ballColour.material.color = Color.green;
            }
            else if (count <= 9)
            {
                ballColour.material.color = Color.blue; 
            }
            else
            {
                count = 1;
                continue;
            }
            
        }
    }
  
}
