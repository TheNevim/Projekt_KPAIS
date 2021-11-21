using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{

    [SerializeField] private FigureType promoteFigure;
    
    public FigureType PromoteFigure
    {
        get => promoteFigure;
    }

    public void SetPromoteFigure()
    {
        GameManager.Instance.FocusedFigure.promteToFigure = promoteFigure;
        IUManager.Instance.DeactivatePromotionPanel();
    }
}
