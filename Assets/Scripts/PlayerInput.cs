using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public delegate void PlayerInputEvent();
    public static event PlayerInputEvent OnPressedPlay;
    public static event PlayerInputEvent OnPressedPause;
    public static event PlayerInputEvent OnPressedRewind;

    public float rewindTime;

    private float currentRewindTime;

    private void Start()
    {
        currentRewindTime = rewindTime;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Return))
        {
            currentRewindTime -= Time.deltaTime;
            if (currentRewindTime < 0)
            {
                OnPressedPlay?.Invoke();
            }
            else
            {
                OnPressedRewind?.Invoke();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            currentRewindTime = rewindTime;
            OnPressedPlay?.Invoke();
        }

        if (currentRewindTime == rewindTime && Input.GetKeyDown(KeyCode.R))
        {
            OnPressedPause?.Invoke();
        }
    }
}
