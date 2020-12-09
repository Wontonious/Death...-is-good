using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    //10 - 15 rooms total
    //  If room has a certain 

    private RoomTemplates templates;
    private RoomInfo roomInfo;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = gameObject.GetComponentInParent<RoomTemplates>();
        roomInfo = gameObject.GetComponentInParent<RoomInfo>();
        Invoke("Spawn", 0.1f);
    }



    void Spawn()
    {
        if (roomInfo.BottomDoor())
        {
            //Spawn a room with a top door
            rand = Random.Range(0, templates.topRooms.Length);
            //if(rand = )
            Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
        }
        if (roomInfo.TopDoor())
        {
            //spawn a room with a bottom door
            rand = Random.Range(0, templates.bottomRooms.Length);

            Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
        }

        if (roomInfo.RightDoor())
        {
            //spawn a room with left door
            rand = Random.Range(0, templates.leftRooms.Length);

            Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
        }
        if (roomInfo.LeftDoor()) { }
        {
            //spawn a room with a right door
            rand = Random.Range(0, templates.rightRooms.Length);

            Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
        }
    }
    /*
    void Spawn()
    {
        if (!spawned)
        {
            if (openingDirection == 1)
            {
                //Need to spawn a room with a bottom door
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                //Need to spawn a room with a top door
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                //Need to spawn a room with a left door
                rand = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                //Need to spawn a room with a right door
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
    */


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint") && other.GetComponent<RoomSpawner>().spawned == true)
        {
            Destroy(gameObject);
        }
    }
}
