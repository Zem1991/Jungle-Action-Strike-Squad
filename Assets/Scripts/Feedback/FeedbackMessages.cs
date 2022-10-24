using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackMessages : AbstractSingleton<FeedbackMessages>
{
    [Header("Command Cost")]
    [SerializeField] public readonly string notEnoughActionPoints = "Not enough Action Points";
}
