using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public bool topDoor;
    public bool bottomDoor;
    public bool rightDoor;
    public bool leftDoor;

    private bool spawnedBottom = false;
    private bool spawnedTop = false;
    private bool spawnedLeft = false;
    private bool spawnedRight = false;

    public bool TopDoor()
    {
        return topDoor;
    }
    public bool BottomDoor()
    {
        return bottomDoor;
    }
    public bool RightDoor()
    {
        return rightDoor;
    }
    public bool LeftDoor()
    {
        return leftDoor;
    }


    public bool GetDoorBottom()
    {
        return spawnedBottom;
    }
    public bool SetDoorBottom()
    {
        spawnedBottom = true;
        return spawnedBottom;
    }

    public bool GetDoorTop()
    {
        return spawnedTop;
    }
    public bool SetDoorTop()
    {
        spawnedTop = true;
        return spawnedTop;
    }

    public bool GetDoorLeft()
    {
        return spawnedLeft;
    }
    public bool SetDoorLeft()
    {
        spawnedLeft = true;
        return spawnedLeft;
    }

    public bool GetDoorRight()
    {
        return spawnedRight;
    }
    public bool SetDoorRight()
    {
        spawnedRight = true;
        return spawnedRight;
    }
}
