using UnityEngine;
using System.Collections;

using VolumetricLines;

[RequireComponent(typeof(VolumetricLineBehavior))]
public class LaserBeamAnimator : MonoBehaviour
{
    [SerializeField]
    float m_minFactor = 0.85f;

    [SerializeField]
    float m_maxFactor = 0.95f;

    [SerializeField]
    float m_speed = 10.0f;

    VolumetricLineBehavior m_line;
    float m_totalTime;

	void Awake ()
    {
        m_line = GetComponent<VolumetricLineBehavior>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_line.LineWidth = Mathf.Lerp(m_minFactor, m_maxFactor, Mathf.Sin(m_speed * m_totalTime));
        m_totalTime += Time.deltaTime;   
	}
}
