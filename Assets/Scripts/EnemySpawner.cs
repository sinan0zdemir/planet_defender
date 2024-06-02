using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float waveDelay = 5f;
    [SerializeField] private float difficultyScale = 0.75f;

    [Header("Events")]
    public static UnityEvent onEnemyKilled = new UnityEvent();

    private int currentWave = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private GameController gameController;

    // Singleton instance
    public static EnemySpawner instance;

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

        onEnemyKilled.AddListener(EnemyKilled);
    }

    void Start()
    {
        gameController = FindObjectOfType<GameController>(); // Find the GameController instance in the scene
        StartCoroutine(StartWave());
    }

    void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(currentWave, difficultyScale));
    }

    private IEnumerator StartWave()
    {
        yield return new WaitForSeconds(waveDelay);
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[0];
        Instantiate(enemyToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
    }

    public void EnemyKilled()
    {
        enemiesAlive--;
        gameController.AddScore(10); // Adding 10 points for each enemy killed
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        currentWave++;
        StartCoroutine(StartWave());
    }
}
