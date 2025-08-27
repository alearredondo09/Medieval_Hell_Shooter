using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull_Spawner : MonoBehaviour
{
    public enum SpawnerType {Straight,Spin,Wave}

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float speed = 3f;

    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public float spawnRate = 0.1f;

    private GameObject spawnedBullet;
    private float spawnTimer = 0f;
    private int number_bullets = 0;

   
    private float amplitude = 1.4f;
    private float frequency = 5f;

    private float type_timer = 0f;
    private float time_per_type = 10f; // 10 seconds 
    private int count_changes = 0;
    private bool start_pos = false;
    
    private Vector3 startPosition;
    private Quaternion startRotation;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position; 
        startRotation = transform.rotation;
        Debug.Log("Starting position: " + startPosition); 
        Debug.Log("Start rotation: " + startRotation); 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (type_timer >= time_per_type)
        {
            //Debug.Log("Entro al changing type");
            ChangeSpawnerType();
            type_timer = 0f; // reinicia el contador
            start_pos = false;
            count_changes++;
        }

        //Debug.Log("Time Delta: " + Time.deltaTime);
        if (spawnerType == SpawnerType.Spin)
        {
            if (!start_pos){
                transform.position = startPosition;
                transform.rotation = startRotation;
                Debug.Log("Rotation: " + transform.rotation);
                start_pos = true;
            }
            transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z + 1f);
        } else if (spawnerType == SpawnerType.Wave)
        {
            if (!start_pos){
                transform.position = startPosition;
                transform.rotation = startRotation;
                Debug.Log("Rotation: " + transform.rotation);
                start_pos = true;
            }
            transform.position = new Vector3(
                startPosition.x,
                startPosition.y + Mathf.Sin(Time.time * frequency) * amplitude, // Se hace la onda en la coordenada de X tiempo desde que inicio la escena
                startPosition.z
            );
        } else {
            if (!start_pos)
            {
                transform.position = startPosition;
                transform.rotation = startRotation;
                Debug.Log("Rotation: " + transform.rotation);
                start_pos = true;
            }
        }

        if (spawnTimer >= spawnRate){
            if (count_changes < 3) {
                Fire();
                spawnTimer = 0;
            }
        }
        type_timer += Time.deltaTime;
        //Debug.Log("Time in current type: " + type_timer);
    }

    private void Fire(){
        if (bullet){
            spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            spawnedBullet.GetComponent<Shield_Bullet>().speed = speed;
            spawnedBullet.GetComponent<Shield_Bullet>().spawner = this;
            spawnedBullet.transform.rotation = transform.rotation;
            number_bullets += 1;
            //Debug.Log("Number of bullets: " + number_bullets);
        }
    }

    public void BulletCleanup(){
        number_bullets -= 1;
        Debug.Log("Number of bullets: " + number_bullets);
    }

    private void ChangeSpawnerType()
    {
        // Alterna entre los tipos en orden
        if (spawnerType == SpawnerType.Straight)
            spawnerType = SpawnerType.Spin;
        else if (spawnerType == SpawnerType.Spin)
            spawnerType = SpawnerType.Wave;
        else
            spawnerType = SpawnerType.Straight;

        Debug.Log("Nuevo tipo de spawner: " + spawnerType);
    }
}
