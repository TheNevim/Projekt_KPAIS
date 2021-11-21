using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlotColor{Default, Green, Red}

public class FigureSlot : MonoBehaviour
{
    private MeshRenderer _mashRenderer;
    
    [SerializeField] private Color _transparent;
    [SerializeField] private Color _green;
    [SerializeField] private Color _red;
    [SerializeField] private Figure figureInSlot;

    private SlotColor _slotColor = SlotColor.Default;

    public Figure FigureInSlot
    {
        get => figureInSlot;
         set => figureInSlot = value;
    }
    
    public SlotColor SlotColor
    {
        get => _slotColor;
        private set{}
    }
    
    // Start is called before the first frame update
    void Start()
    {
        _mashRenderer = gameObject.GetComponent<MeshRenderer>();
        _mashRenderer.material.color = _transparent;
    }
    

    public bool IsSlotGreen()
    {
        if (SlotColor == SlotColor.Green)
        {
            return true;
        }
        return false;
    }
    
    public bool IsSlotRed()
    {
        if (SlotColor == SlotColor.Red)
        {
            return true;
        }
        return false;
    }

    public void SetFigureInSlot(Figure figure)
    {
        figureInSlot = figure;
    }
    
    public void DeSetFigureInSlot()
    {
        figureInSlot = null;
    }
    
    
    public void SetColor(SlotColor colorSet)
    {
        _slotColor = colorSet;
        
        if (!IUManager.Instance.ShowPlayerMoves(PlayerManager.Instance.PlayerTurn))
        {
            return;
        }

        switch (colorSet)
        {
            case SlotColor.Default:
                _mashRenderer.material.color = _transparent;
                break;
            case SlotColor.Red:
                _mashRenderer.material.color = _red;
                break;
            case SlotColor.Green:
                _mashRenderer.material.color = new Color(_green.r,_green.g,_green.b,_green.a);
                //_mashRenderer.material.color = _green;
                break;
        }
        
    }

    
}
