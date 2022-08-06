using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public GameObject basicEnemy;

    public float timeBetweenWaves;
    public float timeIntermission;
    public float timeVariable;

    public bool inRound;
    public bool isIntermission;
    public bool isRoundStart;

    public int round;

    private void Start()
    {
        inRound = false;
        isIntermission = false;
        isRoundStart = true;

        timeVariable = Time.time + timeIntermission;

        round = 1;
    }

    private void SpawnEnemies()
    {
        StartCoroutine("ISpawnEnemies");
    }

    IEnumerator ISpawnEnemies()
    {
        for (int i = 0; i < round; i++)
        {
            GameObject newEnemy = Instantiate(basicEnemy, MapGenerator.startTile.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
        }
    }

    private void Update()
    {
        if (isRoundStart)
        {
            if (Time.time >= timeVariable)
            {
                isRoundStart = false;
                inRound = true;

                SpawnEnemies();
                return;
            }
        }
        else if (isIntermission)
        {
            if (Time.time >= timeVariable)
            {
                isIntermission = false;
                inRound = true;

                SpawnEnemies();
            }
        }
        else if (inRound)
        {
            if (EnemyManager.enemies.Count <= 0)
            {
                isIntermission = true;
                inRound = false;

                timeVariable = Time.time + timeBetweenWaves;
                round++;
            }
        }
    }
}
