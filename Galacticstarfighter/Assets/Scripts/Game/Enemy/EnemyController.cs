using UnityEngine;
using System.Collections;

public class EnemyController : Enemy 
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
        if (m_ShipData.transform.position.y < -30)
        {

            Vector3 spawnPosition = new Vector3(Random.Range(-Camera.main.GetComponent<Waves>().m_SpawnArea.x, 
                                                              Camera.main.GetComponent<Waves>().m_SpawnArea.x), 
                                                              Camera.main.GetComponent<Waves>().m_SpawnArea.y, 
                                                              Camera.main.GetComponent<Waves>().m_SpawnArea.z);
            Quaternion spawnRotation = Quaternion.identity;
            this.transform.position = spawnPosition;
            this.transform.rotation = spawnRotation;
        }
    }

    public override void Update()
    {
        //to move enemy around scene
        float moveVertical = -this.m_ShipData.GetTotalThrustAccel();

        if (m_Target != null)
        {
            Vector3 moveShip = new Vector3(0.0f, moveVertical, 0.0f);

            this.GetComponent<Rigidbody>().velocity = moveShip;

            this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody>().velocity, m_MaxVel);

            m_CurrVel = GetComponent<Rigidbody>().velocity;

            for (int i = 0; i < this.GetComponent<ShipData>().m_Weapons.Length; ++i)
            {
                this.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = this.GetComponentInChildren<Weapon>().m_MaxAmmo;
            }
            m_ShipController.FireWeapons("EnemyProjectile");
        }
        else
        {
            return;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            Instantiate(m_ShipController.m_Explosion, transform.position, transform.rotation);
            this.GetComponent<ShipController>().ApplyDamage(other.gameObject, 100);
            
            gameObject.SetActive(false);
       }
    }

    public override void SetProjectiles()
    {
        for (int i = 0; i < this.GetComponent<ShipData>().m_Weapons.Length; ++i)
        {
            this.GetComponentInChildren<Weapon>().m_MaxAmmo = 1000;
            this.GetComponentInChildren<Weapon>().SetProjectile(this.GetComponentInChildren<Weapon>().m_ProjectilePrefabs[0]);
            this.GetComponent<ShipData>().m_WeaponState[i].m_Ammo = this.GetComponentInChildren<Weapon>().m_MaxAmmo;
        }
    }
}
