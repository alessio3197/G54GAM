using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPlatformScript : MonoBehaviour
{

    public GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        gameController.finished();
    }
}
