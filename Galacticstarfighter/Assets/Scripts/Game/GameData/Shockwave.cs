using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour
{
    #region Variables

    public Transform m_Parent;
    public int m_Damage;

    private SphereCollider m_Shockwave;
    private float time_ = 3.0f;

    #endregion
    
    // Use this for initialization
	public void Start () 
    {
	}
	
	// Update is called once per frame
	public void Update () 
    {
	    if(Time.time >= time_)
        {
            if(m_Shockwave.radius < 50.0f)
            {
                m_Shockwave.radius += 2f;
            }
            else
            {
                m_Shockwave.enabled = false;
            }
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        ShipController hitShip = collision.gameObject.GetComponentInChildren<ShipController>();
        if (hitShip != null)
        {
            if(hitShip.tag != "Player")
            {
                //Destroy(gameObject);
                hitShip.ApplyDamage(hitShip.gameObject, m_Damage);
            }
        }
    }

    public void StartShockwave()
    {
        m_Shockwave = m_Parent.gameObject.AddComponent<SphereCollider>();
        m_Shockwave.center = m_Parent.gameObject.transform.position;

        Instantiate(m_Parent, transform.position, transform.rotation);
    }
}
