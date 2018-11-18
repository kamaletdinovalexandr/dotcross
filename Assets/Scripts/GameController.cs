using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController> {
    [SerializeField] private BoardCellModel[,] BoardCellModels;
    private Player _curentPlayer;
    private Player Player1;
    private Player Player2;
    
    internal override void Init() {
        Player1 = new Player(Players.player1, ElementTypes.cross);
        Player2 = new Player(Players.player2, ElementTypes.dot);
        _curentPlayer = Player1;

        BoardCellModels = new BoardCellModel[BoardManager.Instance.BoardWidth, BoardManager.Instance.BoardHeigh];
        for (int i = 0; i < BoardManager.Instance.BoardWidth; i++) {
            for (int j = 0; j < BoardManager.Instance.BoardHeigh; j++) {
                var cellModel = new BoardCellModel(ElementTypes.none);
                cellModel.ElementType = ElementTypes.none;
                BoardCellModels[i, j] = cellModel;
            }
        }
    }

    private void ChangePlayer() {
        _curentPlayer = _curentPlayer == Player1 ? Player2 : Player1;
    }

    public void TryMakeMove(BoardCellView cell) {
        if (BoardCellModels[cell.Position.x, cell.Position.y].ElementType != ElementTypes.none)
            return;
        BoardCellModels[cell.Position.x, cell.Position.y].ElementType = _curentPlayer.Element;
        cell.SetElement(_curentPlayer.Element);
        CheckWin();
        ChangePlayer();
    }

    private void CheckWin() {

    }
}
