using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Win : MonoBehaviour 
{
    public Button m_Continue;
    public Button m_Save_and_Quit;

    public GameData m_GData;

    public Text m_CurrentKills;
    public Text m_SalvageCollected;

    public void Awake()
    {
        m_CurrentKills.text = m_GData.m_PData.m_EnemiesKilled.ToString();
        m_SalvageCollected.text = m_GData.m_PData.m_Salvage.ToString();
    }

    public void Continue()
    {
        //save progress and let player continue playing
        m_GData.Save(m_GData.m_PData);
        Application.LoadLevel("StarMap");
    }

    public void SaveAndQuit()
    {
        //save player progress and quit application
        m_GData.Save(m_GData.m_PData);
        Application.LoadLevel("Start");
    }
}
