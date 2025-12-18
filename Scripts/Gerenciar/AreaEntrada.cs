using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrada : MonoBehaviour
{
     void Start()
    {
            Player.Instance.transform.position = GerenciaCena.spawnPosition;
            ControlCamera.Instance.CameraSeguePlayer();
            UIDesvanecer.Instance.Clarear();
    }
}
