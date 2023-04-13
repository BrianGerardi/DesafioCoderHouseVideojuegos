using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera camera1;
    [SerializeField] private CinemachineVirtualCamera camera2;
    private bool isCamera1Active = true;


  private void Update() {
    if (Input.GetKeyDown(KeyCode.J)) {
        if (isCamera1Active) {
            TurnOnCamera(camera2, camera1);
            isCamera1Active = false;
        } else {
            TurnOnCamera(camera1, camera2);
            isCamera1Active = true;
        }
    }
}
   private void TurnOnCamera (CinemachineVirtualCamera camToTurnOn, CinemachineVirtualCamera otherCamera)
   {
    camToTurnOn.gameObject.SetActive (true);
    otherCamera.gameObject.SetActive (false);

   }
 }

