using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarMapUI : MonoBehaviour
{
    /// <summary>Upgrade panel UI element</summary>
    public GameObject m_UpgradePanel;
    /// <summary>Text UI element for the health cost/upgrade level</summary>
    public Text m_HealthText;
    /// <summary>Text UI element for the shield cost/upgrade level</summary>
    public Text m_ShieldText;
    /// <summary>Text UI element for the damage cost/upgrade level</summary>
    public Text m_DamageText;
    /// <summary>Text UI element for the engine cost/upgrade level</summary>
    public Text m_EngineText;
    /// <summary>Text UI element for the cost of the next tier ship</summary>
    public Text m_TierText;
    /// <summary>Text element to tell player to upgrade for level they are choosing to play</summary>
    public Text m_Control;
    /// <summary>Text UI element displaying amount of salvage the player has</summary>
    public Text m_Salvage;

    /// <summary>Upgrade Health button</summary>
    public Button m_Health;
    /// <summary>Upgrade Shield button</summary>
    public Button m_Shield;
    /// <summary>Upgrade Damage button</summary>
    public Button m_Damage;
    /// <summary>Upgrade Engine button</summary>
    public Button m_Engine;

    /// <summary>Player Data script</summary>
    public PlayerData m_PData;
    /// <summary>Game Data script</summary>
    public GameData m_GData;
    /// <summary>Level Data script</summary>
    public LevelData m_LData;

    /// <summary>Cost to upgrade</summary>
    private int upgradeCost_;
    /// <summary>Amount of upgrades in the shield by the player</summary>
    private int shieldUpgradeCounter_;
    /// <summary>Amount of upgrades in the engines by the player</summary>
    private int engineUpgradeCounter_;
    /// <summary>Amount of upgrades in damage by the player</summary>
    private int damageUpgradeCounter_;
    /// <summary>Amount of upgrades in health by the player</summary>
    private int healthUpgradeCounter_;
    /// <summary>Level of the Player Ship</summary>
    private int levelUpgradeCounter_;

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
    public void LoadLevel(int level)
    {
        m_Control.text = "";
        m_LData.LoadLevelData();
        SetPlayerData();
        m_GData.Save();

        //set level requirements
        if ((m_PData.m_ShipLevel) < level)
        {
            m_Control.text = "Your Ship needs to be Level " + level + " to access this area";
       }
        else
        {
            m_Control.text = "";
            Application.LoadLevel("Game");
        }
    }

    /// <summary>Button function -- If the user presses the spaceship this function fires. The function opens up the Upgrade Menu.</summary>
    public void UpgradeMenu()
    {
        m_Control.text = "";
        m_UpgradePanel.SetActive(true);
    }

    /// <summary>Button function -- Closes the upgrade menu</summary>
    public void CloseMenu()
    {
        m_Control.text = "";
        m_UpgradePanel.SetActive(false);
    }

    /// <summary>Button function -- If the user presses this button they will purchase a damage upgrade so long as they have enough tokens/salvage</summary>
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

    /// <summary>Button function -- If the user presses this button they will purchase an engine upgrade so long as they have enough tokens/salvage</summary>
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

    /// <summary>Button function -- If the user presses this button they will purchase a health upgrade so long as they have enough tokens/salvage</summary>
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

    /// <summary>Button function -- If the user presses this button they will purchase a shield upgrade so long as they have enough tokens/salvage</summary>
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

    /// <summary>Button function -- If the user presses this button they will purchase a ship upgrade so long as they have enough tokens/salvage</summary>
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