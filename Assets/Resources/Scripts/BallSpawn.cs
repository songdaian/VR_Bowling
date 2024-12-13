using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject m_BallPrefab;//保龄球预制体
    //public List<Texture> m_Textures;//保龄球贴图列表
    //private int m_TextureIndex = 0;//保龄球贴图索引
    private int m_TargetBallCount = 5;//保龄球的目标数量
    private int m_CurrentBallCount = 0;//当前的保龄球数量
    private float m_SpawnInterval = 2.0f;//生成保龄球的时间间隔
    private float m_SpawnTimer = 0.0f;//生保龄球的计时器
    public static BallSpawn Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Update()
    {
        if (m_CurrentBallCount < m_TargetBallCount)
        {
            m_SpawnTimer += Time.deltaTime;
            if (m_SpawnTimer > m_SpawnInterval)
            {
                m_SpawnTimer = 0.0f;
                //创建保龄球
                Spawn();
            }

        }
    }

    /// <summary>
    /// 创建保龄球
    /// </summary>
    private void Spawn()
    {
        GameObject ball;

        if (BallPool.Instance.transform.childCount > 0)
        {
            //从缓冲池中取出保龄球
            ball = BallPool.Instance.GetBall();
        }
        else
        {
            //生成新的保龄球
            ball = Instantiate(m_BallPrefab);
        }

        //重置保龄球的位置与角度
        ball.transform.position = transform.position;
        ball.transform.rotation = Quaternion.identity;

        //ball.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", m_Textures[m_TextureIndex]);

        //m_TextureIndex++;
        //if (m_TextureIndex >= m_Textures.Count)
        //{
        //    m_TextureIndex = 0;
        //}

        //保龄球数量增加
        m_CurrentBallCount += 1;
    }

    /// <summary>
    /// 减少当前保龄球数量
    /// </summary>
    public void ReduceCurrentBallCount()
    {
        if (m_CurrentBallCount > 0)
        {
            m_CurrentBallCount--;
        }
    }
}
