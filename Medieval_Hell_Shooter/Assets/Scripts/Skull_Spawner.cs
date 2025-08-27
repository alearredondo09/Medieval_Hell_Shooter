using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull_Spawner : MonoBehaviour
{
    public enum SpawnerType {Straight,Spin}

    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float speed = 1f;

    [Header("Spawner Attributes")]
    public SpawnerType spawnerType;
    public float spawnRate = 1f;

    private GameObject spawnedBullet;
    private float timer = 0f;

    private int number_bullets = 0;
    private int time_per_type = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("Time Delta: " + Time.deltaTime);
        if (spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z + 1f);
        if (timer >= spawnRate){
            Fire();
            timer = 0;
        }
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
        //Debug.Log("Number of bullets: " + number_bullets);
    }
}
