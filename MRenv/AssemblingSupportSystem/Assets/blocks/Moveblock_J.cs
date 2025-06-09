using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveblock_J : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Transform mytransform = this.transform;

        Vector3 pos = mytransform.position;

        pos.x += 0.05f;
        pos.y += 0.05f;
        pos.z += 0.05f;

        mytransform.position = pos;
        
    }
}
