using UnityEngine;

public class MiScriptableObject : ScriptableObject {
    public string nombre;
    public int nivel;
    
    public void Saludar() {
        Debug.Log("Hola, soy " + nombre + " y estoy en el nivel " + nivel);
    }
}