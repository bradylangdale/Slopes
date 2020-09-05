using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMonitor : MonoBehaviour {

    public bool X, Y, Z;

    public Vector3 BadValues;

    private void FixedUpdate()
    {
        if (X && transform.position.x == BadValues.x)
        {
            Destroy(gameObject);
            Debug.LogWarning("Bad X position detected!");
        }

        if (Y && transform.position.y == BadValues.y)
        {
            Destroy(gameObject);
            Debug.LogWarning("Bad Y position detected!");
        }

        if (Z && transform.position.z == BadValues.z)
        {
            Destroy(gameObject);
            Debug.LogWarning("Bad Z position detected!");
        }
    }
}
