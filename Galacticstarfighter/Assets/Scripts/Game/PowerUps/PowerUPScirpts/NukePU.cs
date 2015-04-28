using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NukePU : PowerUps
{
    private List<GameObject> enemies_ = new List<GameObject>();

    // when used destroy all enemies
    public override void Start()
    {
        m_IsStorable = true;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    public override void ItemAffect(GameObject player)
    {
        GameObject[] enemiesInList_ = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy_ in enemiesInList_)
        {
            enemies_.Add(enemy_);
            for(int i = 0; i < enemiesInList_.Length; ++i)
            {
                ShipController ship = enemiesInList_[i].gameObject.GetComponent<ShipController>();
                if(ship != null)
                {
                    ship.ApplyDamage(ship.gameObject, 1000);
                }
            }
        }
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}