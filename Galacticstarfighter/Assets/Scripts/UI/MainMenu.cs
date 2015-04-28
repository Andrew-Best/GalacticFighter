using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour 
{
    public GameData m_GData;

    public Button m_Start;
    public Button m_Quit;
    public Slider m_MasterVolControl;
    public Slider m_SFXVolControl;
    public Slider m_MusicVolControl;

    public void StartGame()
    {
        m_GData.m_MasterVol = m_MasterVolControl.value;
        m_GData.m_MusicVol = m_MusicVolControl.value;
        m_GData.m_SFXVol = m_SFXVolControl.value;

        Application.LoadLevel("StarMap");
    }

    public void Quit()
    {
    }

    public void OptionsMenu()
    {
        m_MasterVolControl.value = m_GData.m_MasterVol;
        m_MusicVolControl.value = m_GData.m_MusicVol; 
        m_SFXVolControl.value = m_GData.m_SFXVol;
    }
}
