using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBeamScript : MonoBehaviour
{
    public GameObject obstacle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate());
    }

    private IEnumerator Generate()
    {
        float newZPos = 0f;
        for(int i = 0; i < 6; i++)
        {
            Instantiate(obstacle, new Vector3(transform.position.x+0.05f, transform.position.y + 0.05f, transform.position.z + newZPos),obstacle.transform.rotation,transform);
            newZPos -= 4.99f;
            yield return new WaitForSeconds(Random.Range(0.1f,0.7f));
        }
    }

}
