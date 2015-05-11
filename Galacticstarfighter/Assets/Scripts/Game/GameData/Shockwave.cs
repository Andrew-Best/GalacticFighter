using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour
{
    #region Variables

    public int m_Damage;

    public float m_BlastRadius;

    private float time_ = 0.25f;

    #endregion
    
    // Use this for initialization
	public void Start () 
    {
        
	}
	
	// Update is called once per frame
	public void FixedUpdate () 
    {
        if(GetComponent<SphereCollider>().radius < 2.50f)
        {
            ExpandShockwave();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        ShipController hitShip = collision.gameObject.GetComponentInChildren<ShipController>();
        if (hitShip != null)
        {
            if(hitShip.tag != "Player")
            {
                hitShip.ApplyDamage(hitShip.gameObject, m_Damage);
            }
        }
    }


    public void ExpandShockwave()
    {
        if (Time.time >= time_)
        {
            gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.0f);
            GetComponent<SphereCollider>().radius += 0.01f;
        }
    }
}
