using UnityEngine;
using CodeMonkey.Utils;

public class EnemyAI : MonoBehaviour
{

    private Vector3 startPosition;
    private Vector3 roamPosition;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        roamPosition = GetRoamingPoistion();
    }

    void Update()
    {

    }
    private Vector3 GetRoamingPoistion()
    {
        return startPosition + UtilsClass.GetRandomDir() * Random.Range(10f, 70f);
    }
}
