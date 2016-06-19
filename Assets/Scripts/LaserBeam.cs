using UnityEngine;
using System;
using System.Collections;

using VolumetricLines;

[RequireComponent(typeof(VolumetricLineBehavior))]
public class LaserBeam : MonoBehaviour
{
    VolumetricLineBehavior m_volumetricLine;

    public void SetTarget(Transform target)
    {
        print(target.position + " " + transform.position);

        volumetricLine.StartPos = transform.position;
        volumetricLine.EndPos = target.position;
    }

    VolumetricLineBehavior volumetricLine
    {
        get
        {
            if (m_volumetricLine == null)
                m_volumetricLine = GetComponent<VolumetricLineBehavior>();
            return m_volumetricLine;
        }
    }
}
