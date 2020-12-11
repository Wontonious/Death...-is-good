using UnityEngine;

public class RoomSpawner : MonoBehaviour
{

    //10 - 15 rooms total
    //  If room has a certain 

    private RoomTemplates templates;
    //Check what the current room requires
    private RoomInfo roomInfo;
    private int rand;
    private bool spawned = false;

    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("RoomTemplate").GetComponent<RoomTemplates>();
        roomInfo = gameObject.GetComponentInParent<RoomInfo>();
        Spawn();
    }



    void Spawn()
    {
        if (gameObject.CompareTag("SpawnpointBottom"))
        {

            if (roomInfo.BottomDoor() && !roomInfo.GetDoorBottom())
            {

                //Checks if the room requires a door at the bottom
                //Spawn a room with a top door below it
                rand = Random.Range(0, templates.topRooms.Length);
                //if(rand = )
                Debug.Log(rand);
                Debug.Log(templates.topRooms[rand]);
                if (rand == 0)
                {
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    roomInfo.SetDoorBottom();
                }
                else if (rand == 2 && templates.topRooms[rand].CompareTag("Sqaure_TBRL_B"))
                {
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    roomInfo.SetDoorBottom();
                }
                else
                {
                    Debug.Log("FAILED");
                }
            }
        }
        if (gameObject.CompareTag("SpawnpointTop"))
        {
            if (roomInfo.TopDoor() && !roomInfo.GetDoorTop())
            {
                //spawn a room with a bottom door
                rand = Random.Range(0, templates.bottomRooms.Length);

                Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                roomInfo.SetDoorTop();
            }
        }

        if (gameObject.CompareTag("SpawnpointRight"))
        {
            if (roomInfo.RightDoor() && !roomInfo.GetDoorRight())
            {
                //spawn a room with left door
                rand = Random.Range(0, templates.leftRooms.Length);

                Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                roomInfo.SetDoorRight();
            }
        }
        if (gameObject.CompareTag("SpawnpointLeft"))
        {
            if (roomInfo.LeftDoor() && !roomInfo.GetDoorLeft()) { }
            {
                //spawn a room with a right door
                rand = Random.Range(0, templates.rightRooms.Length);

                Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                roomInfo.SetDoorLeft();
            }
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
            Debug.Log("Destroyed");
            Destroy(gameObject);
        }
    }
}
