using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour
{
    #region Variables
    public float m_ForwardAccel;
    public int m_Damage = 1;
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
            Destroy(gameObject);
            hitShip.ApplyDamage(hitShip.gameObject, m_Damage);
        }
    }
}
