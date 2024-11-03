using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    GameObject player;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null) {
            player = GameManager.Instance.player;
            offset = transform.position - player.transform.position;
        }
        if (player != null) {
            transform.position = player.transform.position + offset;
        }
    }
}
