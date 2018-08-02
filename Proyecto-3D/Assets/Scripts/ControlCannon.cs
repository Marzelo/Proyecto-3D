using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCannon : MonoBehaviour {

    public Player activePlayer;
    public Collider triggerArea;

    public readonly string containerName = "Control";
    public readonly Vector3 idlePoint = new Vector3(0.5f, 0.75f, 0f);
    public readonly Vector3 center = new Vector3(0f, 0.75f, 0f);


    bool waitForNextAction = false;
    public bool isWaiting { get { return waitForNextAction; } }

    // Use this for initialization
    void Start()
    {
        if (!activePlayer)
        {
            triggerArea.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            PlayerControlManager.instance.SwapControl2();
        }

    }

    public void AssignActivePlayer(Player targetplayer)
    {
        activePlayer = targetplayer;
        transform.SetParent(activePlayer.transform.Find(containerName));
        transform.localPosition = Vector3.zero;
        transform.rotation = targetplayer.transform.rotation;
        triggerArea.enabled = false;
        GetComponent<Animator>().SetFloat("IdleSpeed", 0.5f);
    }

    public void ResetPoint()
    {
        transform.parent.localPosition = idlePoint;
        waitForNextAction = false;
    }
}
