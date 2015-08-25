using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NukePU : PowerUps
{
    private List<GameObject> enemies_ = new List<GameObject>();

    public GameObject m_NukePrefab;

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
        Instantiate(m_NukePrefab, player.transform.position, player.transform.rotation);
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }
}