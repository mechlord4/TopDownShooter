using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    void Update()
    {
        MeshRenderer mr = GetComponent<MeshRenderer>();
        Material mat = mr.materials[0];//first index of the material area

        Vector2 offset = mat.GetTextureOffset("_MainTex");//Same as mat.maintexture offset\

        offset.y = transform.position.y;

        mat.mainTextureOffset = offset;
    }
}
