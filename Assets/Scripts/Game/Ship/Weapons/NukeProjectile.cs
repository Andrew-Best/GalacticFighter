using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NukeProjectile : Projectile
{
    #region Variables
        #region public 

        public GameObject m_Explosion;

        public GameObject m_Shockwave;

        #endregion

        #region private

        private Vector3 target_;
        
        #endregion
    #endregion

    //set target to middle of the screen
    //travel to target and detonate
    //applydamage to all enemies of 1000

    
    public void Start()
    {
        target_ = new Vector3(0.0f, 4.0f, 0.0f);
    }

    public void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target_, this.m_ForwardAccel * Time.deltaTime);

        if(this.transform.position.y > 3.0f)
        {
            Detonate();
            Destroy(gameObject);
        }
    }

    public void Detonate()
    {
        //Instansiate explosion, with a collider that expands with it
        Instantiate(m_Explosion, this.transform.position, this.transform.rotation);
        m_Shockwave.GetComponent<Blast>().GenerateShockwave();

    }
}
