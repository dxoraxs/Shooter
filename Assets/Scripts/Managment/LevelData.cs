using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private Transform paretnPointEnemySpawn;
    private Vector3[] points;

    public Vector3[] GetPointSpawn()
    {
        if (points == null)
        {
            InitPoint();
        }

        return points;
    }
    
    private void InitPoint()
    {
        var listPoint = new List<Vector3>();
        foreach (Transform child in paretnPointEnemySpawn)
            listPoint.Add(child.position);
        points = listPoint.ToArray();
    }
}