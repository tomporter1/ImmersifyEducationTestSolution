using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class LabelLoader
{
    /// <summary>
    /// Loads the possible label names from the csv file in Resources
    /// </summary>
    /// <returns>The contence of the CSV file split into a list</returns>
    internal static List<string> GetLabelData()
    {
        TextAsset dataSet = Resources.Load ("PartNames") as TextAsset;
        return dataSet.text.Split(',').ToList();
    }
}