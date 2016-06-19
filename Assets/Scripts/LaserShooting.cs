using UnityEngine;
using System.Collections;

public class LaserShooting : MonoBehaviour {

    [SerializeField]
    LaserBeam m_laserBeam;

    [SerializeField]
    Transform m_leftEye;

    [SerializeField]
    Transform m_rightEye;

    [SerializeField]
    float m_attackDuration = .5f;

    public void ShootLasersAt(Explodable explodable)
    {
        LaserBeam leftBeam = CreateBeamAt(m_leftEye, explodable.laserTarget);
        LaserBeam rightBeam = CreateBeamAt(m_rightEye, explodable.laserTarget);

        StartCoroutine(FinishAttack(explodable, leftBeam, rightBeam));
    }

    LaserBeam CreateBeamAt(Transform parent, Vector3 target)
    {
        LaserBeam beam = Instantiate(m_laserBeam);
        beam.transform.parent = parent;
        beam.SetTarget(target);
        return beam;
    }

    IEnumerator FinishAttack(Explodable explodable, LaserBeam leftBeam, LaserBeam rightBeam)
    {
        yield return new WaitForSeconds(m_attackDuration);

        Destroy(leftBeam.gameObject);
        Destroy(rightBeam.gameObject);

        explodable.Explode();
    }
}
