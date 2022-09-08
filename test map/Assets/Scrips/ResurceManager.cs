using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResurceManager 
{
    public static int _paper { get; private set; }
    private static int _maxPaper=1000;
    private static int _cutPaper { get;}
    public static int _population { get; private set; }
    private static int _MaxPopulation { get; }
    private static int _coins { get; }
    public static int _exp { get; private set; }
    public static int _maxExp { get; private set; }
    public static int _level { get; private set; }

    public static void AddPaper(int amount)
    {

        _paper = _paper + amount > _maxPaper ? _maxPaper : _paper + amount;
        Debug.Log(_paper+ " amount");

    }
    public static void AddPopulation(int amount)
    {
        _population = _population + amount > _MaxPopulation ? _MaxPopulation : _population + amount;
    }
    public static void AddExp(int amount)
    {
        if (amount + _exp > _maxExp)
        {
            _level++;
            _exp = amount + _exp - _maxExp;
            _maxExp *= 2;  
        }
        _exp += amount;
    }

}
