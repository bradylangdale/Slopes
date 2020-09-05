using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour {

    public void Load(int scene)
    {
        GameState.state = GameState.State.Play;
        Time.timeScale = 1;
        SceneManager.LoadScene(scene);
    }
}
