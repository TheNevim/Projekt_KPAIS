using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Camera _camera;
    private Figure focusedFigure;
    private bool isFigureFocused = false;
    private bool gameIsAlive = true;

    public Figure FocusedFigure => focusedFigure;

    #region Singleton

    public static GameManager Instance;
    
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        IUManager.Instance.ChangePlayerUI(FigureColor.White);
        BoardManager.Instance.swapTurns += SwapTurn;
    }

     void SwapTurn()
    {
        isFigureFocused = false;
        focusedFigure = null;
        
        
        if (PlayerManager.Instance.CheckForCheckMate())
        {
            gameIsAlive = false;
            IUManager.Instance.ShowWinnerPanel();
            return;
        }
        
        PlayerManager.Instance.SwapTurn();
        
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gameIsAlive)
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out var hit, 50000,(1 << 8 | 1 << 9)) && !isFigureFocused)
            {
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Figure")) {
                    Figure figure = hit.transform.GetComponent<Figure>();

                    if (figure.FigureColor != PlayerManager.Instance.PlayerTurn)
                    {
                        return;   
                    }
                    
                    if (focusedFigure == null)
                    {
                        focusedFigure = figure;
                        focusedFigure.ShowMove();
                        return;
                    }

                    if (focusedFigure != figure)
                    {
                        focusedFigure.HideMove();
                        focusedFigure = figure;
                        focusedFigure.ShowMove();
                    }
                    return;
                }
                
                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Slot")) {
                    int x = (int) Math.Round(hit.transform.position.x);
                    int z = (int) Math.Round(hit.transform.position.z);
                    BoardManager.Instance.PlaceFigure(focusedFigure, x, z);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            if (focusedFigure != null)
            {
                focusedFigure.HideMove();
                focusedFigure = null;
            }
            isFigureFocused = false;
        }
    }
    
}
