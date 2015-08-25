using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileBatteryPU : PowerUps
{
    public GameObject m_MissilePrefab;

    public List<Transform> m_LaunchPoints = new List<Transform>();
    
    public float m_LaunchTimer;
    public float m_Launch;

    private List<GameObject> missilePool_ = new List<GameObject>();

    private Task launchMissiles_;

    public override void Start()
    {
        m_IsStorable = true;
        missilePool_.Capacity = 10;
    }
    public override void Update()
    {
        if (this.isActiveAndEnabled)
        {
            Vector3 movement = new Vector3(0, m_DropSpeed, 0);

            GetComponent<Rigidbody>().velocity = movement;
        }
    }

    //launch 10 missiles without tracking
    public override void ItemAffect(GameObject player)
    {
        //set missile list to contain 10
        for (int i = 0; i < missilePool_.Capacity; ++i)
        {
            GameObject obj = (GameObject)Instantiate(m_MissilePrefab);
            obj.SetActive(false);
            missilePool_.Add(obj);
            for (int j = 0; j < missilePool_.Count; ++j)
            {
                missilePool_[j].gameObject.name = "Missile" + j;
            }

        }
        //launch 10 missiles from the 10 launch points
        launchMissiles_ = new Task(Launch(), true);
    }

    public override void UseItem(GameObject player)
    {
        ItemAffect(player);
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(m_Launch);

        while (missilePool_.Count > 0)
        {
            for (int i = 0; i < missilePool_.Count; ++i)
            {
                for (int j = 0; j < m_LaunchPoints.Count; ++i)
                {
                    if(missilePool_.Count > 0)
                    {
                        Vector3 spawnPosition = new Vector3(m_LaunchPoints[i].position.x, m_LaunchPoints[i].position.y, m_LaunchPoints[i].position.z);
                        Quaternion spawnRotation = Quaternion.identity;

                        missilePool_[i].SetActive(true);
                        missilePool_[i].transform.position = spawnPosition;
                        missilePool_[i].transform.rotation = spawnRotation;
                    }
                    yield return new WaitForSeconds(m_LaunchTimer);
                }
            }
        }
    }
}
