using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private int score = 0;
    public float speed = 5f;
    private Rigidbody rb;
    public int health = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        // WASD buttons enabled
        float direction_x = Input.GetAxis("Horizontal");
        float direction_z = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(direction_x, 0.0f, direction_z).normalized;

        // Rigid Body are for collisions
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If Player collides with Tag "Pickup"
        if (other.CompareTag("Pickup"))
        {
            score += 1;
            Debug.Log("Score: " + score);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Trap"))
        {
            health--;
            Debug.Log("Health: " + health);
        }

        if (other.CompareTag("Goal"))
        {
            Debug.Log("You win!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Debug.Log("Game Over!");

            Scene currentScene = SceneManager.GetActiveScene();

            SceneManager.LoadScene(currentScene.name);
        }
    }
}