using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarMapUI : MonoBehaviour
{
    public GameObject m_UpgradePanel; //Upgrade panel UI element
    public Text m_HealthText; //Text UI element for the health cost and upgrade level
    public Text m_ShieldText; //Text UI element for the shield cost and upgrade level
    public Text m_DamageText; //Text UI element for the damage cost and upgrade level
    public Text m_EngineText; //Text UI element for the engine cost and upgrade level
    public Text m_TierText; //Text UI element for the cost of the next tier Ship
    public Text m_Control;//Text element to tell player to upgrade for level they r choosing to play
    public Text m_Salvage;//Amount of Salvage the player has to spend

    public Button m_Health;
    public Button m_Shield;
    public Button m_Damage;
    public Button m_Engine;

    public PlayerData m_PData;
    public GameData m_GData;
    public LevelData m_LData;

    private int upgradeCost_;
    private int shieldUpgradeCounter_; //Amount of upgrades in the shield by the player
    private int engineUpgradeCounter_; //Amount of upgrades in the engines by the player
    private int damageUpgradeCounter_; //Amount of upgrades in the damage by the player
    private int healthUpgradeCounter_; //Amount of upgrades in the health by the player
    private int levelUpgradeCounter_; //Level of PlayerShip

    public int BuyShieldCost
    {
        get { return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipLevel)); }
    }

    public int ShieldUpgradeCost
    {
        get { return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipLevel)) * shieldUpgradeCounter_; }
    }
    public int EngineUpgradeCost
    {
        get { return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipLevel)) * engineUpgradeCounter_; }
    }
    public int DamageUpgradeCost
    {
        get { return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipLevel)) * damageUpgradeCounter_; }
    }
    public int HealthUpgradeCost
    {
        get { return (Constants.BASE_UPGRADE_COST * (m_PData.m_ShipLevel)) * healthUpgradeCounter_; }
    }
    public int TierUpgradeCost
    {
        get { return (Constants.BASE_SHIP_COST * (m_PData.m_ShipLevel)) * levelUpgradeCounter_; }
    }

    public int EngineLevel
    {
        get { return engineUpgradeCounter_; }
        set { engineUpgradeCounter_ = value; }
    }
    public int ShieldLevel
    {
        get { return shieldUpgradeCounter_; }
        set { shieldUpgradeCounter_ = value; }
    }
    public int DamageLevel
    {
        get { return damageUpgradeCounter_; }
        set { damageUpgradeCounter_ = value; }
    }
    public int HealthLevel
    {
        get { return healthUpgradeCounter_; }
        set { healthUpgradeCounter_ = value; }
    }
    public int PlayerShipLevel
    {
        get { return levelUpgradeCounter_; }
        set { levelUpgradeCounter_ = value; }
    }
    public void Awake()
    {
        shieldUpgradeCounter_ = 1;
        engineUpgradeCounter_ = 1;
        damageUpgradeCounter_ = 1;
        healthUpgradeCounter_ = 1;
        levelUpgradeCounter_ = 1;
   }
    void Update()
    {
        shieldUpgradeCounter_ = m_PData.m_ShieldLevel;
        healthUpgradeCounter_ = m_PData.m_HealthLevel;
        damageUpgradeCounter_ = m_PData.m_DamageLevel;
        engineUpgradeCounter_ = m_PData.m_EngineLevel;
        levelUpgradeCounter_ = m_PData.m_ShipLevel;

        m_Salvage.text = "You have " + m_PData.m_Salvage.ToString() + " Salvage";

        if(m_PData.m_Tokens != null && m_PData.m_Tokens.Count > 0)
        {
            for (int i = 0; i < m_PData.m_Tokens.Count; ++i)
            {
                if (m_PData.m_Tokens[i] == "HealthToken")
                {
                    m_HealthText.text = "Cost: 1 Health Token";
                }
                else
                {
                    m_HealthText.text = "Cost: " + HealthUpgradeCost.ToString() + "\nCurrent Level: " + HealthLevel;
                }

                if (m_PData.m_Tokens[i] == "ShieldToken")
                {
                    m_ShieldText.text = "Cost: 1 ShieldToken";
                }
                else
                {
                    if (!m_PData.m_HasShield)
                    {
                        m_ShieldText.text = "Cost: " + BuyShieldCost.ToString() + "\nCurrent Level: " + ShieldLevel;
                    }
                    else
                    {
                        m_ShieldText.text = "Cost: " + ShieldUpgradeCost.ToString() + "\nCurrent Level: " + ShieldLevel;
                    }
                }

                if (m_PData.m_Tokens[i] == "DamageToken")
                {
                    m_DamageText.text = "Cost: 1 Engine Token";
                }
                else
                {
                    m_DamageText.text = "Cost: " + DamageUpgradeCost.ToString() + "\nCurrent Level: " + DamageLevel;
                }

                if (m_PData.m_Tokens[i] == "EngineToken")
                {
                    m_EngineText.text = "Cost: " + EngineUpgradeCost.ToString() + "\nCurrent Level: " + EngineLevel;
                }
            }
        }
        else
        {
            m_HealthText.text = "Cost: " + HealthUpgradeCost.ToString() + "\nCurrent Level: " + HealthLevel;
            if (!m_PData.m_HasShield)
            {
                m_ShieldText.text = "Cost: " + BuyShieldCost.ToString() + "\nCurrent Level: " + ShieldLevel;
            }
            else
            {
                m_ShieldText.text = "Cost: " + ShieldUpgradeCost.ToString() + "\nCurrent Level: " + ShieldLevel;
            }
            m_DamageText.text = "Cost: " + DamageUpgradeCost.ToString() + "\nCurrent Level: " + DamageLevel;
            m_EngineText.text = "Cost: " + EngineUpgradeCost.ToString() + "\nCurrent Level: " + EngineLevel;
            m_TierText.text = "Cost: " + TierUpgradeCost.ToString() + "\nCurrent Level: " + PlayerShipLevel;
        }
    }
    public void SetPlayerData()
    {
        m_PData.m_ShipLevel = PlayerShipLevel;
        m_PData.m_HealthLevel = HealthLevel;
        m_PData.m_EngineLevel = EngineLevel;
        m_PData.m_ShieldLevel = ShieldLevel;
        m_PData.m_DamageLevel = DamageLevel;
    }
    public void LoadLevel(int level_)
    {
        m_Control.text = "";
        m_LData.LoadLevelData();
        SetPlayerData();
        m_GData.Save();

        //set level requirements
        if ((m_PData.m_ShipLevel) < level_)
        {
            m_Control.text = "Your Ship needs to be Level " + level_ + " to access this area";
       }
        else
        {
            m_Control.text = "";
            Application.LoadLevel("Game");
        }
    }
    //Button function -- If the user presses the spaceship this function will fire
    //                -- The function opens up the Upgrade menu, where they can then upgrade their ship or upgrade to a higher tier ship entirely
    public void UpgradeMenu()
    {
        m_Control.text = "";
        m_UpgradePanel.SetActive(true);
    }
    //Button function
    public void CloseMenu()
    {
        m_Control.text = "";
        m_UpgradePanel.SetActive(false);
    }
    //Button function
    public void UpgradeDamage()
    {
        if(m_PData.m_Tokens.Count > 0)
        {
            for (int i = 0; i < m_PData.m_Tokens.Count; ++i)
            {
                if (m_PData.m_Tokens[i] == "DamageToken")
                {
                    upgradeCost_ = 0;
                    m_PData.m_Tokens.Remove("DamageToken");
                    damageUpgradeCounter_++;
                    m_PData.m_DamageLevel = DamageLevel;
                }
                else
                {
                    m_Control.text = "";
                    upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * damageUpgradeCounter_;
                    if (m_PData.m_Salvage >= upgradeCost_)
                    {
                        if (damageUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                        {
                            m_PData.m_Salvage -= upgradeCost_;
                            damageUpgradeCounter_++;
                            m_PData.m_DamageLevel = DamageLevel;
                        }
                    }
                    else
                    {
                        m_Control.text = "You don't have enough Salvage";
                    }
                }
            }
        }
        else
        {
            m_Control.text = "";
            upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * damageUpgradeCounter_;
            if (m_PData.m_Salvage >= upgradeCost_)
            {
                if (damageUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                {
                    m_PData.m_Salvage -= upgradeCost_;
                    damageUpgradeCounter_++;
                    m_PData.m_DamageLevel = DamageLevel;
                }
            }
            else
            {
                m_Control.text = "You don't have enough Salvage";
            }
        }
    }
    //Button function
    public void UpgradeEngine()
    {
        if (m_PData.m_Tokens.Count > 0)
        {
            for (int i = 0; i < m_PData.m_Tokens.Count; ++i)
            {
                if (m_PData.m_Tokens[i] == "EngineToken")
                {
                    upgradeCost_ = 0;
                    m_PData.m_Tokens.Remove("EngineToken");
                    engineUpgradeCounter_++;
                    m_PData.m_EngineLevel = EngineLevel;
                }
                else
                {
                    m_Control.text = "";
                    upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * engineUpgradeCounter_;
                    if (m_PData.m_Salvage >= upgradeCost_)
                    {
                        if (engineUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                        {
                            m_PData.m_Salvage -= upgradeCost_;
                            engineUpgradeCounter_++;
                            m_PData.m_EngineLevel = EngineLevel;
                        }
                    }
                    else
                    {
                        m_Control.text = "You don't have enough Salvage";
                    }
                }
            }
        }
        else
        {
            m_Control.text = "";
            upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * engineUpgradeCounter_;
            if (m_PData.m_Salvage >= upgradeCost_)
            {
                if (engineUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                {
                    m_PData.m_Salvage -= upgradeCost_;
                    engineUpgradeCounter_++;
                    m_PData.m_EngineLevel = EngineLevel;
                }
            }
            else
            {
                m_Control.text = "You don't have enough Salvage";
            }
        }
    }
    //Button function
    public void UpgradeHealth()
    {
        if (m_PData.m_Tokens.Count > 0)
        {
            for (int i = 0; i < m_PData.m_Tokens.Count; ++i)
            {
                if (m_PData.m_Tokens[i] == "HealthToken")
                {
                    m_PData.m_Tokens.Remove("HealthToken");
                    healthUpgradeCounter_++;
                    m_PData.m_HP += Constants.DEFAULT_UPGRADE_AMT;
                    m_PData.m_HealthLevel = HealthLevel;
                }
                else
                {
                    m_Control.text = "";
                    upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * healthUpgradeCounter_;
                    if (m_PData.m_Salvage >= upgradeCost_)
                    {
                        if (healthUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                        {
                            m_PData.m_Salvage -= upgradeCost_;
                            healthUpgradeCounter_++;
                            m_PData.m_HP += Constants.DEFAULT_UPGRADE_AMT;
                            m_PData.m_HealthLevel = HealthLevel;
                        }
                    }
                    else
                    {
                        m_Control.text = "You don't have enough Salvage";
                    }
                }
            }
        }
        else
        {
            m_Control.text = "";
            upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * healthUpgradeCounter_;
            if (m_PData.m_Salvage >= upgradeCost_)
            {
                if (healthUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                {
                    m_PData.m_Salvage -= upgradeCost_;
                    healthUpgradeCounter_++;
                    m_PData.m_HP += Constants.DEFAULT_UPGRADE_AMT;
                    m_PData.m_HealthLevel = HealthLevel;
                }
            }
            else
            {
                m_Control.text = "You don't have enough Salvage";
            }
        }
    }
    //Button function
    public void UpgradeShield()
    {
        if (m_PData.m_Tokens.Count > 0)
        {
            for (int i = 0; i < m_PData.m_Tokens.Count; i++)
            {
                if (m_PData.m_Tokens[i] == "ShieldToken")
                {
                    upgradeCost_ = 0;
                    if (shieldUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                    {
                        m_PData.m_Tokens.Remove("ShieldToken");
                        shieldUpgradeCounter_++;
                        m_PData.m_Shield += Constants.DEFAULT_UPGRADE_AMT;
                        m_PData.m_ShieldLevel = ShieldLevel;
                    }
                }
                else
                {
                    m_Control.text = "";
                    if (!m_PData.m_HasShield)
                    {
                        upgradeCost_ = Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel + 1;
                        if (m_PData.m_Salvage >= upgradeCost_)
                        {
                            m_PData.m_HasShield = true;
                            shieldUpgradeCounter_++;
                        }
                        else
                        {
                            m_Control.text = "You don't have enough Salvage";
                        }
                    }
                    else
                    {
                        m_Control.text = "";
                        upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * shieldUpgradeCounter_;
                        if (m_PData.m_Salvage >= upgradeCost_)
                        {
                            if (shieldUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                            {
                                m_PData.m_Salvage -= upgradeCost_;
                                shieldUpgradeCounter_++;
                                m_PData.m_Shield += Constants.DEFAULT_UPGRADE_AMT;
                                m_PData.m_ShieldLevel = ShieldLevel;
                            }
                        }
                        else
                        {
                            m_Control.text = "You don't have enough Salvage";
                        }
                    }
                }
            }
        }
        else
        {
            m_Control.text = "";
            if (!m_PData.m_HasShield)
            {
                upgradeCost_ = Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel + 1;
                if (m_PData.m_Salvage >= upgradeCost_)
                {
                    m_PData.m_HasShield = true;
                    shieldUpgradeCounter_++;
                }
                else
                {
                    m_Control.text = "You don't have enough Salvage";
                }
            }
            else
            {
                m_Control.text = "";
                upgradeCost_ = (Constants.BASE_UPGRADE_COST * m_PData.m_ShipLevel) * shieldUpgradeCounter_;
                if (m_PData.m_Salvage >= upgradeCost_)
                {
                    if (shieldUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
                    {
                        m_PData.m_Salvage -= upgradeCost_;
                        shieldUpgradeCounter_++;
                        m_PData.m_Shield += Constants.DEFAULT_UPGRADE_AMT;
                        m_PData.m_ShieldLevel = ShieldLevel;
                    }
                }
                else
                {
                    m_Control.text = "You don't have enough Salvage";
                }
            }
        }
    }
    //Button function
    public void UpgradeShip()
    {
        m_Control.text = "";
        upgradeCost_ = (Constants.BASE_SHIP_COST * m_PData.m_ShipLevel) * levelUpgradeCounter_;
        if (m_PData.m_Salvage >= upgradeCost_)
        {
            if (levelUpgradeCounter_ < Constants.MAX_UPGRADE_LEVEL)
            {
                m_PData.m_Salvage -= upgradeCost_;
                levelUpgradeCounter_++;
                m_PData.m_ShipLevel = PlayerShipLevel;
                m_PData.m_ShieldLevel = 0;
                m_PData.m_EngineLevel = 1;
                m_PData.m_HealthLevel = 1;
                m_PData.m_DamageLevel = 1;
            }
        }
        else
        {
            m_Control.text = "You don't have enough Salvage";
        }
    }
}