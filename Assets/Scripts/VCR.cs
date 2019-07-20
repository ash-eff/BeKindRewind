using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCR : MonoBehaviour
{
    public bool isRewinding = false;
    public bool isPaused = false;
    public float recordTime;
    public float timeRewound;
    public int keyFrame;
    private int frameCounter = 0;
    private int reverseCounter = 0;

    private LinkedList<PointsInTime> pointsIntime;

    private void OnEnable()
    {
        PlayerInput.OnPressedRewind += StartRewind;
        PlayerInput.OnPressedPlay += StopRewind;
        PlayerInput.OnPressedPause += Paused;
    }

    private void OnDisable()
    {
        PlayerInput.OnPressedRewind -= StartRewind;
        PlayerInput.OnPressedPlay -= StopRewind;
        PlayerInput.OnPressedPause -= Paused;
    }

    private void Start()
    {
        pointsIntime = new LinkedList<PointsInTime>();
    }

    private void FixedUpdate()
    {
        if (isRewinding)
        {
            if (reverseCounter > 0)
            {
                reverseCounter--;
            }
            else
            {
                Rewind();
                reverseCounter = keyFrame;
            }
        }
        else
        {
            if (frameCounter < keyFrame)
            {
                frameCounter++;
            }
            else
            {
                frameCounter = 0;
                Record();
            }
        }
    }

    void Rewind()
    {
        isPaused = false;
        if (pointsIntime.Count > 0)
        {
            PointsInTime recordedPoints = pointsIntime.First.Value;
            transform.position = recordedPoints.position;
            transform.rotation = recordedPoints.rotation;
            pointsIntime.RemoveFirst();
        }
        else
        {
            StopRewind();
        }
    }

    void Record()
    {
        if (!isPaused)
        {
            if (pointsIntime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
            {
                pointsIntime.RemoveLast();
            }

            pointsIntime.AddFirst(new PointsInTime(transform.position, transform.rotation));
        }
    }

    void Paused()
    {
        isPaused = !isPaused;
    }

    void StartRewind()
    {
        if (!isPaused)
        {

            isRewinding = true;
        }
    }

    void StopRewind()
    {
        timeRewound = 0;
        isRewinding = false;
    }
}
