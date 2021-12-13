using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSVReader : MonoBehaviour
{
  
    // void Start()
    // {
    //    string filePath = @"I:\Game projects\Unity Game Folder\Brain station 23 assessment\Assets\DataSet\Data1.csv";

    //    string[][] data = File.ReadLines(filePath).Select(x => x.Split(',').ToArray()).ToArray();
       
       
    //    for(int i = 1 ; i < data.Length; i++)
    //     {
    //         if(data[i][4] == "")
    //           break;

    //         Debug.Log(int.Parse(data[i][4]));
    //         Debug.Log(int.Parse(data[i][5]));
    //         Debug.Log(int.Parse(data[i][6]));
    //     }
       

    // }


    public string[][] GetData(string filePath) => File.ReadLines(filePath).Select(x => x.Split(',').ToArray()).ToArray();


    
}
