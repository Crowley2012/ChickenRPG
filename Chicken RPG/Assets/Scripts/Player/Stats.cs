using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    public Text Health;

    private int _currentHealth;

    void Start ()
    {
        _currentHealth = 90;
    }
	
	void Update () {
		
	}

    void FixedUpdate()
    {
        Health.text = string.Format("{0}%", _currentHealth);
    }
}
