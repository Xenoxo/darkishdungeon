using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    GameObject playerModel;
    [SerializeField]
    float depth = 0.0f;

    private float speed_ = 0.05f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Looking();
    }

    void Movement()
    {
        float xDirection = Input.GetAxisRaw("Horizontal") * speed_;
        float zDirection = Input.GetAxisRaw("Vertical") * speed_;

        Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection;
    }

    void Looking()
    {
        var mousePos = Input.mousePosition;
        var wantedPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, depth));

        playerModel.transform.LookAt(wantedPos);
    }
}
