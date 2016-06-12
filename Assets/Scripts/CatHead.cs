using UnityEngine;
using System.Collections;

public class CatHead : MonoBehaviour
{
    [SerializeField]
    Transform m_target;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(m_target);
    }
}
