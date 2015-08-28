using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Variables
    /// <summary>Game Data</summary>
    public GameData m_GData;
    /// <summary>Start Button</summary>
    public Button m_Start;
    /// <summary>Quit Button</summary>
    public Button m_Quit;
    /// <summary>Master Volume Slider</summary>
    public Slider m_MasterVolControl;
    /// <summary>Music Volume Slider</summary>
    public Slider m_MusicVolControl;
    #endregion

    public void Awake()
    {
        m_MasterVolControl.value = m_GData.m_MasterVol;
        m_MusicVolControl.value = m_GData.m_MusicVol;
    }

    /// <summary>Starts the game - button function</summary>
    public void StartGame()
    {
        m_GData.m_MasterVol = m_MasterVolControl.value;
        m_GData.m_MusicVol = m_MusicVolControl.value;

        Application.LoadLevel("StarMap");
    }

    public void Update()
    {
        SetVolume();
    }

    /// <summary>Changes the volume - slider function</summary>
    public void SetVolume()
    {
        m_GData.m_MasterVol = m_MasterVolControl.value;
        m_GData.m_MusicVol = m_MusicVolControl.value;
    }

    /// <summary>Quits the game - button function</summary>
    public void Quit()
    {
        Application.Quit();
    }

    /// <summary>Opens the options menu - button function</summary>
    public void OptionsMenu()
    {
        m_MasterVolControl.value = m_GData.m_MasterVol;
        m_MusicVolControl.value = m_GData.m_MusicVol; 
    }
}
