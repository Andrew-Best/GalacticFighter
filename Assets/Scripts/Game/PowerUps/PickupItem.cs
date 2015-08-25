using UnityEngine;
using System.Collections;

public class PickupItem : MonoBehaviour 
{

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(this.GetComponent<PowerUps>().m_IsStorable)
            {
                other.gameObject.GetComponent<ShipData>().AddItem(gameObject);
                gameObject.SetActive(false);
            }
            else
            {
                this.GetComponent<PowerUps>().UseItem(other.gameObject);
                gameObject.SetActive(false);
            }
        }
    }
}
