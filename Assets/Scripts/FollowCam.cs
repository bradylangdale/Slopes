using UnityEngine;

public class FollowCam : MonoBehaviour {

    public Transform target;
    public Vector3 offsets;

    // Update is called once per frame
    void FixedUpdate () {
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, target.position + offsets, 0.3f);
	}
}
