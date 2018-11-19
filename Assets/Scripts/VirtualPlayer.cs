using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class VirtualPlayer : Player {

	public VirtualPlayer(Players playerType, ElementTypes element) : base(playerType, element) {
	}

	public void MakeMove() {
		bool moveAvailable = false;
		int x = 0;
		int y = 0;

		while (!moveAvailable) {
			x = Random.Range(0, BoardManager.Instance.BoardWidth);
			y = Random.Range(0, BoardManager.Instance.BoardHeigh);
			moveAvailable = GameController.Instance.IsCellAvailable(x, y);
		}

		BoardManager.Instance.GetCellView(x, y).OnClick();
	}
}
