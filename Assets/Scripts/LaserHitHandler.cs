using UnityEngine;
using System.Collections;

using Valve.VR;

[RequireComponent(typeof(SteamVR_LaserPointer))]
public class LaserHitHandler : MonoBehaviour
{
    SteamVR_LaserPointer m_laserPointer;
    int m_controllerIndex;
    Explodable m_explodable;

    void Awake()
    {
        m_laserPointer = GetComponent<SteamVR_LaserPointer>();
        m_laserPointer.PointerIn += OnPointerIn;
        m_laserPointer.PointerOut += OnPointerOut;
        m_controllerIndex = -1;
    }

    void Update()
    {
        if (m_controllerIndex != -1 && m_explodable != null && SteamVR_Controller.Input(m_controllerIndex).GetPressDown(EVRButtonId.k_EButton_SteamVR_Trigger))
        {
            CatHead catHead = FindObjectOfType<CatHead>();
            catHead.Attack(m_explodable);
            m_explodable = null;
        }
    }

    void Destroy()
    {
        m_laserPointer.PointerIn -= OnPointerIn;
        m_laserPointer.PointerOut -= OnPointerOut;
    }

    #region Hit handlers

    void OnPointerIn(object sender, PointerEventArgs e)
    {
        m_controllerIndex = (int) e.controllerIndex;
        print(m_controllerIndex);

        TrySetHighlighted(e.target.gameObject, true);
    }

    void OnPointerOut(object sender, PointerEventArgs e)
    {   
        TrySetHighlighted(e.target.gameObject, false);
        m_controllerIndex = -1;
        m_explodable = null;
    }

    void TrySetHighlighted(GameObject hitObject, bool highlighted)
    {
        LaserSelectable selectable = hitObject.GetComponent<LaserSelectable>();
        if (selectable != null)
        {
            selectable.highlighted = highlighted;
            m_explodable = selectable.GetComponent<Explodable>();
        }
        else
        {
            m_explodable = null;
        }
    }

    #endregion
}
