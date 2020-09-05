using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class RestartHandler : MonoBehaviour {

    public Text scores;
    public Text scores_paused;
    public Transform visPos;
    public Transform gamePos;
    public Transform pausePos;
    private Transform targetPos;
    public GameObject menu;
    private bool ended = false;

    private void Start()
    {
        targetPos = gamePos;
        ended = false;
    }

    public void Display()
    {
        targetPos = visPos;

        if (Scorer.score > PlayerPrefs.GetInt("high", 0)) PlayerPrefs.SetInt("high", Scorer.score);

        scores.text = "Scores: " + Scorer.score + " - High: " + PlayerPrefs.GetInt("high", 0);

        if (Advertisement.IsReady())
        {
            int odds = Random.Range(0, 3);
            if (odds == 0) Advertisement.Show();
        }
        ended = true;
    }

    public void Pause()
    {
        if (Scorer.score > PlayerPrefs.GetInt("high", 0)) PlayerPrefs.SetInt("high", Scorer.score);

        scores_paused.text = "Scores: " + Scorer.score + " - High: " + PlayerPrefs.GetInt("high", 0);

        targetPos = pausePos;
    }

    private void Update()
    {
        if (GameState.state == GameState.State.Crash && !ended) Display();
        if (GameState.state == GameState.State.Pause) Pause();
        if (GameState.state == GameState.State.Play) targetPos = gamePos;
        menu.transform.position = Vector3.Lerp(menu.transform.position, targetPos.position, 0.2f);
    }

    public void Reload()
    {
        GameState.state = GameState.State.Play;
        SceneManager.LoadScene(1);
    }
}
