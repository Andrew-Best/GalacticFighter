using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

[System.Serializable]
public class GameData : MonoBehaviour 
{
    public static GameData m_GData;

    //Game Data
    public float m_MasterVol;
    public float m_MusicVol;
    public float m_SFXVol;

    //Player Data
    public PlayerData m_PData;

    //Enemy Data
    public int m_Level;
    public int m_EnemyTier;

    public int m_EnemyEngineLevel;
    public int m_EnemyDamageLevel;
    public int m_EnemyHealthLevel;
    public int m_EnemyShieldLevel;
    
	void Awake () 
    {
	    if(m_GData == null)
        {
            DontDestroyOnLoad(gameObject);
            m_GData = this;
        }
        else if(m_GData != null)
        {
            Destroy(gameObject);
        }

        //Initalizing Default Game Values
        m_MasterVol = 100;
        m_MusicVol = 100;
        m_SFXVol = 100;

        //Initalize Default Enemy Data
        m_EnemyTier = 1;

        m_EnemyEngineLevel = 1 * m_EnemyTier;
        m_EnemyDamageLevel = 1 * m_EnemyTier;
        m_EnemyHealthLevel = 1 * m_EnemyTier;
        m_EnemyShieldLevel = 1 * m_EnemyTier;

        Load();
	}

    public void Save()
    {
        if (!File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Creating file at " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");
            PlayerSave pData = new PlayerSave();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_TotalScore = m_PData.m_TotalScore;
            pData.m_Salvage = m_PData.m_Salvage;
            pData.m_ShipTier = m_PData.m_ShipLevel;
            pData.m_Shield = m_PData.m_Shield;
            pData.m_HP = m_PData.m_HP;
            pData.m_EngineLevel = m_PData.m_EngineLevel;
            pData.m_ShieldLevel = m_PData.m_ShieldLevel;
            pData.m_HealthLevel = m_PData.m_HealthLevel;
            pData.m_DamageLevel = m_PData.m_DamageLevel;
            pData.m_Items = m_PData.m_Items;
            pData.m_Tokens = m_PData.m_Tokens;

            bf.Serialize(file, pData);
            file.Close();
        }
        else
        {
            Debug.Log("Saving to " + Application.persistentDataPath);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerSave pData = new PlayerSave();

            pData.m_EnemiesKilledLifetime = m_PData.m_EnemiesKilledLifetime;
            pData.m_WavesCompleted = m_PData.m_WavesCompleted;
            pData.m_TotalScore = m_PData.m_TotalScore;
            pData.m_Salvage = m_PData.m_Salvage;
            pData.m_ShipTier = m_PData.m_ShipLevel;
            pData.m_Shield = m_PData.m_Shield;
            pData.m_HP = m_PData.m_HP;
            pData.m_EngineLevel = m_PData.m_EngineLevel;
            pData.m_ShieldLevel = m_PData.m_ShieldLevel;
            pData.m_HealthLevel = m_PData.m_HealthLevel;
            pData.m_DamageLevel = m_PData.m_DamageLevel;
            pData.m_Items = m_PData.m_Items;
            pData.m_Tokens = m_PData.m_Tokens;

            bf.Serialize(file, pData);
            file.Close();
        }
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            Debug.Log("Loading");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat", FileMode.Open);
            PlayerSave pData = (PlayerSave)bf.Deserialize(file);

            m_PData.m_EnemiesKilledLifetime = pData.m_EnemiesKilledLifetime;
            m_PData.m_WavesCompleted = pData.m_WavesCompleted;
            m_PData.m_TotalScore = pData.m_TotalScore;
            m_PData.m_Salvage = pData.m_Salvage;
            m_PData.m_ShipLevel = pData.m_ShipTier;
            m_PData.m_HP = pData.m_HP;
            m_PData.m_Shield = pData.m_Shield;
            m_PData.m_EngineLevel = pData.m_EngineLevel;
            m_PData.m_ShieldLevel = pData.m_ShieldLevel;
            m_PData.m_HealthLevel = pData.m_HealthLevel;
            m_PData.m_DamageLevel = pData.m_DamageLevel;
            m_PData.m_Items = pData.m_Items;
            m_PData.m_Tokens = pData.m_Tokens;

            file.Close();
        }
        else
        {
            Debug.Log("Failed to load, file doesn't exist");
        }
    }
}