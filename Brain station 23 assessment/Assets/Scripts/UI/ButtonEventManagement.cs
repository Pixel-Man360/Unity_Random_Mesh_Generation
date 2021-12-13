using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonEventManagement : MonoBehaviour
{
    [SerializeField] private Button _randomMeshButton;
    [SerializeField] private Button _data1Button;
    [SerializeField] private MeshGenerator _meshGenerator;
    [SerializeField] private CSVReader _csvData;
    void Start()
    {
        _randomMeshButton?.onClick.AddListener(GenerateRandomMesh);
        _data1Button?.onClick.AddListener(GenerateMeshFromData);
    }

    void GenerateRandomMesh()
    {
        string[][] emp = new string[][]{};
       _meshGenerator.CreateNewMesh(emp);
    }

    void GenerateMeshFromData()
    {
        string[][] data = _csvData.GetData(@"I:\Game projects\Unity Game Folder\Brain station 23 assessment\Assets\DataSet\Data1.csv");
        _meshGenerator.CreateNewMesh(data);
    }

 
    
}
