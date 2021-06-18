using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonDatabaseConnection
{
    public static string load(string path) {
        TextAsset loadedJsonfile = new TextAsset();
        string data = "";

        try {
            string jsonFilePath = path.Replace(".json", "");
            loadedJsonfile = Resources.Load<TextAsset>(jsonFilePath);
            
            if ( loadedJsonfile == null || !loadedJsonfile ) {    // Якщо файл не було заванажено, генеруємо виключну ситуацію
                throw new Exception("Файл не знайдений");
            } else {
                data = loadedJsonfile.text;
            }

        } catch (Exception error) {
            data = "";
            
        }

        return data;
    }

    public static void save(string file, string data) {
        try {
            string path = Application.dataPath+"/Resources/" + file + ".json";
            File.WriteAllText(path, data);

        } catch (Exception error) {   // Функція File.WriteAllText, при відсутності можливості відкрити файл сама генерую віключну ситуацію, яку ми просто перехоплюємо
            Debug.Log(error.Message);
        }
    }

    public static void clean(string file) {
        try {
            string path = Application.dataPath+"/Resources/" + file + ".json";
            File.WriteAllText(path, "");
        } catch (Exception error) { // Теж саме, що і в попередній функції
            Debug.Log(error.Message);
        }
    }
}
