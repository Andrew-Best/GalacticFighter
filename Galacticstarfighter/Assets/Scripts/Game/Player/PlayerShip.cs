using UnityEngine;
using System.Collections;

public class PlayerShip : Ship 
{
    public PlayerController m_PController;
    public PlayerData m_PData;

    public bool m_HasTempShield;

    public int m_MaxHP;
    public int m_MaxShieldHP;
    public int m_TempShieldHP;
    public int m_MaxTempShiledHP;

    private int shieldUpgradeCounter_ = 1; //Amount of upgrades in the shield by the player
    private int engineUpgradeCounter_ = 1; //Amount of upgrades in the engines by the player
    private int damageUpgradeCounter_ = 1; //Amount of upgrades in the damage by the player
    private int healthUpgradeCounter_ = 1; //Amount of upgrades in the health by the player
    private int levelUpgradeCounter_ = 1; //Level of PlayerShip

    public int EngineLevel { get { return engineUpgradeCounter_; } set { engineUpgradeCounter_ = value; } }
    public int ShieldLevel { get { return shieldUpgradeCounter_; } set { shieldUpgradeCounter_ = value; } }
    public int DamageLevel { get { return damageUpgradeCounter_; } set { damageUpgradeCounter_ = value; } }
    public int HealthLevel { get { return healthUpgradeCounter_; } set { healthUpgradeCounter_ = value; } }
    public int Level { get { return levelUpgradeCounter_; } set { levelUpgradeCounter_ = value; } }

    public void Start()
    {
        m_PController =  Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<PlayerController>();

        m_DamageModifier = DamageLevel * Constants.DEFAULT_UPGRADE_MODIFIER;

        shieldUpgradeCounter_ = m_PData.m_ShieldLevel;
        healthUpgradeCounter_ = m_PData.m_HealthLevel;
        damageUpgradeCounter_ = m_PData.m_DamageLevel;
        engineUpgradeCounter_ = m_PData.m_EngineLevel;
        levelUpgradeCounter_ = m_PData.m_ShipLevel;

        m_TempShieldHP = 10;
        m_MaxTempShiledHP = 10;
        m_MaxHP = 20 * HealthLevel;
        m_MaxShieldHP = 10 * (m_PData.m_ShieldLevel);
    }
}
