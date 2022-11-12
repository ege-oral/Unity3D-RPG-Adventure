using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConvertToRegularMesh : MonoBehaviour
{
    [ContextMenu("Convert to regular mesh")]
    void Convert()
    {
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();

        meshFilter.sharedMesh = skinnedMeshRenderer.sharedMesh;
        meshRenderer.sharedMaterial = skinnedMeshRenderer.sharedMaterial;

        DestroyImmediate(skinnedMeshRenderer);
        DestroyImmediate(this);
    }
}
