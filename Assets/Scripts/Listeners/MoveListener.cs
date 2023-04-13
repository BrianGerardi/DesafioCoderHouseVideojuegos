using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveListener : MonoBehaviour
{
    public FPSController fpsController;
     public AudioSource audioSource; 
    public AudioClip soundClip; 
    private bool isMoving = false;



  private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundClip;
    }
  private void OnEnable()
    {Debug.Log("Move enable event subscribed by " + gameObject.name);

        fpsController.OnMove.AddListener(StartMoving);
    }

    private void OnDisable()
    {Debug.Log("Move disable event unsubscribed by " + gameObject.name);

        fpsController.OnMove.RemoveListener(StartMoving);
        StopMoving();
    }

    private void StartMoving(Vector3 direction)
    {Debug.Log("Move event called from " + fpsController.gameObject.name + " and received by " + gameObject.name);

        if (!isMoving)
        {
            isMoving = true;
            audioSource.Play();
        }
    }

    private void StopMoving()
    {
        isMoving = false;
        audioSource.Stop();
    }

    private void Update()
    {
        if (isMoving && !fpsController.IsMoving())
        {
            StopMoving();
        }
    }
}