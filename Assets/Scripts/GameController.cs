using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    private int currentNumberOfTanks;
    public int maxNumberOfTanks = 10;
    public int spawnRadius = 14;
    public GameObject tankPrefab;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        currentNumberOfTanks = GameObject.FindObjectsOfType<Tank>().Length;
        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            if (currentNumberOfTanks < maxNumberOfTanks)
            {
                SpawnTank();
            }

            yield return new WaitForSeconds(2.0f);
        }
    }

    private void SpawnTank()
    {
        // posição aleatório no raio de um circulo
        Vector2 randomCirclePos = Random.insideUnitCircle * spawnRadius;

        Vector3 spawnPos = new Vector3(randomCirclePos.x, 0, randomCirclePos.y);

        Instantiate(tankPrefab, spawnPos, Quaternion.Euler(0, Random.value * 360, 0));

        currentNumberOfTanks++;
    }

    public void RegisterTankDown()
    {
        currentNumberOfTanks--;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
