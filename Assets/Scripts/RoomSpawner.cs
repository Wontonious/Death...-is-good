using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    //10 - 15 rooms total
    //  If room has a certain 

    private RoomTemplates templates;
    //Check what the current room requires
    private RoomInfo roomInfo;
    private RoomInfo otherInfo;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        roomInfo = gameObject.GetComponentInParent<RoomInfo>();
        Invoke("Spawn", 0.1f);
    }
    


    void Spawn()
    {
        if (spawned == false)
        {
            if (gameObject.CompareTag("SpawnpointRight"))
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }

            if (gameObject.CompareTag("SpawnpointBottom"))
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            if (gameObject.CompareTag("SpawnpointTop"))
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }

            if (gameObject.CompareTag("SpawnpointLeft"))
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
     
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            Destroy(gameObject);
        }
    }
}