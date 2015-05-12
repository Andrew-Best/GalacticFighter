using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    #region Variables
    public GameData m_GData;

    public Button m_Start;
    public Button m_Quit;
 
    public Slider m_MasterVolControl;
    public Slider m_MusicVolControl;
    #endregion

    public void Awake()
    {
        m_GData.Load();
        m_MasterVolControl.value = m_GData.m_MasterVol;
        m_MusicVolControl.value = m_GData.m_MusicVol;
    }

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

    public void SetVolume()
    {
        m_GData.m_MasterVol = m_MasterVolControl.value;
        m_GData.m_MusicVol = m_MusicVolControl.value;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OptionsMenu()
    {
        m_MasterVolControl.value = m_GData.m_MasterVol;
        m_MusicVolControl.value = m_GData.m_MusicVol; 
    }
}
