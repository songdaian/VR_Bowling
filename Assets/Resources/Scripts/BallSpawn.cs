using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject m_BallPrefab;//������Ԥ����
    //public List<Texture> m_Textures;//��������ͼ�б�
    //private int m_TextureIndex = 0;//��������ͼ����
    private int m_TargetBallCount = 5;//�������Ŀ������
    private int m_CurrentBallCount = 0;//��ǰ�ı���������
    private float m_SpawnInterval = 2.0f;//���ɱ������ʱ����
    private float m_SpawnTimer = 0.0f;//��������ļ�ʱ��
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
                //����������
                Spawn();
            }

        }
    }

    /// <summary>
    /// ����������
    /// </summary>
    private void Spawn()
    {
        GameObject ball;

        if (BallPool.Instance.transform.childCount > 0)
        {
            //�ӻ������ȡ��������
            ball = BallPool.Instance.GetBall();
        }
        else
        {
            //�����µı�����
            ball = Instantiate(m_BallPrefab);
        }

        //���ñ������λ����Ƕ�
        ball.transform.position = transform.position;
        ball.transform.rotation = Quaternion.identity;

        //ball.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", m_Textures[m_TextureIndex]);

        //m_TextureIndex++;
        //if (m_TextureIndex >= m_Textures.Count)
        //{
        //    m_TextureIndex = 0;
        //}

        //��������������
        m_CurrentBallCount += 1;
    }

    /// <summary>
    /// ���ٵ�ǰ����������
    /// </summary>
    public void ReduceCurrentBallCount()
    {
        if (m_CurrentBallCount > 0)
        {
            m_CurrentBallCount--;
        }
    }
}
