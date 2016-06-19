using UnityEngine;
using System;
using System.Collections;

using VolumetricLines;

public class LaserBeam : MonoBehaviour
{
    public void SetTarget(Vector3 target)
    {
        LineRenderer line = GetComponent<LineRenderer>();
        line.SetPosition(0, transform.parent.position);
        line.SetPosition(1, target);
    }
}
