using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Weapon : MonoBehaviour
{
    [System.Serializable]
    public class WeaponStateData
    {
        [SerializeField]
        /// <summary>Cooldown timer of the weapon</summary>
        public float m_CooldownTimer;
        [SerializeField]
        /// <summary>Amount of ammo in the weapon</summary>
        public int m_Ammo;

        [SerializeField]
        /// <summary>Offset of the weapon</summary>
        public Vector2 m_Offset;
        [SerializeField]
        /// <summary>Rotation of the weapon</summary>
        public float m_Rotation;

        /// <summary>Decreases the cooldown timer based on deltaTime</summary>
        public void UpdateWeapon()
        {
            if (m_CooldownTimer > 0.0f)
            {
                m_CooldownTimer -= Time.deltaTime;
            }
        }
    };

    #region Variables
    /// <summary>List of projectiles</summary>
    public List<GameObject> m_ProjectilePrefabs;
    /// <summary>Transform of the blaster</summary>
    public Transform m_Blaster;
    /// <summary>Projectile object</summary>
    public GameObject m_Shot;
    /// <summary>Cooldown of the shot</summary>
    public float m_Cooldown;
    /// <summary>Maximum ammo in the weapon</summary>
    public int m_MaxAmmo;
    #endregion

    /// <summary>Assign the projectile to m_Shot</summary>
    /// <param name="projectile">Projectile to be assigned to m_Shot</param>
    public void SetProjectile(GameObject projectile)
    {
        m_Shot = projectile;
    }

    /// <summary>Fire weapons</summary>
    /// <param name="stateData">State data of the weapon firing</param>
    /// <param name="parentShip">Ship that owns the weapon that is firing</param>
    /// <param name="firedBy">Who projectile was fired by</param>
    public void Fire(WeaponStateData stateData, GameObject parentShip, string firedBy)
    {
        GameObject go = (GameObject)Instantiate(m_Shot, m_Blaster.position, m_Blaster.rotation);
        go.GetComponent<Projectile>().m_FiredBy = firedBy;

        stateData.m_Ammo -= 1;
        stateData.m_CooldownTimer = m_Cooldown;
    }
}