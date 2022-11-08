using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvisibleController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ballQty;
    [SerializeField] string winText;
    [SerializeField] TextMeshProUGUI text;
   

    [SerializeField] List<GameObject> inviCubes;
    [SerializeField] float currentTime = 0;
    MeshRenderer meshComp;
    Collider inviCollider;
    BoxCollider boxCollider;
    [SerializeField] float timeToToggleVicible =  5f;

    int count = 0;
    int randValue;
    [HideInInspector]
    [SerializeField] bool available = true;

    void Start()
    {
        text.enabled = false;
        available = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        available = Mathf.FloorToInt(Time.time) % 5 == 0;

        if (available && currentTime > timeToToggleVicible)
        {
            Debug.Log(currentTime);
            currentTime = 0;
            Invisicible();
        }

    }

    void Invisicible()
    {
        randValue = Random.Range(0, 8);
        Debug.Log("Random Value:" + randValue);
        meshComp = inviCubes[randValue].GetComponent<MeshRenderer>();
        inviCollider = inviCubes[randValue].GetComponent<Collider>();
        boxCollider = inviCubes[randValue].GetComponent<BoxCollider>();
        inviCollider.isTrigger = available;
        boxCollider.center = new Vector3(0f, 0f, -2.5f);
        meshComp.enabled = !available;
        StartCoroutine(Visible(randValue));

    }
    IEnumerator Visible(int random)
    {
       
        yield return (new WaitForSeconds(4.98f));
        Debug.Log("Random Enum Value:" + randValue);
        meshComp = inviCubes[random].GetComponent<MeshRenderer>();
        inviCollider = inviCubes[random].GetComponent<Collider>();
        boxCollider = inviCubes[random].GetComponent<BoxCollider>();
        Debug.Log("BOx Before" + boxCollider.center);
        boxCollider.center = new Vector3(0f, 0f, 0f);
        Debug.Log("BOx After" + boxCollider.center);
        Debug.Log("T or F:" + available);
        inviCollider.isTrigger = available;
        meshComp.enabled = !available;
    }

    private void OnTriggerEnter(Collider other)
    {
        count++;
        ballQty.text = count.ToString();
        Debug.Log(count);
        if(other.gameObject.name == "Sphere(Clone)" && count == 10)
        {
            StartCoroutine("PauseGame");  
        }
    }
    IEnumerator PauseGame()
    {
        yield return (new WaitForSeconds(0.1f));
        text.enabled = true;
        Time.timeScale = 0f;
    }

}
