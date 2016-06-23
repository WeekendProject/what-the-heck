using UnityEngine;
using System.Collections;

[RequireComponent(typeof(LineRenderer))]
public class LaserPointer : MonoBehaviour
{
    [SerializeField]
    LayerMask m_hitLayerMask;

    CatHead m_catHead;
    LineRenderer m_lineRenderer;

    void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
        m_catHead = FindObjectOfType<CatHead>();
        if (m_catHead == null)
        {
            throw new UnityException("Missing cat head object");
        }
    }

    void Update()
    {
        m_lineRenderer.SetPosition(0, transform.position);

        Vector3 direction = transform.rotation * Vector3.forward;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, 100, m_hitLayerMask))
        {
            m_lineRenderer.SetPosition(1, hit.point);

            GameObject hitObject = hit.collider.gameObject;
            LaserSelectable selectable = hitObject.GetComponent<LaserSelectable>();
            if (selectable != null)
            {
                // selectable.sethi
                if (Input.GetMouseButtonDown(0))
                {
                    Explodable explodable = hitObject.GetComponent<Explodable>();
                    if (explodable != null)
                    {
                        m_catHead.Attack(explodable);
                    }
                }
            }
        }
        else
        {
            m_lineRenderer.SetPosition(1, direction * 100);
        }
    }
}
