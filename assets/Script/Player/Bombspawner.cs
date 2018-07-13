using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombspawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string Name;
        public Transform[] Supplies;
        public int Count;
        public float Rate;
    }

    #region CLASS_VARIAVLES

    //public
    public Wave[] waves;
    public float timeBetweenWaves = 5f;
    public float waveCountdown;
    public SpawnState state = SpawnState.COUNTING;

    //private
    private int nextWave = 0;
    private float searchCountdown = 1f;
    private int currentWave = 0;

    #endregion

    void Start()
    {
        waveCountdown = timeBetweenWaves;
    }

    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    void WaveCompleted()
    {
        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
        }
        else
        {
            nextWave++;
        }

    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("SupplyDrop").Length == 0)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < _wave.Count; i++)
        {
            for (int j = 0; j < _wave.Supplies.Length; j++)
            {
                SpawnEnemy(_wave.Supplies[j]);
                yield return new WaitForSeconds(1f / _wave.Rate);
            }
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform enemy)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.1f, 0.1f));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.9f, 1f));

        Transform e = Instantiate(enemy);
        e.position = new Vector2(Random.Range(min.x, max.x), max.y);
        e.rotation = transform.rotation;
    }
}
