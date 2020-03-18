using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMove : MonoBehaviour
{
    public Vector2 MoveDirectionSpeed; // Direction to move texture
    Vector2 uvOffset = Vector2.zero; // Offset of texture

    string TextureName = "_MainTex";
    int MatIndex = 0;
    Renderer rend; // Renderer ref

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        uvOffset += (MoveDirectionSpeed * Time.deltaTime);
        if (rend.enabled)
        {
            rend.materials[MatIndex].SetTextureOffset(TextureName, uvOffset);
        }
    }
}
