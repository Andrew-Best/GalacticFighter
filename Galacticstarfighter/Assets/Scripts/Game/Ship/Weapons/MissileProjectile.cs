using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MissileProjectile : Projectile 
{
    private List<Transform> enemies_;
    public  Transform m_CurrentTarget;

    private float speed_ = 10.0f;

    public void Start()
    {
        m_CurrentTarget = null;
        enemies_ = new List<Transform>();
        AddPotentialTargets();
        m_Damage = 10;
    }

    public void Update()
    {
        SetTarget();
        if (m_CurrentTarget != null)
        {
            Vector3 dir = transform.position - m_CurrentTarget.transform.position;
            float angle = ((Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg) + 90.0f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, speed_);

            transform.position = Vector3.MoveTowards(transform.position, m_CurrentTarget.transform.position, this.m_ForwardAccel * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody>().velocity = transform.up * m_ForwardAccel;
        }
    }

    private void AddPotentialTargets()
    {
        GameObject[] enemiesInList_ = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy_ in enemiesInList_)
        {
            AddEnemyToList(enemy_.transform);
        }
    }

    private void AddEnemyToList(Transform enemy)
    {
        enemies_.Add(enemy);
    }

    public void DistanceToTarget()
    {
        enemies_.Sort(delegate(Transform t1, Transform t2)
        {
            return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
        });
    }

    public void SetTarget()
    {
        if(enemies_.Count > 0)
        {
            //check for current target, if it is null set a target
            if(m_CurrentTarget == null)
            {
                DistanceToTarget();
                for (int i = 0; i < enemies_.Count; ++i)
                {
                    if (enemies_[i].GetComponent<ShipData>().m_IsTargetted == false)
                    {
                        m_CurrentTarget = enemies_[i];
                        enemies_[i].GetComponent<ShipData>().m_IsTargetted = true;
                        break;
                    }
                }
           }
        }
    }
}
