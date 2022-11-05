using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IScoreItem
{
    void AddScoreValue(bool isIncrementer, int scoreValue);
}
