// import
using UnityEngine;

/// <summary>
/// Script for the shield bullets fired by the skull spawner
/// </summary>
public class Shield_Bullet : MonoBehaviour
{
    // Variables
    public Skull_Spawner spawner; // reference to the spawner that created this bullet
    public float speed = 0f;      // speed of the bullet
    private Vector2 spawnPoint;   // Vector that stores the initial position of the buller
    private float timer = 0f; // Timer to keep track of the time since the bullet was spawned
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Stores the initial position of the bullet
        spawnPoint = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the bullet if it goes out of bounds
        if (transform.position.x < -17 || transform.position.x > 17
            || transform.position.y < -8.5 || transform.position.y > 8.5){
                // calls the function in the spáwner to decrease the bullet count
                spawner.BulletCleanup(); 
                // Destroy the bullet
                Destroy(this.gameObject);  
            } 
        timer += Time.deltaTime; // sum the time since the last frame
        transform.position = Movement(timer); // update the position of the bullet
    }

    // Function that defines the movement of the bullet
    Vector2 Movement(float timer)
    {
        // Calculate the new position based on the speed, direction and time
        // transform.right is a vector that point to the right of the object. 
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        // return the new position
        return new Vector2(x+spawnPoint.x, y+spawnPoint.y);
    }
}
