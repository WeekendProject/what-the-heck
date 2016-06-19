using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour {

    [SerializeField]
    LaserBeam m_laserBeam;

    [SerializeField]
    Transform m_leftEye;

    [SerializeField]
    Transform m_rightEye;

    public void ShootLasersAt(Vector3 target)
    {
        CreateBeamAt(m_leftEye, target);
        CreateBeamAt(m_rightEye, target);
    }

    LaserBeam CreateBeamAt(Transform parent, Vector3 target)
    {
        LaserBeam beam = Instantiate(m_laserBeam);
        beam.transform.parent = parent;
        beam.SetTarget(target);
        return beam;
    }
}
