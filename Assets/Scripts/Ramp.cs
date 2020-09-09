using UnityEngine;

public class Ramp : MonoBehaviour {

    private void Start()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit))
            transform.position = hit.point;
        else
            Destroy(gameObject);

        if (hit.point.y > 0.5) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jump");
        other.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, 25,0));
    }
}
