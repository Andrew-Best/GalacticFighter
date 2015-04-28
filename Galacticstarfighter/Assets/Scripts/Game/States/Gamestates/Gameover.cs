using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Gameover : MonoBehaviour 
{
    public GameData m_GData;
    public PlayerData m_PData;

    public Text m_TotalEnemiesKilled;
    public Text m_SalvageCollected;

    public Button m_Continue;
    public Button m_Quit;

    public void Awake()
    {
        m_TotalEnemiesKilled.text = m_PData.m_EnemiesKilledLifetime.ToString();
        m_SalvageCollected.text = m_PData.m_Salvage.ToString();
    }

    public void Continue()
    {
        Camera.main.GetComponent<GameController>().LoadSoftSave(Camera.main.GetComponent<GameController>().m_Player);
        m_GData.Save();
        Application.LoadLevel("StarMap");
    }

    public void Quit()
    {
        Camera.main.GetComponent<GameController>().LoadSoftSave(Camera.main.GetComponent<GameController>().m_Player);
        m_GData.Save();
        Application.LoadLevel("Start");
    }
}
