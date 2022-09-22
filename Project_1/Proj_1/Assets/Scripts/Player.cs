using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int speed = 0;
    public int acc = 5;
    Vector3 facing_direction = new Vector3(0.0f, 0.0f, 0.0f);

    private int cubes = 0;
    private float timer = 0;

    public Text text;
    public GameObject ui;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Current Speed is: " + speed);
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

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

        if(cubes >= 4)
        {  
            Time.timeScale = 0;
            text.text = timer.ToString();
            ui.SetActive(true);
        }

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Cube"))
        {
            cubes++;
            Debug.Log("SPEED UP! Current Speed is: " + speed);
            speed += acc;
            Destroy(collider.gameObject);
        }
    }
}
