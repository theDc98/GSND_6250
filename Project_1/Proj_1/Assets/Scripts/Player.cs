using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int speed = 0;
    public int acc = 5;
    Vector3 facing_direction = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Speed is: " + speed);
    }

    // Update is called once per frame
    void Update()
    {
        var characterController = this.GetComponent<CharacterController>();
        var direction = new Vector3(
            Input.GetAxis("Horizontal"),
            0.0f,
            Input.GetAxis("Vertical")
        ).normalized;
        var delta = direction * this.speed;
        characterController.SimpleMove(delta);

        facing_direction = Vector3.Lerp(direction, this.facing_direction, 0.99f);
        var transform = this.GetComponent<Transform>();
        var target = transform.position + facing_direction;
        transform.LookAt(target);

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cube"))
        {
            Debug.Log("SPEED UP! Current Speed is: " + speed);
            speed += acc;
            Destroy(collider.gameObject);
        }
    }
}
