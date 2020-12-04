using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMap : MonoBehaviour
{
    public int roomLocation;
    public GameObject roomOnePrefab;
    // Start is called before the first frame update
    void Start()
    {
        roomLocation = Random.Range(1, 4);
        Debug.Log(roomLocation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
