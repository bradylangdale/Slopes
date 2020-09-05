using UnityEngine;

public class DestroyObject : MonoBehaviour {

    public bool layered = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ClearPlane")
        {
            if (layered) Destroy(gameObject.transform.parent.gameObject);
            else Destroy(gameObject);
        }

        Debug.Log("Collision: "+ collision.gameObject.tag);
    }
}
