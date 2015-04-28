using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour 
{
    public PlayerData m_PData;

    public GameObject m_Enemy;

    public ShipController m_ShipController;
    public PlayerShip m_PlayerShip;
    public Boundary m_PlayerBoundary;

    public float m_MaxVel;
    public float m_FireRate;
    public int m_Salvage;

    private float nextShot_;

    public void Start()
    {
        nextShot_ = 0.0f;
        m_PlayerShip = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<PlayerShip>();
        m_ShipController = Camera.main.GetComponent<SpawnPlayer>().m_Player.GetComponent<ShipController>();
        //set player ammo to max
        ResetProjectileAmmo();
    }

    public void Update()
    {
        if(m_Enemy == null)
        {
            m_Enemy = GameObject.FindGameObjectWithTag("Enemy");
        }
        //to move player around scene
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 moveShip = new Vector3((moveHorizontal * m_PlayerShip.m_SData.GetTotalVertAccel()), (moveVertical * m_PlayerShip.m_SData.GetTotalThrustAccel()), 0.0f);

        this.GetComponent<Rigidbody>().velocity = moveShip;

        this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, m_MaxVel);

        //to keep player from leaving play area
        this.GetComponent<Rigidbody>().position = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().position.x, m_PlayerBoundary.xMin, m_PlayerBoundary.xMax),
                                         Mathf.Clamp(GetComponent<Rigidbody>().position.y, m_PlayerBoundary.yMin, m_PlayerBoundary.yMax),
                                         0.0f);

        //to fire weapons
        if (Input.GetButton("Fire"))
        {
            nextShot_ -= Time.deltaTime;

            for (int i = 0; i < m_PlayerShip.m_SData.m_Weapons.Length; ++i)
            {
                if (m_PlayerShip.m_SData.m_WeaponState[i].m_Ammo == 0)
                {
                    ResetProjectileAmmo();
                }
                else
                {
                    if (nextShot_ <= 0.0f)
                    {
                        m_ShipController.FireWeapons("PlayerShot");

                        nextShot_ = m_FireRate;
                    }
                }
            }
        }

        //check if playing on a mobile device and activate this code if true
        /*nextShot_ -= Time.deltaTime;
        if (m_Enemy != null)
        {
            for (int i = 0; i < m_PlayerShip.m_SData.m_Weapons.Length; ++i)
            {
                if (m_PlayerShip.m_SData.m_WeaponState[i].m_Ammo == 0)
                {
                    ResetProjectileAmmo();
                }
                else
                {
                    if (nextShot_ <= 0.0f)
                    {
                        m_ShipController.FireWeapons("PlayerShot");

                        nextShot_ = m_FireRate;
                    }
                }
            }
        }*/
    }

    public void ResetProjectileAmmo()
    {
        for (int i = 0; i < this.GetComponent<ShipData>().m_Weapons.Length; ++i)
        {
            //set player ammo to max
            this.GetComponentInChildren<Weapon>().m_MaxAmmo = 500;
            this.m_FireRate = 0.25f;
            this.GetComponentInChildren<Weapon>().SetProjectile(this.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);
            this.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = this.GetComponentInChildren<Weapon>().m_MaxAmmo;
        }
    }
}
