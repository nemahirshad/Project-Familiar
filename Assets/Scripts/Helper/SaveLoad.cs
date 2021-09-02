using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoad
{
    public static void Save(UpgradeObject upgrade, Bond bond, string sceneName)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Player.Woohoo";

        FileStream stream = new FileStream(path, FileMode.Create);
        
        SaveSlot data = new SaveSlot(upgrade, bond, sceneName);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SaveSlot Load()
    {
        string path = Application.persistentDataPath + "/Player.Woohoo";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SaveSlot data = formatter.Deserialize(stream) as SaveSlot;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save File not found in" + path);
            return null;
        }
    }
}
