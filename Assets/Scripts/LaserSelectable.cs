using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(MeshRenderer))]
public class LaserSelectable : MonoBehaviour
{
    [SerializeField]
    Color m_highlightedColor;

    [SerializeField]
    float m_fadeTime = 0.25f;

    MeshRenderer m_meshRenderer;
    bool m_highlighted;
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
        float target = m_highlighted ? 1.0f : 0.0f;
        float diff = target - m_highlight;

        if (!Mathf.Approximately(diff, 0.0f))
        {
            float delta = m_fadeSpeed * Time.deltaTime;
            m_highlight += Mathf.Sign(diff) * Mathf.Min(Mathf.Abs(diff), delta);
            m_meshRenderer.material.color = Color.Lerp(m_originalColor, m_highlightedColor, m_highlight);
        }
    }

    public bool highlighted
    {
        get { return m_highlighted; }
        set { m_highlighted = value; }
    }
}
