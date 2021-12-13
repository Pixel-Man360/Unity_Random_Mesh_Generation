using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private int _sizeInXAxis = 25;
    [SerializeField] private int _sizeInZAxis = 25;
    private Mesh _mesh;
    private MeshFilter _meshFilter;

    private Vector3[] _vertices;
    private int[] _triangles;

    void Awake()
    {
        _mesh = new Mesh();
        _meshFilter = GetComponent<MeshFilter>();
        
    }

    void Start()
    {
        _meshFilter.mesh = _mesh;
        
        string[][] emp = new string[][]{};
        CreateNewMesh(emp);
    }

    public void CreateNewMesh(string[][] data)
    {
      _mesh.Clear();

      
      _sizeInXAxis += UnityEngine.Random.Range(0, 75);
      _sizeInZAxis += UnityEngine.Random.Range(0, 75);
        
       CreateVertices(data);
       CreateTriangles(data);

      _mesh.vertices = _vertices;
      _mesh.triangles = _triangles;
      _mesh.RecalculateNormals();
      _mesh.Optimize();
    }



    void CreateVertices(string[][] data)
    {
        if(data.Length == 0)
        {    _vertices = new Vector3[(_sizeInXAxis + 1) * (_sizeInZAxis + 1)];
            int currVert = 0;

            for(int k = 0 ; k <= _sizeInZAxis; k++)
            {
                for(int i = 0; i <= _sizeInXAxis; i++)
                {
                    float j = Mathf.PerlinNoise(i * UnityEngine.Random.Range(0.1f, .9f), k * UnityEngine.Random.Range(0.1f, .9f)) * UnityEngine.Random.Range(0.5f, 3f);
                    _vertices[currVert] = new Vector3(i, j, k);
                    currVert++;
                }
            }
        }

        else
        {
            _vertices = new Vector3[data.Length + 1];
            int currVert = 0;

            for(int i = 1 ; i <= data.Length; i++)
            {
                if(data[i][0] == "")
                 break;
                _vertices[currVert] = new Vector3(float.Parse(data[i][0], NumberStyles.AllowLeadingSign), float.Parse(data[i][1], NumberStyles.AllowLeadingSign), float.Parse(data[i][2], NumberStyles.AllowLeadingSign));
                currVert++;
                
            }
        }

        
    }

    void CreateTriangles(string[][] data)
    { 
        if(data.Length == 0)
        {
            int currVert = 0;
            int currTri = 0;
            _triangles = new int[_sizeInXAxis * _sizeInZAxis * 6];

            for(int k = 0; k < _sizeInZAxis; k++)
            {
                for(int i = 0 ; i < _sizeInXAxis; i++)
                {
                
                    _triangles[currTri + 0] = currVert+ 0;
                    _triangles[currTri + 1] = currVert + _sizeInXAxis + 1;
                    _triangles[currTri + 2] = currVert + 1;
                    _triangles[currTri + 3] = currVert + 1;
                    _triangles[currTri + 4] = currVert + _sizeInXAxis + 1;
                    _triangles[currTri + 5] = currVert + _sizeInXAxis + 2;

                    currVert++;
                    currTri += 6;
                }
                currVert++;
            }
        }

        else 
        {
            int currVert = 0;
            int currTri = 0;
            _triangles = new int[data.Length * 6];

            for(int i = 0; i < data.Length - 3; i++)
            {
                if(data[i][4] == "")
                    break;
            
                _triangles[currTri + 0] = int.Parse(data[i][4]);
                _triangles[currTri + 1] = int.Parse(data[i][5]);
                _triangles[currTri + 2] = int.Parse(data[i][6]);
                _triangles[currTri + 3] = int.Parse(data[i + 3][4]);
                _triangles[currTri + 4] = int.Parse(data[i + 3][5]);
                _triangles[currTri + 5] = int.Parse(data[i + 3][6]);

                currVert++;
                currTri += 6;
                
            }  
        }
        

       
    }

   
}
