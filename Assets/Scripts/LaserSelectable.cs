using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class LaserSelectable : MonoBehaviour
{
    [SerializeField]
    Color m_highlightedColor;

    [SerializeField]
    float m_fadeTime = 1.0f;

    MeshRenderer m_meshRenderer;
    float m_highlight;
    Color m_originalColor;
    float m_fadeSpeed;
    
    void Awake()
    {
        m_meshRenderer = GetComponent<MeshRenderer>();
        m_originalColor = m_meshRenderer.material.color;
        m_fadeSpeed = 1.0f / m_fadeTime;
    }

    void Update()
    {
        if (m_highlight > 0)
        {
            float delta = m_fadeSpeed * Time.deltaTime;
            m_highlight -= Mathf.Min(delta, m_highlight);
            m_meshRenderer.material.color = Color.Lerp(m_originalColor, m_highlightedColor, m_highlight);
        }
    }

    public void LaserHit()
    {
        m_highlight = 1.0f;
    }
}
