using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class UIControl : MonoBehaviour
{
    private GameData m_GData;
    private PlayerData m_PData;
    public PowerUpControls m_PUControls;

    public GameObject m_GameControl;
    public GameObject m_Player; //The player game object
    public Slider m_PlayerHealth; //Slider for the player's current health
    public Slider m_PlayerShield;//Slider that is activated to show player shield health, turn off if hasShield is false;
    public Slider m_TempShield;
    public Text m_LivesVal; //Text element for the current number of lives the player has
    public Text m_ScoreVal; //Text element for the player's current score
    public Text m_SalvageVal;//Text elememnt for the collected salvage

    private int maxPlayerHealth_; //Player's max health
    private int minHealth_ = 0; //Minimum health the player or enemy can ever have, obviously it's 0
    private int maxPlayerShield_;//Player's Max shield hp
    private int minShield_ = 0;
    private int maxTempShield_;
    private int minTempShield_ = 0;
   
    private int currHealth_;
    private int currShield_;
    private int currTempShield_;
    private int currLives_;
    private int currScore_;
    private int currSalvage_;

    //Stats UI code
    public int m_EnemiesKilledLifetime;
    public int m_WavesCompleted;

    void Start()
    {
        m_GData = GameObject.Find("GameData").GetComponent<GameData>();
        m_PData = GameObject.Find("PlayerData").GetComponent<PlayerData>();
        if (m_GData == null)
        {
            Debug.LogError("GameData is null in UIControl");
        }
        if (m_PData == null)
        {
            Debug.LogError("PlayerData is null in UIControl");
        }

        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;

        m_EnemiesKilledLifetime = m_PData.m_EnemiesKilled;
        m_WavesCompleted = m_PData.m_WavesCompleted;

        maxTempShield_ = m_Player.GetComponent<PlayerShip>().m_MaxTempShiledHP;
        m_TempShield.maxValue = maxTempShield_;
        m_TempShield.minValue = minTempShield_;

        maxPlayerShield_ = m_Player.GetComponent<PlayerShip>().m_MaxShieldHP;
        m_PlayerShield.maxValue = maxPlayerShield_;
        m_PlayerShield.minValue = minShield_;

        maxPlayerHealth_ = m_Player.GetComponent<PlayerShip>().m_MaxHP;
        m_PlayerHealth.maxValue = maxPlayerHealth_;
        m_PlayerHealth.minValue = minHealth_;
    }

    void Update()
    {
        if (m_Player != null)
        {
            currHealth_ = m_Player.GetComponent<ShipData>().m_HP;
            if (m_Player.GetComponent<ShipData>().m_HasShield)
            {
                currShield_ = m_Player.GetComponent<ShipData>().m_CurrShield;
            }
            else
            {
                currShield_ = 0;
            }
            if (m_Player.GetComponent<PlayerShip>().m_HasTempShield)
            {
                currTempShield_ = m_Player.GetComponent<ShipData>().m_CurrShield;
            }
            else
            {
                currTempShield_ = 0;
            }
            currLives_ = m_GameControl.GetComponent<GameController>().m_Lives;
            currScore_ = m_GameControl.GetComponent<GameController>().m_Score;
            currSalvage_ = m_GameControl.GetComponent<GameController>().m_Salvage;

            m_PlayerHealth.value = currHealth_;
            m_PlayerShield.value = currShield_;
            m_TempShield.value = currTempShield_;
            m_LivesVal.text = currLives_.ToString();
            m_ScoreVal.text = currScore_.ToString();
            m_SalvageVal.text = currSalvage_.ToString();
        }
    }
}
