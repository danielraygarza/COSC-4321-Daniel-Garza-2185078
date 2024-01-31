using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player; //ref to game object
    private Vector3 offset; //distance from camera and player

    // Start is called before the first frame update
    void Start()
    {
        //calculate initial offset between cameras position
        offset = transform.position - player.transform.position;
    }

    // alled once per frame after all ppdate functions have been completed
    private void LateUpdate()
    {
        // maintain the same offset between camera and player
        transform.position = player.transform.position + offset;
    }

}
