using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    private List<Character> enemies = new List<Character>();
    private int countDied;
    private Action onAllEnemyDied;

    public void InitEnemySpawn(Action action) => onAllEnemyDied = action;

    public void SpawnEnemy(Vector3[] points, PoolObject bulletPool, int health)
    {
        foreach (var character in enemies.Where(character => character != null))
        {
            Destroy(character.gameObject);
        }
        
        enemies.Clear();
        countDied = 0;
        foreach (var point in points)
        {
            var newEnemy = Instantiate(enemyPrefab, point, Quaternion.identity);
            newEnemy.InitEnemy(health, CountEnemyDied, bulletPool);
            enemies.Add(newEnemy);
        }
    }

    private void CountEnemyDied()
    {
        countDied++;
        if (enemies.Count == countDied)
            onAllEnemyDied?.Invoke();
    }
}