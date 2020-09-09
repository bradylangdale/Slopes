using UnityEngine;

public class Rock : MonoBehaviour {

    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            transform.position = hit.point + new Vector3(0, -0.2f);
        else
            Destroy(gameObject);

        if (hit.point.y > 0.75) Destroy(gameObject);
    }
}
