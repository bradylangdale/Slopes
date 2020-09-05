using UnityEngine;

public class GameState : MonoBehaviour {

    public enum State
    {
        Play,
        Crash,
        Pause
    }

    public static State state;

    private void Start()
    {
        state = State.Play;
    }
}
