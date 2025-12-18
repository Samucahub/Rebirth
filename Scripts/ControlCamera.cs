using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ControlCamera : Unico<ControlCamera>
{
    private CinemachineVirtualCamera CVC;

    private void Start() {
        CameraSeguePlayer();
    }

    public void CameraSeguePlayer() {
        CVC = FindObjectOfType<CinemachineVirtualCamera>();
        CVC.Follow = Player.Instance.transform;
    }
}
