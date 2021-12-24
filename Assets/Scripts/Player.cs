using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed_ = 0.05f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        float xDirection = Input.GetAxisRaw("Horizontal") * speed_;
        float zDirection = Input.GetAxisRaw("Vertical") * speed_;
        float diagDirection = zDirection + xDirection;

        Vector3 moveDirection = new Vector3(diagDirection, 0.0f, diagDirection);

        transform.position += moveDirection;
    }
}
