using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MiniBossController : Enemy 
{

    public float m_MaxVel;
    public Vector3 m_CurrVel;

    public override void Awake()
    {
        //Set target for all enemies
        if (m_Target == null)
        {
            m_Target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    public override void OnExit()
    {
        if (m_ShipData.transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    public override void Update()
    {
        //Boss will stay at top of play area until Destroyed moving only side to side
        float moveVertical = this.m_ShipData.GetTotalVertAccel();

        if (m_Target != null)
        {
            Vector3 moveShip = new Vector3(moveVertical, 0.0f, 0.0f);

            this.GetComponent<Rigidbody>().velocity = moveShip;

            this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, m_MaxVel);

            m_CurrVel = GetComponent<Rigidbody>().velocity;

            m_ShipController.FireWeapons("EnemyProjectile");
        }
        else
        {
            return;
        }
    }

    public override void SetProjectiles()
    {
        //foreach (Weapon weapon in this.GetComponent<ShipData>().m_Weapons)
        //{
            for (int i = 0; i < this.GetComponent<ShipData>().m_Weapons.Length; ++i)
            {
                this.GetComponentInChildren<Weapon>().m_MaxAmmo = 1000;
                this.GetComponentInChildren<Weapon>().SetProjectile(this.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);
                this.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = this.GetComponentInChildren<Weapon>().m_MaxAmmo;
            }
        //}
    }
}
