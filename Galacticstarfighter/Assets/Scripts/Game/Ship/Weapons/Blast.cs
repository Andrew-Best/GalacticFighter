using UnityEngine;
using System.Collections;

public class Blast : MonoBehaviour
{
    #region Variables
    public Transform m_InitalPoint;
    public GameObject m_Shockwave;

    #endregion
    // Use this for initialization
	void Start () 
    {
	}
	
    public void GenerateShockwave()
    {
        Instantiate(m_Shockwave, m_InitalPoint.position, m_InitalPoint.rotation);
    }

}
