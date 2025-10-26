using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public MyHashTable<string, object> myHashTable;
    public string nombre;
    public int debugQuantity;

    void Start()
    {
        Debug.Log("GameManager iniciado. Usa los botones para probar la tabla hash.");
    }

    [Button]
    public void ShowHashCode()
    {
        Debug.Log("Hash code : " + (nombre.GetHashCode() & 0x7FFFFFFF));
    }

    [Button]
    public void ShowHashCodeClamped()
    {
        Debug.Log("Hash code : " + (nombre.GetHashCode() % debugQuantity));
    }

    [Button("1. Claves enteras → nombres")]
    public void Test_Enteros_Nombres()
    {
        MyHashTable<int, string> tabla = new MyHashTable<int, string>(5);

        tabla.Add(1, "Espada");
        tabla.Add(2, "Escudo");
        tabla.Add(3, "Pocion");
        tabla.Add(4, "Llave");

        tabla.Get(2);
        tabla.Get(5);

        Debug.Log("Fin de la prueba 1");
    }

    [Button("2. Claves string → objetos")]
    public void Test_String_Objetos()
    {
        myHashTable = new MyHashTable<string, object>(5);

        myHashTable.Add("Jugador", new GameObject("Jugador"));
        myHashTable.Add("Enemigo", new GameObject("Enemigo"));
        myHashTable.Add("NPC", new GameObject("NPC"));

        myHashTable.Get("Jugador");
        myHashTable.Get("Jefe");

        Debug.Log("Fin de la prueba 2");
    }

    [Button("3. Forzar colisiones")]
    public void Test_Colisiones()
    {
        MyHashTable<string, string> tabla = new MyHashTable<string, string>(3);

        tabla.Add("A", "Espada");
        tabla.Add("D", "Escudo");
        tabla.Add("G", "Pocion");
        tabla.Add("J", "Llave");

        tabla.Get("D");
        tabla.Get("G");

        Debug.Log("Fin de la prueba 3");
    }

    [Button("4. Diferentes tamaños (rehash)")]
    public void Test_Tamanos()
    {
        MyHashTable<int, string> tabla = new MyHashTable<int, string>(2);

        for (int i = 0; i < 10; i++)
        {
            tabla.Add(i, "Item" + i);
        }

        Debug.Log("Fin de la prueba 4");
    }

    [Button("5. Eliminar elementos")]
    public void Test_Eliminar()
    {
        MyHashTable<string, string> tabla = new MyHashTable<string, string>(5);

        tabla.Add("A", "Espada");
        tabla.Add("B", "Escudo");
        tabla.Add("C", "Pocion");

        tabla.Remove("B");
        Debug.Log("Contiene 'A'? " + tabla.ContainsKey("A"));
        tabla.Get("A");

        Debug.Log("Fin de la prueba 5");
    }

    [Button("6. Comparar con Dictionary")]
    public void Test_Comparar()
    {
        MyHashTable<int, string> miTabla = new MyHashTable<int, string>(5);
        Dictionary<int, string> dict = new Dictionary<int, string>();

        for (int i = 0; i < 5; i++)
        {
            miTabla.Add(i, "MyHash_Item" + i);
            dict.Add(i, "Dict_Item" + i);
        }

        miTabla.Get(3);
        Debug.Log("Dictionary: " + dict[3]);

        Debug.Log("Fin de la prueba 6");
    }
}
