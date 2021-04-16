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
    public bool spawned = false;

    public int openingDirection;
    //1 = Right
    //2 = Bottom
    //3 = Top
    //4 = Left

    private RoomSpawner roomSpawner;

    public float waitTime = 4f;

    void Start()
    {
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        roomInfo = gameObject.GetComponentInParent<RoomInfo>();
        Invoke("Spawn", 0.1f);
    }
    


    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
            }

            if (openingDirection == 2)
            {
                rand = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
            }
            if (openingDirection == 3)
            {
                rand = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
            }

            if (openingDirection == 4)
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
            roomSpawner = other.gameObject.GetComponent<RoomSpawner>();
            if(roomSpawner.spawned == false && spawned == false)
            {
                //Spawn walls blocking off any openings
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
        
    }
}