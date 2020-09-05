using UnityEngine;

public class Rock : MonoBehaviour {

    private void Start()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        if (hit.point.y != 0) transform.position = hit.point + new Vector3(0, 0.2f);
        else Destroy(gameObject);
    }
}
