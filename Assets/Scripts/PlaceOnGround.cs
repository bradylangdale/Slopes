using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOnGround : MonoBehaviour
{
    public float offset = 0.75f;
    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            transform.position = new Vector3(transform.position.x, hit.point.y - offset, transform.position.z);
        else
            Destroy(gameObject);

        if (hit.point.y > 0.75) Destroy(gameObject);
    }
}
