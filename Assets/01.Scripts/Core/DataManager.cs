using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static string ObjectToJson(object obj)
    {
        return JsonUtility.ToJson(obj, true);
    }
    public static T JsonToObject<T>(string jsonData)
    {
        return JsonUtility.FromJson<T>(jsonData);
    }
    public static void SaveJsonFile(string createPath, string fileName, string jsonData)
    {
        if (!Directory.Exists(createPath))
        {
            Directory.CreateDirectory(createPath);
        }
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", createPath, fileName), FileMode.Create);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);
        fileStream.Write(data, 0, data.Length); fileStream.Close();
    }
    public static T LoadJsonFile<T>(string loadPath, string fileName) where T : new()
    {
        if (!Directory.Exists(loadPath))
        {
            Directory.CreateDirectory(loadPath);
        }
        if (!File.Exists(string.Format("{0}/{1}.json", loadPath, fileName)))
        {
            SaveJsonFile(loadPath, fileName, ObjectToJson(new T()));
        }
        FileStream fileStream = new FileStream(string.Format("{0}/{1}.json", loadPath, fileName), FileMode.Open);
        byte[] data = new byte[fileStream.Length]; fileStream.Read(data, 0, data.Length);
        fileStream.Close();
        string jsonData = Encoding.UTF8.GetString(data);
        return JsonToObject<T>(jsonData);
    }
}