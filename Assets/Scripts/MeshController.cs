using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    private Mesh _mesh;
    // Start is called before the first frame update
    void Start()
    {
        _mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
    }

    // Update is called once per frame
    void Update()
    {
        _mesh.RecalculateNormals();
        _mesh.RecalculateTangents();
    }
}
