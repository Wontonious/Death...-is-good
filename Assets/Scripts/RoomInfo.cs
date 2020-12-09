using UnityEngine;

public class RoomInfo : MonoBehaviour
{
    public bool topDoor;
    public bool bottomDoor;
    public bool rightDoor;
    public bool leftDoor;

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
}
