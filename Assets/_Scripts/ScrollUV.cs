using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.materials[0];//first index of the material area

        Vector2 offset = mat.GetTextureOffset("_MainTex");//Same as mat.maintexture offset\

        offset.y += Time.deltaTime/2;

        mat.mainTextureOffset = offset;
    }
}
