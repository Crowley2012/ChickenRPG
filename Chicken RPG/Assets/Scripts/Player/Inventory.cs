using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public Text Money;

    private int _currentMoney;

	void Start ()
    {
        _currentMoney = 2000;
	}
	
	void Update ()
    {
		
	}

    private void FixedUpdate()
    {
        Money.text = string.Format("${0}", _currentMoney);
    }
}
