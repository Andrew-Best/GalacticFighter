using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour 
{
    public Button m_Continue;
    public Button m_Save_and_Quit;

    public GameData m_GData;
    public PlayerData m_PData;

    public Text m_CurrentKills;
    public Text m_SalvageCollected;

    public void Awake()
    {
        m_CurrentKills.text = m_PData.m_EnemiesKilledLifetime.ToString();
        m_SalvageCollected.text = m_PData.m_Salvage.ToString();
    }

    public void Continue()
    {
        Camera.main.GetComponent<GameController>().LoadSoftSave(Camera.main.GetComponent<GameController>().m_Player);
        //save progress and let player continue playing
        m_GData.Save();
        Application.LoadLevel("StarMap");
    }

    public void SaveAndQuit()
    {
        //save player progress and quit application
        m_GData.Save();
        Application.LoadLevel("Start");
    }
}
