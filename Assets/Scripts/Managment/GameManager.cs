using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private Character player;
    [SerializeField] private MainUI mainUi;
    private LevelData level;
    private EnemySpawner enemySpawner;
    private PlayerController playerController;
    private PoolObject[] bulletPool;
    private int selectLevelIndex;

    private void Awake()
    {
        enemySpawner = GetComponent<EnemySpawner>();
        bulletPool = GetComponents<PoolObject>();
        bulletPool[0].StartSpawn(gameSettings.GetDamageEnemy);
        bulletPool[1].StartSpawn(gameSettings.GetDamagePlayer);
        playerController = GetComponent<PlayerController>();
        playerController.InitController(player, bulletPool[1], mainUi.EndLosePanel);
        mainUi.InitMainUI(ResetLevel, RestartLevel);
        enemySpawner.InitEnemySpawn(mainUi.EndWinPanel);
        
        StartLevel();
    }

    private void StartLevel()
    {
        InitLevel();
        enemySpawner.SpawnEnemy(level.GetPointSpawn(), bulletPool[0], gameSettings.GetHealthEnemy);
        playerController.SetPlayerSetting(gameSettings.GetHealthPlayer);
    }

    public void RestartLevel()
    {
        selectLevelIndex++;
        if (gameSettings.GetLevels.Length <= selectLevelIndex)
            selectLevelIndex = 0;
        Destroy(level.gameObject);
        StartLevel();
    }

    public void ResetLevel()
    {
        Destroy(level.gameObject);
        StartLevel();
    }

    private void InitLevel()
    {
        var levels = gameSettings.GetLevels;
        level = Instantiate(levels[selectLevelIndex]);
    }
}
