using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character1 : MonoBehaviour
{
    public int age;
    public float health =100;
    public float damage;
    public double physicsFall;
    [SerializeField] private string characterName;
    public bool raytracing;
    public Vector2 xz;
    public Vector3 myPosition;
    [SerializeField] public float armor;


    public ScaleMode scale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
