using UnityEngine;
using System.Collections;

public class CatHead : MonoBehaviour
{
    [SerializeField]
    [Tooltip("A transform to follow")]
    Transform target;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
    }
}
