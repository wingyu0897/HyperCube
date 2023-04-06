using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIComponent : MonoBehaviour
{
    public GameState state;

    public abstract void UpdateUI();
}
