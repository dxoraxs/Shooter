using System;
using UnityEngine;

public class MainUI : MonoBehaviour
{
    [SerializeField] private GamePanel gamePanel;
    [SerializeField] private EndPanel endPanel;
    private Action restartLevel;
    private Action resetLevel;

    public void InitMainUI(Action restart, Action reset)
    {
        restart += OnClickButton;
        reset += OnClickButton;
        endPanel.InitEndPanel(restart, reset);
    }

    private void OnClickButton()
    {
        gamePanel.gameObject.SetActive(true);
        endPanel.gameObject.SetActive(false);
    }
    
    public void EndWinPanel() => ShowEndPanel(true);
    public void EndLosePanel() => ShowEndPanel(false);

    private void ShowEndPanel(bool result)
    {
        gamePanel.gameObject.SetActive(false);
        endPanel.ShowPanel(result);
    }
}
