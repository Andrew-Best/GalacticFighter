using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PowerUpControls : MonoBehaviour 
{
    public GameObject m_Player;

    public Material m_BlankImage;
 
    public Button m_Boost1;
    public Button m_Boost2;
    public Button m_Boost3;

    public void Start()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
    }

    public void Update()
    {
        SetPowerUpImages();
        ItemsUse();
    }


    public void SetPowerUpImages()
    {
        m_Boost1.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<MeshRenderer>().sharedMaterial;

        m_Boost2.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<MeshRenderer>().sharedMaterial;
 
        m_Boost3.GetComponent<Image>().material = m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<MeshRenderer>().sharedMaterial;
    }

    public void ItemsUse()
    {
        if (Input.GetKey(KeyCode.B))
        {
            if (m_Boost1.GetComponent<Image>().material != m_BlankImage)
            {
                m_Player.GetComponent<ShipData>().m_Inventory[0].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[0] = m_Player.GetComponent<ShipData>().m_NullItem;
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.N))
        {
            if (m_Boost2.GetComponent<Image>().material != m_BlankImage)
            {
                m_Player.GetComponent<ShipData>().m_Inventory[1].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[1] = m_Player.GetComponent<ShipData>().m_NullItem;
            }
            else
            {
                return;
            }
        }

        if (Input.GetKey(KeyCode.M))
        {
            if (m_Boost3.GetComponent<Image>().material != m_BlankImage)
            {
                m_Player.GetComponent<ShipData>().m_Inventory[2].GetComponent<PowerUps>().UseItem(m_Player);
                m_Player.GetComponent<ShipData>().m_Inventory[2] = m_Player.GetComponent<ShipData>().m_NullItem;
            }
            else
            {
                return;
            }
        }
    }

}
