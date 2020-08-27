using System;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
    private Action restartLevel;
    private Action resetLevel;
    
    public void InitEndPanel(Action restart, Action reset)
    {
        restartLevel = restart;
        resetLevel = reset;
    }
    
    public void ShowPanel(bool result)
    {
        gameObject.SetActive(true);
        winPanel.SetActive(result);
        losePanel.SetActive(!result);
    }

    public void OnClickButtonNextLevel() => resetLevel?.Invoke();
    public void OnClickButtonRestartLevel() => restartLevel?.Invoke();
}
