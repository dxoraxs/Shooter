using System.Collections.Generic;
using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [SerializeField] private Bullet objectPrefab;
    [SerializeField] private int countPool;
    private List<Bullet> pool = new List<Bullet>();
    private int damage;
    
    public void StartSpawn(int damage)
    {
        this.damage = damage;
        for (int i = 0; i < countPool; i++)
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        var _object = Instantiate(objectPrefab, transform);
        _object.SetDamage(damage);
        AddDisable(_object);
    }

    private void AddDisable(Bullet _object)
    {
        if (_object == null || _object.gameObject == null) return;
        pool.Add(_object);
        _object.gameObject.SetActive(false);
    }

    public Bullet GetObject(Vector3 position)
    {
        if (pool.Count <= 0)
        {
            SpawnObject();
        }

        var currentObject = pool[0];
        pool.Remove(currentObject);
        currentObject.transform.position = position;
        currentObject.gameObject.SetActive(true);
        return currentObject;
    }

    public void ReturnObject(Bullet _object)
    {
        if (pool.Contains(_object)) return;
        AddDisable(_object);
    }
}