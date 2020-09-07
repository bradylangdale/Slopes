using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject tileFab;
    private Vector3 last;
    private int prevdelta;
    public int delta;
    public int step;
    private Rigidbody rb;
    public GameObject[] objectsFabs;
    public Scorer scoreboard;
    private float offset;
    private Vector3 startRot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        CenterGyro();
        startRot = transform.rotation.eulerAngles;
    }

    public void Pause()
    {
        Time.timeScale = 0;
        GameState.state = GameState.State.Pause;
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameState.state = GameState.State.Play;
    }

    void FixedUpdate() {

        if (transform.position.y < -3) GameState.state = GameState.State.Crash;

        if (GameState.state == GameState.State.Crash)
        {
            Screen.sleepTimeout = SleepTimeout.SystemSetting;
            ground();
            center();
            return;
        }

        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        if (rb.velocity.z < 30) rb.AddRelativeForce((Vector3.back * 2f));
        rb.velocity = new Vector3(Mathf.Lerp(rb.velocity.x, 0, 0.01f), rb.velocity.y, rb.velocity.z);
        ground();
        center();

        rb.velocity += new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        rb.velocity += new Vector3((Input.acceleration.x + offset) / 2f, 0, 0);
    }

    private void center()
    {
        Vector3 rot = startRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot), 0.2f);
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + ((Input.acceleration.x + offset) * 8), transform.rotation.eulerAngles.z));
    }

    private void ground()
    {
        delta = ((((int)(transform.position.z / 10)) * 10) - (int)transform.position.z);
        if (Math.Abs(delta) >= 9 && prevdelta != delta)
        {
            step++;
            if (GameState.state == GameState.State.Play) scoreboard.AddScore();
        }
        prevdelta = delta;

        if (step >= 2)
        {
            step = 0;
            Vector3 tilesPos = new Vector3(((int)(transform.position.x / 10)) * 10f, -1.34f, (((int)(transform.position.z / 10)) * 10f) + 90);
            if (last != tilesPos)
            {
                last = tilesPos;
                Debug.Log(tilesPos);
                objects(tilesPos);
                Instantiate(tileFab, tilesPos, tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(-20, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(20, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(-40, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(40, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(-60, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(60, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(-80, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(80, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(-100, 0, 0), tileFab.transform.rotation);
                Instantiate(tileFab, tilesPos + new Vector3(100, 0, 0), tileFab.transform.rotation);
            }
        }
    }

    private void objects(Vector3 midPos)
    {
        Vector3[] tiles = new Vector3[11];
        tiles[0] = midPos;
        tiles[1] = midPos + new Vector3(20, 0, 0);
        tiles[2] = midPos + new Vector3(-20, 0, 0);
        tiles[3] = midPos + new Vector3(40, 0, 0);
        tiles[4] = midPos + new Vector3(-40, 0, 0);
        tiles[5] = midPos + new Vector3(60, 0, 0);
        tiles[6] = midPos + new Vector3(-60, 0, 0);
        tiles[7] = midPos + new Vector3(80, 0, 0);
        tiles[8] = midPos + new Vector3(-80, 0, 0);
        tiles[9] = midPos + new Vector3(100, 0, 0);
        tiles[10] = midPos + new Vector3(-100, 0, 0);

        foreach (Vector3 pos in tiles)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject fab = objectsFabs[UnityEngine.Random.Range(0, objectsFabs.Length)];
                Vector3 newPos = new Vector3(pos.x + UnityEngine.Random.Range(-19, 19), fab.transform.position.y, pos.z + UnityEngine.Random.Range(-19, 19));
                Instantiate(fab, newPos, fab.transform.rotation);
            }
        }
    }

    private void CenterGyro()
    {
        offset = -Input.acceleration.x;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Object") GameState.state = GameState.State.Crash;
    }
}
