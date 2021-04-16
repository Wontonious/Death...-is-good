using UnityEngine.UI;
using UnityEngine;

public class WispCount : MonoBehaviour
{
    public Text wispText;
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
        if(playerObject != null)
        {
            PlayerV2 player = playerObject.gameObject.GetComponent<PlayerV2>();

            wispText.text = player.WispCount().ToString();
        }
    }
}
