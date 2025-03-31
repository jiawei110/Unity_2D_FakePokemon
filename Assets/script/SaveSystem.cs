using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(Unit player, ItemUnit item) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player, item);

        formatter.Serialize(stream, data);
        stream.Close();

      
    }
    public static void SaveEnemy(EnemyData enemy) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path2 = Application.persistentDataPath + "/enemy.fun";
        FileStream stream = new FileStream(path2, FileMode.Create);

        EnemyData data2 = new EnemyData(enemy);
        formatter.Serialize(stream, data2);
        stream.Close();
    }

    public static PlayerData LoadPlayer() 
    {
        string path = Application.persistentDataPath + "/player.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }
        else 
        {
            Debug.LogError("Save file is not found in" + path);
            return null;
        }
    }
    public static EnemyData LoadEnemy()
    {
        string path = Application.persistentDataPath + "/enemy.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter1 = new BinaryFormatter();
            FileStream stream1 = new FileStream(path, FileMode.Open);

            EnemyData data1 = formatter1.Deserialize(stream1) as EnemyData;
            stream1.Close();

            return data1;
        }
        else
        {
            Debug.LogError("Save file is not found in" + path);
            return null;
        }
    }
}
