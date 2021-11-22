using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Vector3 blackCameraView = new Vector3(3.5f, 15, -5f);
    private Vector3 whiteCameraView = new Vector3(3.5f, 15, 12f);

    private Vector2Int whiteKingPosition = new Vector2Int(3,7);
    private Vector2Int blackKingPosition = new Vector2Int(3,0);

    private Camera _camera;
    
    [SerializeField] private List<Figure> _blackFigures = new List<Figure>();
    [SerializeField] private List<Figure> _whiteFigures = new List<Figure>(); 
    
    private FigureColor playerTurn = FigureColor.White;

    private int possibleMoves = 0;
    
    #region Singleton
    public static PlayerManager Instance;
    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }

        Instance = this;
    }

    #endregion

    public Vector2Int WhiteKingPosition
    {
        get => whiteKingPosition;
        private set => whiteKingPosition = value;
    }
    
    public Vector2Int BlackKingPosition
    {
        get => blackKingPosition;
        private set => blackKingPosition = value;
    }

    public List<Figure> WhiteFigures
    {
        get => _whiteFigures;
        private set => _whiteFigures = value;
    }
    
    public List<Figure> BlackFigures
    {
        get => _blackFigures;
        private set => _blackFigures = value;
    }

    
    public FigureColor PlayerTurn
    {
        get => playerTurn;
        private set{}
    }

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        _camera.transform.position = whiteCameraView;
    }
    
    public void SwapTurn()
    {
        if (playerTurn == FigureColor.White)
        {
            playerTurn = FigureColor.Black;
            ChangeCameraView(blackCameraView);
            IUManager.Instance.ChangePlayerUI(FigureColor.Black);
        }
        else
        {
            playerTurn = FigureColor.White;
            ChangeCameraView(whiteCameraView);
            IUManager.Instance.ChangePlayerUI(FigureColor.White);
        }
    }

    public void SetKingNewPosition(int xPos, int zPos, FigureColor color)
    {
        if (color == FigureColor.White)
        {
            whiteKingPosition.x = xPos;
            whiteKingPosition.y = zPos;
        }
        else
        {
            blackKingPosition.x = xPos;
            blackKingPosition.y = zPos;
        }
    }

    public bool CheckForCheckMate()
    {
        if (playerTurn == FigureColor.White)
        {
            playerTurn = FigureColor.Black;
            possibleMoves = BoardManager.Instance.Board[blackKingPosition.y][blackKingPosition.x].FigureInSlot.NumberOfPossibleMoves();
            BoardManager.Instance.Board[blackKingPosition.y][blackKingPosition.x].FigureInSlot.ClearMoves();
            if (possibleMoves == 0)
            {
                foreach (Figure figure in BlackFigures)
                {
                    possibleMoves += figure.NumberOfPossibleMoves();
                    figure.ClearMoves();
                }
            }
            playerTurn = FigureColor.White;
            if (possibleMoves == 0)
            {
                return true;
            }

            possibleMoves = 0;
        }
        else
        {
            playerTurn = FigureColor.White;
            possibleMoves = BoardManager.Instance.Board[whiteKingPosition.y][whiteKingPosition.x].FigureInSlot.NumberOfPossibleMoves();
            BoardManager.Instance.Board[blackKingPosition.y][blackKingPosition.x].FigureInSlot.ClearMoves();
            if (possibleMoves == 0)
            {
                foreach (Figure figure in WhiteFigures)
                {
                    possibleMoves += figure.NumberOfPossibleMoves();
                    figure.ClearMoves();
                }
            }
            playerTurn = FigureColor.Black;
            if (possibleMoves == 0)
            {
                return true;
            }
            
            possibleMoves = 0;
        }

        return false;
    }

    void ChangeCameraView(Vector3 position)
    {
        _camera.transform.position = position;
        Vector3 rot = _camera.transform.rotation.eulerAngles;
        rot = new Vector3(rot.x,rot.y+180,rot.z);
        _camera.transform.rotation = Quaternion.Euler(rot);
    }

    public void RemoveMyFigure(Figure figure)
    {
        if (playerTurn == FigureColor.White)
        {
            _whiteFigures.Remove(figure);
        }
        else
        {
            _blackFigures.Remove(figure);
        }
    }
    
    public void RemoveEnemyFigure(Figure figure)
    {
        if (playerTurn == FigureColor.White)
        {
            _blackFigures.Remove(figure);
        }
        else
        {
            _whiteFigures.Remove(figure);
        }
    }
    
    public void AddFigure(Figure figure)
    {
        if (playerTurn == FigureColor.White)
        {
            _whiteFigures.Add(figure);
        }
        else
        {
            _blackFigures.Add(figure);
        }
    }
    
    
}
