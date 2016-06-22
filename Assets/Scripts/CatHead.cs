using UnityEngine;
using System.Collections;
using System;

public class CatHead : MonoBehaviour, IAttacker
{
    [SerializeField]
    Transform m_lookTarget;

    [SerializeField]
    CatPosition m_targetPosition;

    [SerializeField]
    float m_arrivalTime = 1.0f;

    LaserShooting m_lasetShooting;
    FloatingMovement m_floatingMovement;

    bool m_followTarget = true;
    bool m_lookAtTarget = true;

    float m_floatHeight;

    void Awake()
    {
        m_lasetShooting = GetComponent<LaserShooting>();
        if (m_targetPosition != null)
        {
            transform.position = m_targetPosition.transform.position;
            transform.LookAt(m_targetPosition.transform);

            m_floatHeight = m_targetPosition.transform.position.y;
        }

        m_floatingMovement = GetComponent<FloatingMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_followTarget && m_targetPosition != null)
        {
            Vector3 targetPosition = m_targetPosition.transform.position;
            targetPosition.y = m_floatHeight;

            Vector3 distance = targetPosition - transform.position;
            float distanceMagnitude = distance.magnitude;
            if (distanceMagnitude > 0.01f)
            {
                Vector3 direction = distance.normalized;
                float speed = distanceMagnitude / m_arrivalTime;

                Vector3 offset = speed * direction * Time.deltaTime;
                transform.position += distance.sqrMagnitude < offset.sqrMagnitude ? distance : offset;
            }
        }

        if (m_lookAtTarget && m_lookTarget != null)
        {
            transform.LookAt(m_lookTarget);
        }
    }

    public void Attack(Explodable explodable)
    {
        StartCoroutine(AttackCoroutine(explodable));
    }

    IEnumerator AttackCoroutine(Explodable explodable)
    {
        m_followTarget = false;
        m_lookAtTarget = false;

        m_floatingMovement.enabled = false;

        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(explodable.laserTarget - transform.position);

        // rotate to the target
        float t = 0.0f;
        while (t < 1.0f)
        {
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);
            t += 0.1f;

            yield return new WaitForSeconds(0.01f);
        }

        transform.rotation = targetRotation;

        // shoot lasers
        m_lasetShooting.ShootLasersAt(explodable);

        yield return new WaitForSeconds(1.0f);

        m_floatingMovement.enabled = true;
        m_followTarget = true;
        m_lookAtTarget = true;
    }
}
