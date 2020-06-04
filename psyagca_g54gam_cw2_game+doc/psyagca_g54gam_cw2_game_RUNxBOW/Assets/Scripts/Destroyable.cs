using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{

    //public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // script for the target
    public int timeBonus = 2;
    private void OnCollisionEnter(Collision collision)
    {
        // destroy this object
        Destroy(gameObject);
    }
    /*private void OnDestroy()
    {
        // tell the game controller
        if (gameController != null)
        {
            //gameController.timeLeft = gameController.timeLeft + 5.0f; 
            gameController.TargetDestroyed(timeBonus);
        }
    }*/

}
