using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        float direction_x = Input.GetAxis("Horizontal");
        float direction_z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(direction_x, 0.0f, direction_z).normalized;


        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}