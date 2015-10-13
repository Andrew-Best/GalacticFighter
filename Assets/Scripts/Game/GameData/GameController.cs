using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    #region Variables
    /// <summary>Text to display instructions</summary>
    public Text m_ControlText;
    /// <summary>Game Data script</summary>
    public GameData m_GData;
    /// <summary>Player Data script</summary>
    public PlayerData m_PData;
    /// <summary>Spawn Player script</summary>
    public SpawnPlayer m_PSpawn;
    /// <summary>Enemy Spawn script</summary>
    public EnemySpawn m_ESpawn;
    /// <summary>Waves script</summary>
    public Waves m_Waves;
    /// <summary>Player object</summary>
    public GameObject m_Player;
    /// <summary>Win canvas</summary>
    public Canvas m_Win;
    /// <summary>Lose canvas</summary>
    public Canvas m_Lose;
    /// <summary>Boss Health Panel</summary>
    public CanvasGroup m_BossPanel;
    /// <summary>Primary UI</summary>
    public Canvas m_MainUI;
    /// <summary>UI Controller Script</summary>
    public UIControl m_UIControl;
    /// <summary>Current Level</summary>
    public int m_Level;
    /// <summary>The number of lives the player has</summary>
    public int m_Lives = 3;
    /// <summary>Player's current score</summary>
    public int m_Score = 0;
    /// <summary>Total score - for stat purposes</summary>
    public int m_TotalScore;
    /// <summary>Number of kills so far</summary>
    public int m_Kills;
    /// <summary>Amount of salvage attained</summary>
    public int m_Salvage;
    /// <summary>A Temporary list of items</summary>
    public List<String> m_TempItems;

    /// <summary>Temporary amount of kills -- Used in the event of restart</summary>
    public int m_TempKills;
    /// <summary>Temporary score -- Used in the event of restart</summary>
    public int m_TempScore;
    /// <summary>Temporary amount of salvage -- Used in the event of restart</summary>
    public int m_TempSalvage;
    /// <summary>Temporary wave number -- Used in the event of restart</summary>
    public int m_TempWaveNum;
    /// <summary>Temporary amount of kills lifetime -- Used in the event of restart</summary>
    public int m_TempEnemiesKilledLifetime;
    /// <summary>Temporary total score -- Used in the event of restart</summary>
    public int m_TempTotalScore;
    /// <summary>Temporary waves completed -- Used in the event of restart</summary>
    public int m_TempWavesCompleted;
    /// <summary>Temporary ship level -- Used in the event of restart</summary>
    public int m_TempShipLevel;
    /// <summary>Temporary engine level -- Used in the event of restart</summary>
    public int m_TempEngineLevel;
    /// <summary>Temporary damage level -- Used in the event of restart</summary>
    public int m_TempDamageLevel;
    /// <summary>Temporary health level -- Used in the event of restart</summary>
    public int m_TempHealthLevel;
    /// <summary>Temporary shield level -- Used in the event of restart</summary>
    public int m_TempShieldLevel;
    /// <summary>Temporary flag for whether or not player has shield -- Used in the event of restart</summary>
    public bool m_TempHasShield;
    /// <summary>Temporary current HP -- Used in the event of restart</summary>
    public int m_TempHP;
    /// <summary>Temporary current shield -- Used in the event of restart</summary>
    public int m_TempShield;
    /// <summary>Temporary damage modifier -- Used in the event of restart</summary>
    public int m_TempDamageModifer;
    /// <summary>Temporary engine modifier -- Used in the event of restart</summary>
    public int m_TempEngineModifier;
    /// <summary>Flag for restart UI</summary>
    public bool m_Restart;
    /// <summary>Flag for Game Over UI</summary>
    public bool m_GameOver;
    /// <summary>Flag for playing the game</summary>
    public bool m_Play;
    #endregion

    void Awake()
    {
        m_BossPanel.alpha = 0;

        m_MainUI.enabled = true;

        m_Lose.enabled = false;
        m_Win.enabled = false;

        m_Restart = false;
        m_GameOver = false;
        m_Play = false;

        m_PSpawn.Spawn();
        m_Player = m_PSpawn.m_Player;
        m_GData = GameObject.Find("GameData").GetComponent<GameData>();
        m_PData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Return))
        {
            m_GData.Save(m_PData);
        }

        if (!m_Play)
        {
            m_Player.GetComponent<PlayerController>().enabled = false;//disable player
            m_ControlText.text = "Press 'Z' to begin";

            if (Input.GetKey(KeyCode.Z))
            {
                m_Play = true;
                Play();
            }
        }

        if (m_Restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Respawn();
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                m_Restart = false;
                Application.LoadLevel("StarMap");
            }
        }
     }

    /// <summary>Starts the game</summary>
    public void Play()
    {
        if(m_Play)
        {
            m_ControlText.text = "";
            m_Player.GetComponent<PlayerController>().enabled = true;//enable player
            m_ESpawn.SetShipPrefab();
            m_ESpawn.AISpawn();
        }
    }

    /// <summary>Sets values required in the player loses the game</summary>
    public void GameOver()
    {
        m_Play = false;
        m_MainUI.enabled = false;
        m_ESpawn.DestroyAllEnemies();
        m_Lose.enabled = true;
    }

    /// <summary>Sets values required if the player wins the game</summary>
    public void Win()
    {
        m_Play = false;
        m_MainUI.enabled = false;
        m_ESpawn.DestroyAllEnemies();
        m_Win.enabled = true;
    }

    /// <summary>Respawn's the wave and character</summary>
	public void Respawn()
    {
        m_ControlText.text = "";
        m_Restart = false;
        m_Waves.RestartCurrentWave();
    }

    /// <summary>Once the game has ended, as long as the player has lives, enable the restart. Otherwise this function calls GameOver</summary>
    public void EnableRestart()
    {
        m_Lives -= 1;

        if (m_Lives > 0)
        {
            m_ESpawn.DestroyAllEnemies();

            m_Restart = true;

            m_ControlText.text = "Press 'R' for Restart or 'Q' to Quit";
        }
        else
        {
            GameOver();
        }
    }

    /// <summary>Sets player stats in preparation for saving</summary>
    public void SetPlayerSave(GameObject player)
    {
        m_PData.m_EnemiesKilled += m_Kills;
        m_PData.m_TotalScore += m_Score;
        m_PData.m_Salvage += m_Salvage;
        for (int i = 0; i < m_PSpawn.m_Player.GetComponent<ShipData>().m_Inventory.Count; ++i)
        {
            for(int j = 0; j < m_PData.m_Items.Count; ++j)
            {
                m_PData.m_Items[j] = m_PSpawn.m_Player.GetComponent<ShipData>().m_Inventory[i].name;
            }
        }
    }
}