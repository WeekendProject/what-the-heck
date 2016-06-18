using UnityEngine;
using System.Collections;
using System;

public class CatHead : MonoBehaviour, IAttacker
{
    [SerializeField]
    Transform m_target;

    [SerializeField]
    bool m_trackTarget = true;    
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_trackTarget)
        {
            transform.LookAt(m_target);
        }
    }

    public void Attack(GameObject obj)
    {
        m_trackTarget = false;
        StartCoroutine(AttackCoroutine(obj));
    }

    IEnumerator AttackCoroutine(GameObject obj)
    {
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(obj.transform.position - transform.position);

        float t = 0.0f;
        while (t < 1.0f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            t += 0.1f;

            yield return new WaitForSeconds(0.01f);
        }

        transform.rotation = targetRotation;
    }
}
