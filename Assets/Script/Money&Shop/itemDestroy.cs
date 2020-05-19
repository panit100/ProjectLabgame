using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemDestroy : MonoBehaviour
{
    float DestoryTime = 60;
    float countdown = 0;

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;
        if(countdown >= DestoryTime){
            Destroy(gameObject);
        }
    }
}
