using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class LaserHitHandler : MonoBehaviour
{
    SteamVR_LaserPointer m_laserPointer;

    void Awake()
    {
        m_laserPointer = GetComponent<SteamVR_LaserPointer>();
        m_laserPointer.PointerIn += OnPointerIn;
        m_laserPointer.PointerOut += OnPointerOut;
    }

    void Destroy()
    {
        m_laserPointer.PointerIn -= OnPointerIn;
        m_laserPointer.PointerOut -= OnPointerOut;
    }

    #region Hit handlers

    void OnPointerIn(object sender, PointerEventArgs e)
    {
        TrySetHighlighted(e.target.gameObject, true);
    }

    void OnPointerOut(object sender, PointerEventArgs e)
    {
        TrySetHighlighted(e.target.gameObject, false);
    }

    void TrySetHighlighted(GameObject hitObject, bool highlighted)
    {
        LaserSelectable selectable = hitObject.GetComponent<LaserSelectable>();
        if (selectable != null)
        {
            selectable.highlighted = highlighted;
        }
    }

    #endregion
}
