using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform camera_Transform;
    private Transform player_Transform;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        camera_Transform = gameObject.GetComponent<Transform>();
        player_Transform = GameObject.Find("Player").GetComponent<Transform>();

        offset = new Vector3(0f, 30f, -30f);
    }

    // Update is called once per frame
    void Update()
    {
        camera_Transform.position = Vector3.Lerp(camera_Transform.position,
            player_Transform.position + offset,
            Time.deltaTime * 3);
    }
}