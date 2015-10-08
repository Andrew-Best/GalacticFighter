using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    #region Variables
    /// <summary>Forward acceleration</summary>
    public float m_ForwardAccel;
    /// <summary>Damage dealt by projectile</summary>
    public int m_Damage = 1;
    /// <summary>Who fired the projectile</summary>
    public string m_FiredBy;
    #endregion

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;
    }

    void OnCollisionEnter(Collision collision)
    {
        ShipController hitShip = collision.gameObject.GetComponentInChildren<ShipController>();
        if (hitShip != null)
        {
            if(m_FiredBy == "Player")
            {
                GameObject.Find("PlayerData").GetComponent<PlayerData>().m_EnemiesKilled++;
            }
            Destroy(gameObject);
            hitShip.ApplyDamage(hitShip.gameObject, m_Damage);
        }
    }
}
