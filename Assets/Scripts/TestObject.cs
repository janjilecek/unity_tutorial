using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class TestObject : MonoBehaviour
{
    [Range(0, 100)] public int numberOfEnemies;

    [Header("Observer pattern variables")] public GameObject objCar1;
    public GameObject objCar2;
    public GameObject objCar3;

    [Header("State pattern variables")] public GameObject enemy1;
    public GameObject enemy2;
    public GameObject player;

    [Header("Text data")] [ModularText("health_potion_hover")]
    public TextMesh healthPotionHoverText;

    [ModularText("main_menu_resume")] public TextMesh mainMenuResumeText;
    

public void applyTranslations(object inputObject) {
        FieldInfo[] fieldInfo = typeof(TestObject).GetFields();
        foreach (FieldInfo field in fieldInfo) {
            Attribute modText = System.Attribute.GetCustomAttribute(field, typeof(ModularText));
            if (modText == null) continue;
            TextMesh item = field.GetValue(inputObject) as TextMesh;
            //if (item != null) item.text = GetTranslationFromExcelFile(((ModularText) modText).textKey);
        }
    }
}




[System.AttributeUsage(System.AttributeTargets.Field)]
public class ModularText : System.Attribute
{
    public string textKey;

    public ModularText(string key)
    {
        textKey = key;
    }
}
