﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static int Level { get; private set; }


    public static int enemyCounter;


    protected List<GameObject> spawnPointsEnemy;
    protected List<GameObject> spawnPointsHero;
    //protected List<GameObject> spawnPointsObstacle;

    public GameObject hero;

    public List<GameObject> enemies;
    [HideInInspector] public List<int> enemiesCounter;

    //public List<GameObject> obstacles;
    //[HideInInspector] public List<int> obstaclesCounter;


    // Start is called before the first frame update
    void Start()
    {
        enemiesCounter = new List<int>();
        enemiesCounter.AddRange(Enumerable.Repeat<int>(0, enemies.Count));
        enemyCounter = 0;

        //spawnPointsObstacle = new List<GameObject>();
        spawnPointsEnemy = new List<GameObject>();
        spawnPointsHero = new List<GameObject>();

        //spawnPointsObstacle.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointObstacle"));
        spawnPointsEnemy.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointEnemy"));
        spawnPointsHero.AddRange(GameObject.FindGameObjectsWithTag("SpawnPointHero"));


        SpawnSettings();

        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public static bool LevelCompleted()
    {
        if (enemyCounter <= 0)
        {
            Level++;
            return true;
        }

        return false;
    }

    public static void ResetLevel()
    {
        Level = 1;
    }


    protected void SpawnSettings()
    {
        switch (Level)
        {
            case 1:
                enemiesCounter[0] = 0;//circleEnemyCount
                enemiesCounter[1] = 1;//triangleEnemyCount
                enemiesCounter[2] = 0;//squareEnemyCount
                break;
            case 2:
                enemiesCounter[0] = 1;//circleEnemyCount
                enemiesCounter[1] = 1;//triangleEnemyCount
                enemiesCounter[2] = 0;//squareEnemyCount
                break;
            case 3:
                enemiesCounter[0] = 5;//circleEnemyCount
                enemiesCounter[1] = 10;//triangleEnemyCount
                enemiesCounter[2] = 5;//squareEnemyCount
                break;
            default:
                break;
        }

        foreach(int count in enemiesCounter)
        {
            enemyCounter += count;
        }
    }


    protected void Spawn()
    {
        SpawnHero();

        SpawnEnemy();
    }

    protected void SpawnHero()
    {
        if (spawnPointsHero.Count <= 0)//check the availability of spawn points
        {
            Debug.Log("MISSED SPAWN POINTS - HERO");
        }

        int positionNumber;
        positionNumber = Random.Range(0, spawnPointsHero.Count - 1);

        if (GameObject.Find("Hero") != null)
        {
            GameObject.Find("Hero").transform.position = spawnPointsHero[positionNumber].transform.position;
        }
        else
        {
            Instantiate(hero, spawnPointsHero[positionNumber].transform).name = "Hero";
        }
    }

    protected void SpawnEnemy()
    {
        int positionNumber;

        for (int i = 0; i < enemies.Count; i++)
        {
            for (int j = 0; j < enemiesCounter[i]; j++)
            {
                if (spawnPointsEnemy.Count <= 0)//check the availability of spawn points
                {
                    Debug.Log("MISSED SPAWN POINTS - ENEMY");
                }


                positionNumber = Random.Range(0, spawnPointsEnemy.Count - 1);
                Instantiate(enemies[i], spawnPointsEnemy[positionNumber].transform);

                spawnPointsEnemy.RemoveAt(positionNumber);
            }
        }
    }
}