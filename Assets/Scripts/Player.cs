﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables
    public float movementSpeed;
    public GameObject camera;
    public GameObject bulletSpawnPoint;
    public float waitTime;
    public GameObject bullet;
    private Transform bulletSpawned;
    public GameObject playerObj;
    public float points;
    public float maxHealth;
    public float health;
    
    // Méthodes

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Le joueur fait face à la souris
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDist = 0.0f;

        if (playerPlane.Raycast(ray, out hitDist))
        {
            Vector3 targetPoint = ray.GetPoint(hitDist);
            Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
            targetRotation.x = 0;
            targetRotation.z = 0;
            playerObj.transform.rotation=Quaternion.Slerp(playerObj.transform.rotation, targetRotation, 7f * Time.deltaTime);
        }
        
        //Mouvement du joueur
        
        if (Input.GetKey(KeyCode.Z))
            transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
            transform.Translate(Vector3.left*movementSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right*movementSpeed*Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back*movementSpeed*Time.deltaTime);
        
        //Tir

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        // mort du joueur
        if (health <=0)
            Die();
    }

    void Shoot()
    {
        bulletSpawned = Instantiate(bullet.transform, bulletSpawnPoint.transform.position, Quaternion.identity);
        bulletSpawned.rotation = bulletSpawnPoint.transform.rotation;
    }
    
    //

    public void Die()
    {
        print("Vous êtes Mort");
    }
}