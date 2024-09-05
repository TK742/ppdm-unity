using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ISaveLoad : MonoBehaviour
{
    public SaveData saveData;

    private void Start()
    {
        path = Path.Combine(Application.persistentDataPath + "saveData.json");
    }

    #region PlayerPrefs

    [Header("PlayerPrefs")] [SerializeField]
    private Vector3 playerPrefs; // Imaginemos que esto es la posición del jugador.
    
    /* PlayerPrefs nos permite guardar datos sencillos (String, Int, Float) sin mucho esfuerzo. */
    /* Se guardan en archivos locales de la computadora. */
    /* Suelen ser fácil de encontrar y modificar. */
    /* No se aplica ningún método de encriptado. */
    
    public void PlayerPrefs_Load(string key)
    {
        if (!PlayerPrefs.HasKey(key)) // Si nuestras PlayerPrefs *NO* tienen la key solicitada, hace return;
            return;

        playerPrefs = new Vector3(
            PlayerPrefs.GetFloat("x"), // Cargamos el primer valor, un float X.
            PlayerPrefs.GetFloat("y"), // Eje Y.
            PlayerPrefs.GetFloat("z") // Y ahora el Z.
        );
        
        Debug.Log($"Valor cargado: {playerPrefs}");
        // No podemos guardar Vector3, pero podemos cargar valores individuales.
    }

    public void PlayerPrefs_Save()
    {
        playerPrefs = transform.position; // Hacemos nuestro Vector3 y asignamos la posición del cubo.
        
        PlayerPrefs.SetFloat("x", playerPrefs.x); // Guardamos el valor X.
        PlayerPrefs.SetFloat("y", playerPrefs.y); // Eje Y.
        PlayerPrefs.SetFloat("z", playerPrefs.z); // Y ahora el Z.

        Debug.Log($"Valor guardado: {playerPrefs}");
        // No podemos guardar Vector3, pero podemos guardar valores individuales.
    }

    #endregion

    #region File System

    /* using System.IO */
    /* Podemos guardar archivos de texto y darle cualquier formato. */
    /* No se aplica ningún método de encriptado base, pero se puede hacer manualmente. */
    /* Suelen ser fácil de encontrar y modificar.  */

    private string path;
    
    public void IO_Load()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Debug.Log("Game Loaded");
            return data;
        }
        else
        {
            Debug.LogWarning("No save file found");
            return null;
        }
    }
    
    public void IO_Save()
    {
        SaveData data = new SaveData(playerPosition);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved");
    }

    #endregion

    #region JSON
    
    /* JSONUtility */
    /* Esto es nada más el formato que le damos a los datos guardados. */
    /* Debemos recurir a guardar PlayerPrefs o un archivo si queremos lograr la persistencia. */

    public SaveData JSONUtility_Load(string json)
    {
        
    }

    public string JSONUtility_Save()
    {
        
    }

    #endregion

    #region Classes

    [System.Serializable] // Tenemos que hacer la clase nueva PÚBLICA y SERIALIZABLE, sino no guarda nada, en ningún caso.
    public class SaveData
    {
        // Acá podemos guardar básicament cualquier tipo de variable. O al menos en su gran mayoría.
        public Vector3 savedPosition;
    }

    #endregion
}