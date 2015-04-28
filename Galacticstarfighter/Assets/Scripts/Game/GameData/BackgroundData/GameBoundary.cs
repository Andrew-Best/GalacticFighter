using UnityEngine;
using System.Collections;

public class GameBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-Camera.main.GetComponent<Waves>().m_SpawnArea.x,
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.x),
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.y,
                                                                          Camera.main.GetComponent<Waves>().m_SpawnArea.z);
            Quaternion spawnRotation = Quaternion.identity;

            other.gameObject.transform.position = spawnPosition;
            other.gameObject.transform.rotation = spawnRotation;
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
