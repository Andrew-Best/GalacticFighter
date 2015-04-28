using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawn : MonoBehaviour
{
    #region variables
    public GameData m_GData;
    public Waves m_Waves;
    public GameController m_GController;

    public List<GameObject> m_Enemies = new List<GameObject>();
    public List<GameObject> m_CurrentEnemies = new List<GameObject>();
    public List<GameObject> m_LightEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_MediumEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_HeavyEnemyPrefabs = new List<GameObject>();
    public List<GameObject> m_MiniBossPrefabs = new List<GameObject>();
    public List<GameObject> m_BossPrefabs = new List<GameObject>();
    public List<GameObject> enemyPool_ = new List<GameObject>();
    public List<GameObject> bossPool_ = new List<GameObject>();

    public CanvasGroup m_KillsPanel;
    public CanvasGroup m_BossPanel;

    public Text m_WaveText;
    public Text m_ReqKillText;
    public Text m_Control;

    public GameObject m_LightEmemy;
    public GameObject m_MediumEmemy;
    public GameObject m_HeavyEmemy;
    public GameObject m_MiniBoss;
    public GameObject m_Boss;
    public GameObject m_BossObj;

    public float m_SpawnDelay;
    public float m_StartDelay;
    public float m_WaveDelay;

    public int m_RequiredKills;
    public int m_WaveNum;
    public int maxPoolSize_;

    public GameObject m_Player;

    private Task spawn_;
    #endregion

    public void SetShipPrefab()
    {
        m_LightEmemy = m_LightEnemyPrefabs[m_GData.m_Level - 1];
        m_MediumEmemy = m_MediumEnemyPrefabs[m_GData.m_Level - 1];
        m_HeavyEmemy = m_HeavyEnemyPrefabs[m_GData.m_Level - 1];
        m_MiniBoss = m_MiniBossPrefabs[m_GData.m_Level - 1];
        m_Boss = m_BossPrefabs[m_GData.m_Level - 1];
    }
    public void Update()
    {
        m_Player = Camera.main.GetComponent<SpawnPlayer>().m_Player;

        if (m_GController.m_Play)
        {
            if (m_Player == null)
            {
                spawn_.Stop();
                m_GController.EnableRestart();
            }

            if (m_RequiredKills == 0)
            {
                DestroyAllEnemies();
                m_WaveNum++;
                m_WaveText.text = m_WaveNum.ToString("F0");

                /*if(m_WaveNum == 6)
                {
                    m_GData.Save();
                    m_Control.text = "Next Wave";
                    AISpawn();
                }*/
                if (m_WaveNum == 11)
                {
                    m_GController.m_Play = false;
                    m_GData.Save();
                    m_GController.Win();
                }
                else
                {
                    m_Control.text = "Next Wave";
                    AISpawn();
                }
            }
        }
    }

    public void AISpawn()
    {
        if (m_WaveNum == 0)
        {
            m_WaveNum++;
            m_WaveText.text = m_WaveNum.ToString("F0");

            SetShipPrefab();
        }

        if (m_WaveNum == 1)
        {
            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);

            WaveSetup(10);
        }

        if (m_WaveNum == 2)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);

            WaveSetup(15);
        }

        if (m_WaveNum == 3)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);

            WaveSetup(20);
        }

        if (m_WaveNum == 4)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(25);
        }

        if (m_WaveNum == 5)
        {
            m_GController.SoftSave(m_Player);

            //Set Boss to Spawn
            BossSetUp(m_MiniBoss, 15);
        }

        if (m_WaveNum == 6)
        {
            m_GData.Save();
            m_GController.SoftSave(m_Player);
            m_KillsPanel.alpha = 1;

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(30);
        }

        if (m_WaveNum == 7)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(35);
        }

        if (m_WaveNum == 8)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(40);
        }

        if (m_WaveNum == 9)
        {
            m_GController.SoftSave(m_Player);

            //clear enemy array
            m_Enemies.Clear();
            enemyPool_.Clear();

            //populate enemy array
            m_Enemies.Add(m_LightEmemy);
            m_Enemies.Add(m_MediumEmemy);
            m_Enemies.Add(m_HeavyEmemy);

            WaveSetup(45);
        }

        if (m_WaveNum == 10)
        {
            m_GController.SoftSave(m_Player);

            //Set Boss to Spawn
            BossSetUp(m_Boss, 20);
        }
    }

    public void BossSetUp(GameObject boss, int numEnemies)
    {

        m_BossObj = boss;

        //Turn on the Boss UI
        m_BossPanel.alpha = 0;

        //turn off kills required panel
        m_KillsPanel.alpha = 0;

        //clear enemy array
        m_Enemies.Clear();
        enemyPool_.Clear();

        //populate enemy array
        m_Enemies.Add(m_LightEmemy);
        m_Enemies.Add(m_MediumEmemy);

        GameObject bossObj = (GameObject)Instantiate(m_BossObj);
        m_BossObj.SetActive(false);
        bossPool_.Add(bossObj);

        Vector3 bossSpawn = new Vector3(0.0f, 8.0f, 0.0f);
        Quaternion spawnBossRotation = Quaternion.identity;

        m_BossObj.GetComponent<EnemyShip>().m_ShieldData.SetShield(m_BossObj);

        m_BossObj.SetActive(true);
        m_BossObj.transform.position = bossSpawn;
        m_BossObj.transform.rotation = spawnBossRotation;

        enemyPool_.Capacity = numEnemies;

        for (int i = 0; i < enemyPool_.Capacity; i++)
        {
            int randEnemy = Random.Range(0, m_Enemies.Count);

            GameObject obj = (GameObject)Instantiate(m_Enemies[randEnemy]);
            obj.SetActive(false);
            enemyPool_.Add(obj);
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            spawn_ = new Task(m_Waves.BossSpawner(), true);
        }
    }

    public void WaveSetup(int kills)
    {
        m_RequiredKills = kills;
        m_ReqKillText.text = m_RequiredKills.ToString("F0");

        enemyPool_.Capacity = kills;

        for (int i = 0; i < enemyPool_.Capacity; i++)
        {
            int randEnemy = Random.Range(0, m_Enemies.Count);

            GameObject obj = (GameObject)Instantiate(m_Enemies[randEnemy]);
            obj.SetActive(false);
            enemyPool_.Add(obj);
            for (int j = 0; j < enemyPool_.Count; ++j)
            {
                enemyPool_[j].gameObject.name = "Enemy" + j;
            }
        }
        spawn_ = new Task(m_Waves.WaveSpawner(), true);
    }

    public void DestroyAllEnemies()
    {
        for(int i = 0; i < enemyPool_.Count; ++i)
        {
            Destroy(enemyPool_[i]);
        }
        enemyPool_.Clear();

        spawn_.Stop();
    }
}
