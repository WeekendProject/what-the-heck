using UnityEngine;
using System.Collections;

public class Explodable : MonoBehaviour
{
    [SerializeField]
    GameObject[] m_explosions;

    [SerializeField]
    GameObject m_exploded;

    #region Explosions

    public void Explode()
    {
        CreateExplosion();
        CreateExploded();

        Destroy(gameObject);
    }
    
    void CreateExplosion()
    {
        int index = Random.Range(0, m_explosions.Length - 1);
        Instantiate(m_explosions[index], transform.position, Quaternion.identity);
    }

    void CreateExploded()
    {
        if (m_exploded)
        {
            Instantiate(m_exploded, transform.position, Quaternion.identity);
        }
    }

    #endregion
}
