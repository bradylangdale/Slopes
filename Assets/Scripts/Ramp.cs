using UnityEngine;

public class Ramp : MonoBehaviour {

    private void Start()
    {
        RaycastHit hit;
        Physics.Raycast(transform.parent.gameObject.transform.position, Vector3.down, out hit);
        if (hit.point.y != 0) transform.parent.gameObject.transform.position = hit.point;
        else Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Jump");
        other.GetComponentInParent<Rigidbody>().AddForce(new Vector3(0, 25,0));
    }
}
