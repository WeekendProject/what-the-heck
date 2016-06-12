using UnityEngine;
using System.Collections;

public class FloatingMovement : MonoBehaviour {

    [SerializeField]
    Vector3 m_velocity = new Vector3(0.1f, 0.1f, 0.0f);

    [SerializeField]
    Vector3 m_scale = new Vector3(1, 1, 1);

    float m_elaspedTime;

	// Update is called once per frame
	void Update ()
    {
        float vx = Mathf.Sin(m_scale.x * m_elaspedTime) * Mathf.Cos(m_scale.x * m_elaspedTime) * m_velocity.x;
        float vy = Mathf.Sin(m_scale.y * m_elaspedTime) * Mathf.Cos(m_scale.y * m_elaspedTime) * m_velocity.y;
        float vz = Mathf.Sin(m_scale.z * m_elaspedTime) * Mathf.Cos(m_scale.z * m_elaspedTime) * m_velocity.z;

        Vector3 offset = new Vector3(vx, vy, vz) * Time.deltaTime;
        transform.position += offset;

        m_elaspedTime += Time.deltaTime;
	}
}
