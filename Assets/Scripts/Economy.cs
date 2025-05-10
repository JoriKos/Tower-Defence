using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Economy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private int _startingMoney;
    private int _money;

    private Dictionary<string, int> _towerCost = new Dictionary<string, int>() {
        {"Tower1", 5},   //TOWER 1
        {"Tower2", 7 },  //TOWER 2
        {"Tower3", 8 },  //TOWER 3
        {"Tower4", 10 }  //TOWER 4
    };

    public Dictionary<string, int> TowerCost { get { return _towerCost; } }


    private void Awake()
    {
        if (_startingMoney != 0)
        {
            _money = _startingMoney;
            _coinText.text = "Coins: " + _money;
        }
    }

    public void AddMoney(int moneyToAdd)
    {
        _money += moneyToAdd;
        _coinText.text = "Coins: " + _money;
    }
    
    public int GetMoney() { return _money; }
}
