using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private int health;
    protected Action onManDied;

    public void InitCharacter(Action onManDied) => this.onManDied = onManDied;
    public void ResetCharacter(int health) => this.health = health;

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0) Death();
    }

    protected virtual void Death() => onManDied?.Invoke();
}