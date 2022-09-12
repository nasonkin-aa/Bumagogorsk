using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ResurceManager 
{
    public static int _paper { get; set; } = 5;
    public static int _maxPaper { get; private set; } = 100;
    public static int _cutPaper { get; set; } = 5;
    public static int _population { get; private set; } 
    public static int _MaxPopulation { get; private set; } = 15;
    public static int _coins { get; private set; } 
    public static int _exp { get; private set; }
    public static int _maxExp { get; private set; } = 10;
    public static int _level { get; private set; }

    public static void AddPaper(int amount)
    {
        _paper = _paper + amount > _maxPaper ? _maxPaper : _paper + amount;
    }
    public static bool CheckPaper(int amount)
    {
        return amount <= _paper;
    }
    public static void ReducePaper(int amount)
    {
        _paper -= amount;
    }

    public static void AddCutPaper(int amount)
    {
        _cutPaper += amount;
    }
    public static bool CheckCutPaper(int amount)
    {
        Debug.Log("Amount: " + amount + " cP: " + _cutPaper);
        return amount <= _cutPaper;
    }
    public static void ReduceCutPaper(int amount)
    {
        Debug.Log("Amount: " + amount + " cP: " + _cutPaper + " reduce");
        _cutPaper -= amount;
    }

    public static void AddCoins(int amount)
    {
        _coins += amount;
    }
    public static bool CheckCoins(int amount)
    {
        return amount <= _coins;
    }
    public static void ReduceCoins(int amount)
    {
        _coins -= amount;
    }


    public static void AddPopulation(int amount)
    {
        _population = _population + amount > _MaxPopulation ? _MaxPopulation : _population + amount;
    }
    public static bool CheckPopulation(int amount)
    {
        return amount <= _population;
    }
    public static void ReducePopulation(int amount)
    {
        _population -= amount;
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
