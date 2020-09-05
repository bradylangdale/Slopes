using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour {

    public Transform cam;
    public Text score_label;
    public static int score = 0;

    private void Start()
    {
        score = 0;
    }

    private void Update()
    {
        transform.LookAt(cam.position);
    }

    public void AddScore()
    {
        score++;
        score_label.text = "Score: " + score;
    }
}