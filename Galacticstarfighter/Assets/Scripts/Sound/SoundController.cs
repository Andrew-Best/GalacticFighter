using UnityEngine;
using System.Collections;

public class SoundController : MonoBehaviour
{
    #region Variables
    public GameData m_GData;

    public float m_MasterVolume;
    public float m_MusicVolume;
    #endregion

	// Use this for initialization
	void Start () 
    {
        m_MasterVolume = m_GData.m_MasterVol / 100.0f;
        m_MusicVolume = m_GData.m_MusicVol / 100.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        SetVolume();
        AudioListener.volume = m_MasterVolume / 100.0f;
    }

    public void SetVolume()
    {
        m_MasterVolume = m_GData.m_MasterVol / 100.0f;
        m_MusicVolume = m_GData.m_MusicVol / 100.0f;
    }
}
