using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NukeProjectile : Projectile
{
    #region Variables
        #region public 

        public GameObject m_Explosion;

        #endregion

        #region private
        private List<GameObject> activeEnemies_;

        private Vector3 target_;
        
        #endregion
    #endregion

    //detect all enemies on screen(going to have to use not player for the tag)
    //set target to middle of the screen
    //travel to target and detonate
    //applydamage to all enemies of 1000
    //use particle system to create the explosion and shock wave
    public void Start()
    {
        m_Damage = 1000;
        target_ = new Vector3(0.0f, 3.0f, 0.0f);
        activeEnemies_ = new List<GameObject>();
        AddPotentialTargets();
    }

    public void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target_, this.m_ForwardAccel * Time.deltaTime);

        if(this.transform.position.y > 3.0f)
        {
            Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
            Detonate();
            Destroy(gameObject);
        }
    }

    public void Detonate()
    {
        //Inatansiate explosion, with a collider that expands with it
        //check for contact with anything that isn't the player and apply 1000 damage

        for(int i = 0; i < activeEnemies_.Count; ++i)
        {
            activeEnemies_[i].GetComponent<ShipController>().ApplyDamage(activeEnemies_[i], m_Damage);
        }
    }

    private void AddPotentialTargets()
    {
        GameObject[] enemiesInList_ = GameObject.FindGameObjectsWithTag("Enemy");
        //if there is a boss or miniboss add them to list as well
        
        foreach (GameObject enemy_ in enemiesInList_)
        {
            AddEnemyToList(enemy_);
        }
    }

    private void AddEnemyToList(GameObject enemy)
    {
        activeEnemies_.Add(enemy);
    }
}
