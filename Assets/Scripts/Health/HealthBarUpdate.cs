using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class HealthBarUpdate : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private UnityEngine.UI.Image totalHealthBar;
    [SerializeField] private UnityEngine.UI.Image currentHealthBar;
    // Start is called before the first frame update
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
