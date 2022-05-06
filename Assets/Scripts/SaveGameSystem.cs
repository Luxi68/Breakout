using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveGameSystem
{
    public static bool SaveData(SaveData saveGame, string name)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(GetSavePath(name), FileMode.Create))
        {
            try
            {
                formatter.Serialize(stream, saveGame);
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        return true;
    }

    public static SaveData LoadData(string name)
    {
        if (!DoesSaveDataExist(name))
        {
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();

        using (FileStream stream = new FileStream(GetSavePath(name), FileMode.Open))
        {
            try
            {
                SaveData myData = formatter.Deserialize(stream) as SaveData;
                return myData;
            }
            catch (System.Exception)
            {
                return null;
            }
        }
    }

    public static bool DeleteSaveData(string name)
    {
        try
        {
            File.Delete(GetSavePath(name));
        }
        catch (System.Exception)
        {
            return false;
        }

        return true;
    }

    public static bool DoesSaveDataExist(string name)
    {
        return File.Exists(GetSavePath(name));
    }

    public static string GetSavePath(string name)
    {
        return Path.Combine(Application.persistentDataPath, name + ".sav");
    }

}

