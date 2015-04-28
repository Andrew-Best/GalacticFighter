using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[System.Serializable]
public class Waves : MonoBehaviour 
{
    public EnemySpawn m_ESpawn;
    public SpawnPlayer m_PSpawn;
    public GameController m_GController;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;
    
    public int m_CurrentWave;
    public int m_EnemyCount;

    public GameObject m_Player;

    public Vector3 m_SpawnArea;

    public Text m_Control;

	// Update is called once per frame
	public void Awake() 
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;
	}


    public IEnumerator WaveSpawner()
    {
        yield return new WaitForSeconds(m_StartDelay);

        while (m_ESpawn.m_RequiredKills > 0)
        {
            m_Control.text = "";

            for (int i = 0; i < m_ESpawn.enemyPool_.Count; ++i)
            {
                if (m_EnemyCount < 8)
                {
                    Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                    Quaternion spawnRotation = Quaternion.identity;

                    m_ESpawn.enemyPool_[i].SetActive(true);
                    if (m_ESpawn.enemyPool_[i].GetComponent<ShipData>().m_HasShield)
                    {
                        m_ESpawn.enemyPool_[i].GetComponent<EnemyShip>().m_ShieldData.SetShield(m_ESpawn.enemyPool_[i]);
                    }
                    m_ESpawn.enemyPool_[i].transform.position = spawnPosition;
                    m_ESpawn.enemyPool_[i].transform.rotation = spawnRotation;
                    m_EnemyCount++;
                }
                yield return new WaitForSeconds(m_SpawnDelay);

            }
        }
    }

    public IEnumerator BossSpawner()
    {
        while(GameObject.FindGameObjectWithTag("Boss") != null)
        {
            yield return new WaitForSeconds(m_StartDelay);

            if (GameObject.FindGameObjectWithTag("Player") != null)
            {
                for (int i = 0; i < m_ESpawn.enemyPool_.Count; ++i)
                {
                    if (m_EnemyCount < 6)
                    {
                        Vector3 spawnPosition = new Vector3(Random.Range(-m_SpawnArea.x, m_SpawnArea.x), m_SpawnArea.y, m_SpawnArea.z);
                        Quaternion spawnRotation = Quaternion.identity;

                        m_ESpawn.enemyPool_[i].SetActive(true);
                        if (m_ESpawn.enemyPool_[i].GetComponent<ShipData>().m_HasShield)
                        {
                            m_ESpawn.enemyPool_[i].GetComponent<EnemyShip>().m_ShieldData.SetShield(m_ESpawn.enemyPool_[i]);
                        }
                        m_ESpawn.enemyPool_[i].transform.position = spawnPosition;
                        m_ESpawn.enemyPool_[i].transform.rotation = spawnRotation;
                        m_EnemyCount++;
                    }
                    yield return new WaitForSeconds(m_SpawnDelay);
                }

                if (GameObject.FindGameObjectWithTag("Boss") == null)
                {
                    m_ESpawn.m_WaveNum++;
                    m_ESpawn.m_WaveText.text = m_ESpawn.m_WaveNum.ToString("F0");
                    m_GController.SoftSave(m_Player);
                    m_ESpawn.m_BossPanel.alpha = 0;
                    m_ESpawn.m_KillsPanel.alpha = 1;
                }
                yield return new WaitForSeconds(m_WaveDelay);

            }
        }
    }

    public void RestartCurrentWave()
    {
        m_PSpawn.PlayerRespawn();

        m_GController.SetPlayerSave(m_Player);
        m_GController.m_Player.GetComponent<PlayerController>().enabled = true;

        m_ESpawn.m_WaveNum = m_GController.m_TempWaveNum;

        m_ESpawn.AISpawn();
    }
}