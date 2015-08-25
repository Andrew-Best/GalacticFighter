using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipData : MonoBehaviour 
{
    public Weapon[] m_Weapons;
    public Weapon.WeaponStateData[] m_WeaponState;
    public Rigidbody m_Rigidbody;
    public List<GameObject> m_Inventory = new List<GameObject>(3);

    public GameObject m_NullItem;//used to set inventory list and to give something to set in the power up UI

    public float m_ForwardAccel;//for movement controls
    public float m_VerticalAccel;//for movement controls

    public int m_HP;
    public int m_CurrShield;
 
    public bool m_HasShield;
    public bool m_IsTargetted;//to let missiles know if ship has been targetted by another missile

    public float GetTotalThrustAccel()
    {
        float retval = 0.0f;

        retval += m_ForwardAccel;

        return retval;
    }

    public float GetTotalVertAccel()
    {
        float retval = 0.0f;

        retval += m_VerticalAccel;

        return retval;
    }


    public void AddItem(GameObject item)
    {
        for (int i = 0; i < m_Inventory.Capacity; ++i)
        {
            if (m_Inventory[i].gameObject == m_NullItem)
            {
                item.transform.position = gameObject.transform.position;
                item.transform.parent = gameObject.transform;
                m_Inventory.RemoveAt(i);
                m_Inventory.Insert(i, item);
                return;
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i < m_Inventory.Count; ++i)
        {
            if (m_Inventory[i].gameObject == item)
            {
                m_Inventory[i] = null;
            }
        }
    }

	//Use this for initialization
	void Start () 
    {
        m_IsTargetted = false;
        m_Inventory.Capacity = 3;

        for (int i = 0; i < m_Inventory.Capacity; ++i)
        {
            m_Inventory.Add(m_NullItem);
        }
	}
	
	//Update is called once per frame
	void FixedUpdate () 
    {
        for (int i = 0; i < m_WeaponState.Length; ++i)
        {
            m_WeaponState[i].UpdateWeapon();
        }
	}
}
