using UnityEngine;
using TMPro;

// <summary>
// Class for the skull spawner that shoots shield bullets
// </summary>
public class Skull_Spawner : MonoBehaviour
{
    // Enum for the different types of spawners
    public enum SpawnerType {Straight,Snake,Spin}

    // Variables
    [Header("Bullet Attributes")] // Header to group of variables in the inspector
    public GameObject bullet; // the bullet object from the prefab to be spawned
    public float speed = 0f; // Speed of the buller
    public int number_arms = 0; // Number of arms to shoot bullets in all directions

    [Header("Spawner Attributes")] // Header to group of variables in the inspector
    public SpawnerType spawnerType; // Type of spawner from the 
    public float spawnRate = 0f; // Delay between each bullet spawn

    private float spawnTimer = 0f; // Timer to keep track of the spawn rate
    private int numberBullets = 0; // Counter for the number of bullets
    public TextMeshProUGUI bulletCountText; // Variable to display the bullet count on the UI 

    private float timerType = 0f; // Timer to keep track of the time spent in the current spawner type
    private float totalTimeType = 10f; // Time to spend in each spawner type
    private int count_changes = 0; // Counter for the number of type changes
    private bool startPos = false; // Flag to indicate if the start position has been set
    private float rotationTimer = 0f; // Flag to change the rotation direction in Snake type

    private Vector3 startPosition; // vector to store the initial position of the spawner
    private Quaternion startRotation; // quaternion to store the initial rotation of the spawner

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; // store the initial position
        startRotation = transform.rotation; // store the initial rotation
    }

    // Update is called once per frame
    void Update(){
        spawnTimer += Time.deltaTime; // Sum the time since the last frame
        // Check if it's time to change the spawner type
        if (timerType >= totalTimeType){
            ChangeSpawnerType(); // change the spawner type
            timerType = 0f; // reset the type timer
            startPos = false; // reset the start position flag
            count_changes++; // increment the change counter
        }

        // Check if the spawner equals Snake
        if (spawnerType == SpawnerType.Snake){
            // if the start position has not been set, it sets it
            if (!startPos){
                transform.position = startPosition;
                transform.rotation = startRotation;
                startPos = true;
            }
            // Rotates the spawner to certain speed
            if (rotationTimer<1){
                transform.Rotate(0, 0, 70f * Time.deltaTime);
                rotationTimer += Time.deltaTime;
            } else {
                transform.Rotate(0, 0, -70f * Time.deltaTime);
                rotationTimer += Time.deltaTime;
                if (rotationTimer>2) rotationTimer=0;
            }

        } else if (spawnerType == SpawnerType.Spin){
            if (!startPos){
                transform.position = startPosition;
                transform.rotation = startRotation;
                startPos = true;
            }
            // Move the spawner in a Spin pattern
            transform.Rotate(0, 0, 70f * Time.deltaTime);
        } else {
            if (!startPos){
                transform.position = startPosition;
                transform.rotation = startRotation;
                startPos = true;
            }
        }

        // Check if it's time to spawn a new bullet
        if (spawnTimer >= spawnRate){
            // if the number of changes is less than 3, it spawns bullets
            if (count_changes < 3) {
                // Depending on the spawner type, it calls the appropiate fire function
                if (spawnerType == SpawnerType.Snake)
                    Fire();
                else if (spawnerType == SpawnerType.Spin)
                    FireSpin();
                else 
                    FireAllAngles();
                spawnTimer = 0; // reset the spawn timer
            }
        }
        timerType += Time.deltaTime; // sum the time since the last frame
    }

    void Fire(){
        for (int i = 0; i < 8; i++){
            // Calculate the angle for each bullet depending on the number of arms
            float bulletAngle = i * (360 / 8);
            // Instantiate the bullet at the spawner position with the calculated rotation 
            GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.Euler(0,0, bulletAngle+transform.rotation.eulerAngles.z));
            // Set the bullet speed and spawner reference
            bulletObject.GetComponent<Shield_Bullet>().speed = speed;
            bulletObject.GetComponent<Shield_Bullet>().spawner = this;  
            // Increment the bullet counter
            numberBullets++;
            // Update the bullet count text
            bulletCountText.text = "Contador de balas: " + numberBullets;
        }
    }

    // Function to fire bullets in all directions
    void FireAllAngles(){
        for (int i = 0; i < number_arms; i++){
            // Calculate the angle for each bullet depending on the number of arms
            float bulletAngle = i * (360 / number_arms);
            // Instantiate the bullet at the spawner position with the calculated rotation
            GameObject bulletObject = Instantiate(bullet, transform.position, Quaternion.Euler(0,0, bulletAngle));
            // Set the bullet speed and spawner reference
            bulletObject.GetComponent<Shield_Bullet>().speed = speed;
            bulletObject.GetComponent<Shield_Bullet>().spawner = this;  
            // Increment the bullet counter
            numberBullets++;
            // Update the bullet count text
            bulletCountText.text = "Contador de balas: " + numberBullets;
        }
    }

    void FireSpin(){
        // Instantiate the bullet at the spawner position with no rotation
        GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,0));
        // Set the bullet speed and spawner reference
        spawnedBullet.GetComponent<Shield_Bullet>().speed = speed;
        spawnedBullet.GetComponent<Shield_Bullet>().spawner = this;
        // Set the bullet rotation to match the spawner rotation
        spawnedBullet.transform.rotation = transform.rotation;

        // Increment the bullet counter
        numberBullets += 1; 
        // Update the bullet count text
        bulletCountText.text = "Contador de balas: " + numberBullets;
    }

    public void BulletCleanup(){
        // Decrement the bullet once it is destroyed
        numberBullets -= 1;
        // Update the bullet count text
        bulletCountText.text = "Contador de balas: " + numberBullets;
    }

    // Function to change the spawner type
    void ChangeSpawnerType(){
        if (spawnerType == SpawnerType.Straight)
            spawnerType = SpawnerType.Snake;
        else if (spawnerType == SpawnerType.Snake)
            spawnerType = SpawnerType.Spin;
        else
            spawnerType = SpawnerType.Straight;
    }
}