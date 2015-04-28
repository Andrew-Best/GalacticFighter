using UnityEngine;
using System.Collections;

public class ShieldData : MonoBehaviour
{
    public Transform m_ShieldPos;

    public void SetShield(GameObject ship)
    {
        if(ship.tag == "Player")
        {
            if(ship.GetComponent<PlayerShip>().m_HasTempShield)
            {
                if (ship.GetComponent<ShipData>().m_CurrShield > 0)
                {
                    m_ShieldPos.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    m_ShieldPos.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else if (ship.GetComponent<ShipData>().m_HasShield)
            {
                Debug.Log("ShieldHP Value is " + ship.GetComponent<ShipData>().m_CurrShield);

                if (ship.GetComponent<ShipData>().m_CurrShield > 0)
                {
                    m_ShieldPos.GetComponent<MeshRenderer>().enabled = true;
                }
                else
                {
                    m_ShieldPos.GetComponent<MeshRenderer>().enabled = false;
                }
            }
            else
            {
                m_ShieldPos.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
}
