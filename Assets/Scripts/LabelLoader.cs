using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LabelLoader : MonoBehaviour
{  
    internal static List<string> GetLabelData()
    {
        TextAsset dataSet = Resources.Load ("PartNames") as TextAsset;
        return dataSet.text.Split(',').ToList();
    }
}
