using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Create GameSettings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] private LevelData[] levels;
    [Header("Header")] [SerializeField] private uint healthPlayer;
    [SerializeField] private uint healthEnemy;
    [Header("Damage")] [SerializeField] private uint playerDamage;
    [SerializeField] private uint enemyDamage;

    public int GetHealthEnemy => (int) healthEnemy;
    public int GetHealthPlayer => (int) healthPlayer;
    public int GetDamageEnemy => (int) enemyDamage;
    public int GetDamagePlayer => (int) playerDamage;
    public LevelData[] GetLevels => levels;
}