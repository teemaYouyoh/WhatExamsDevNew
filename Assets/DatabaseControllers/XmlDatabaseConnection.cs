using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class XmlDatabaseConnection
{
    public static XmlElement load(string path) {
        XmlDocument xDoc = new XmlDocument();  
        
        try {
            xDoc.Load(Application.dataPath+"/Resources/" + path + ".xml");

        } catch (Exception error) {      //  Функція XmlDocument.Load, при відсутності можливості завантажити файл також сама генерую віключну ситуацію, яку ми просто перехоплюємо
            Debug.Log(error.Message);
        }

        return xDoc.DocumentElement;
    }
}