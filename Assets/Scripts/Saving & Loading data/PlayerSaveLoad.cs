using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class PlayerSaveLoad {

    public static string filebin = "/playerdata.bin";

    public static void savePlayerData(Player player)
    {
        try
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter(); //Construct a BinaryFormatter and use it to serialize the data to the stream.
            string path = Application.persistentDataPath + filebin; //Bin file path which can be in any installer path in any OS

            FileStream stream = new FileStream(path, FileMode.Create); //Filestream mode in Create
            PlayerModel playerModel = new PlayerModel(player); //instance of playermodel
            binaryFormatter.Serialize(stream, playerModel); //saving file or serialize file

            Debug.Log(path);

            stream.Close(); //close the stream
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
        }
    }

    public static PlayerModel loadPlayerData()
    {
        try
        {
            string path = Application.persistentDataPath + filebin; //Bin file path which can be in any installer path in any OS
            Debug.Log(path);
            if (File.Exists(path))
            { //checking if file exists or not
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open); //Reading the file
                PlayerModel playerModel = binaryFormatter.Deserialize(stream) as PlayerModel; //Deserilize and convert the data to PlayerModel
                stream.Close();
                return playerModel;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.ToString());
            return null;
        }
    }




}
