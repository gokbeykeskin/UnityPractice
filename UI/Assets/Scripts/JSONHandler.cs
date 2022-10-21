using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;
public static class JSONHandler
{
    public static void SaveToJSON<T,V>(Dictionary<T,V> toSave, string fileName){
        
        List<T> keys = new List<T>();
        List<V> values = new List<V>();
        foreach(KeyValuePair<T,V> pair in toSave){
            keys.Add(pair.Key);
            values.Add(pair.Value);
        } 
        string content = JsonHelper.ToJson<T>(keys.ToArray());
        WriteFile(GetPath(fileName+"Keys.json"),content);
        content = JsonHelper.ToJson<V>(values.ToArray());
        WriteFile(GetPath(fileName+"Values.json"),content);
    }

    public static Dictionary<T,V> ReadFromJSON<T,V>(string fileName){
        string[] content = ReadFile(GetPath(fileName+"Keys.json"),GetPath(fileName+"Values.json"));
        if(string.IsNullOrEmpty(content[0]) || string.IsNullOrEmpty(content[1])){
            return new Dictionary<T, V>();
        }
        Debug.Log(content[0]+"|"+content[1]);
        List<T> keys = JsonHelper.FromJson<T>(content[0]).ToList();
        List<V> values = JsonHelper.FromJson<V>(content[1]).ToList();
        Dictionary<T,V> result = new Dictionary<T, V>();
        for(int i=0;i<keys.Count;i++){
            result.Add(keys[i],values[i]);
        }
        return result;
    }

    private static string GetPath(string fileName){
        Debug.Log(Application.streamingAssetsPath + "/" + fileName);
        return Application.streamingAssetsPath + "/" + fileName;
    }

    private static void WriteFile(string path,string content){
        FileStream fileStream = new FileStream(path, FileMode.Create);
        using (StreamWriter writer = new StreamWriter(fileStream)){
            writer.Write(content);
        }
    }

    private static string[] ReadFile(string path1,string path2){
        string[] strings = new string[2];
        if(File.Exists(path1)){
            using (StreamReader reader = new StreamReader(path1)){
                strings[0]=reader.ReadToEnd();
            }
        }

        if(File.Exists(path2)){
            using (StreamReader reader = new StreamReader(path2)){
                strings[1]=reader.ReadToEnd();
            }
        }
        return strings;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}
