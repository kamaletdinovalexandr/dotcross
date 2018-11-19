using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GameController : Singleton<GameController> {
    private enum GameState { started, noMoves, win }

    [SerializeField] private BoardCellModel[,] BoardCellModels;
    private Player _curentPlayer;
    private Player Player1;
    private VirtualPlayer Player2;
    private GameState _gameState;
    
    internal override void Init() {
        Player1 = new Player(Players.player1, ElementTypes.cross);
        Player2 = new VirtualPlayer(Players.player2, ElementTypes.dot);
        _curentPlayer = Player1;
		_gameState = GameState.started;

        BoardCellModels = new BoardCellModel[BoardManager.Instance.BoardWidth, BoardManager.Instance.BoardHeigh];
        for (int i = 0; i < BoardManager.Instance.BoardWidth; i++) {
            for (int j = 0; j < BoardManager.Instance.BoardHeigh; j++) {
                var cellModel = new BoardCellModel(ElementTypes.none);
                cellModel.ElementType = ElementTypes.none;
                BoardCellModels[i, j] = cellModel;
            }
        }
        NotifyTurn();
    }

    private void Update() {
		if (_gameState == GameState.started)
			return;

       if (_gameState == GameState.win)
            Debug.Log("Player " + _curentPlayer.PlayerType.ToString() + " Win!!!");

		if (_gameState == GameState.noMoves)
			Debug.Log("No moves left");

		EditorApplication.isPlaying = false;
    }

    private void ChangePlayer() {
        _curentPlayer = _curentPlayer == Player1 ? Player2 : Player1;
		NotifyTurn();
		if (_curentPlayer == Player2)
			Player2.MakeMove();
    }

    private void NotifyTurn() {
        Debug.Log(_curentPlayer.PlayerType.ToString() + " turn");
    }

    public void  TryMakeMove(BoardCellView cell) {
        if (BoardCellModels[cell.Position.x, cell.Position.y].ElementType != ElementTypes.none)
            return;

        BoardCellModels[cell.Position.x, cell.Position.y].ElementType = _curentPlayer.Element;
        cell.SetElement(_curentPlayer.Element);
		if (!CheckMovesAvailable()) {
			_gameState = GameState.noMoves;
		} 
		else if (CheckWin()) 
            _gameState = GameState.win;
        else
            ChangePlayer();
		return;
    }

	public bool IsCellAvailable(int x, int y) {
		return BoardCellModels[x, y].ElementType == ElementTypes.none;
	}

	private bool CheckMovesAvailable() {
		for (int i = 0; i < BoardManager.Instance.BoardWidth; i++) {
			for (int j = 0; j < BoardManager.Instance.BoardHeigh; j++) {
				if (BoardCellModels[i, j].ElementType == ElementTypes.none)
					return true;
			}
		}
		return false;
	}

    private bool CheckWin() {
		return _curentPlayer.Element == BoardCellModels[0, 0].ElementType
			&& _curentPlayer.Element == BoardCellModels[1, 1].ElementType
			&& _curentPlayer.Element == BoardCellModels[2, 2].ElementType

			|| _curentPlayer.Element == BoardCellModels[2, 0].ElementType
			&& _curentPlayer.Element == BoardCellModels[1, 1].ElementType
			&& _curentPlayer.Element == BoardCellModels[0, 2].ElementType

			|| _curentPlayer.Element == BoardCellModels[0, 0].ElementType
            && _curentPlayer.Element == BoardCellModels[0, 1].ElementType
            && _curentPlayer.Element == BoardCellModels[0, 2].ElementType
            || _curentPlayer.Element == BoardCellModels[1, 0].ElementType
            && _curentPlayer.Element == BoardCellModels[1, 1].ElementType
            && _curentPlayer.Element == BoardCellModels[1, 2].ElementType
            || _curentPlayer.Element == BoardCellModels[2, 0].ElementType
            && _curentPlayer.Element == BoardCellModels[2, 1].ElementType
            && _curentPlayer.Element == BoardCellModels[2, 2].ElementType

            || _curentPlayer.Element == BoardCellModels[0, 0].ElementType
            && _curentPlayer.Element == BoardCellModels[1, 0].ElementType
            && _curentPlayer.Element == BoardCellModels[2, 0].ElementType
            || _curentPlayer.Element == BoardCellModels[0, 1].ElementType
            && _curentPlayer.Element == BoardCellModels[1, 1].ElementType
            && _curentPlayer.Element == BoardCellModels[2, 1].ElementType
            || _curentPlayer.Element == BoardCellModels[0, 2].ElementType
            && _curentPlayer.Element == BoardCellModels[1, 2].ElementType
            && _curentPlayer.Element == BoardCellModels[2, 2].ElementType;
    }
}
