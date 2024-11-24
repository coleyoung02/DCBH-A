using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Slider slider;

    private Camera camera;
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = camera.transform.rotation;
        transform.position = target.position + offset;
    }

    public void UpdateHealthBar(float current, float max)
    {
        slider.value = current / max;
    }
}
