using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Item interface for score adding or deducting 
/// </summary>

interface IScoreItem
{
    void AddScoreValue(bool isIncrementer, int scoreValue);
}
