using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Board : MonoBehaviour
{
	#region Public
	//public members go here

	#endregion

	#region Private
	//private members go here
	[SerializeField] int _width = 8;
	[SerializeField] int _height = 8;
	[SerializeField] int _borderSize;
	[SerializeField] GameObject _tilePrefab;
	[SerializeField] GameObject[] _gamePiecePrefabs;

	Tile[,] _tiles;
	GamePiece[,] _gamePieces;

	#endregion
	#region DebugVariables
	// debug variables go here

	#endregion
	// Place all unity Message Methods here like OnCollision, Update, Start ect. 
	#region Unity Messages 
	// Start is called before the first frame update
	void Start()
	{
		_tiles = new Tile[_width, _height];
		_gamePieces = new GamePiece[_width, _height];
		SetupTiles();
		SetUpCamera();
		FillRandom();
	}

	// Update is called once per frame
	void Update()
	{

	}
	#endregion
	#region Public Methods
	//Place your public methods here

	#endregion
	#region Private Methods
	//Place your public methods here

	void SetupTiles()
	{
		for (int i = 0; i < _width; i++)
		{
			for (int j = 0; j < _height; j++)
			{
				GameObject tile = Instantiate(_tilePrefab, new Vector3(i, j, 0), Quaternion.identity);
				tile.transform.SetParent(transform);
				tile.name = "Tile (" + i + ", " + j + ")";
				_tiles[i, j] = tile.GetComponent<Tile>();
				_tiles[i, j].Init(i, j, this);

			}
		}
	}

	void SetUpCamera()
	{
		Camera.main.transform.position = new Vector3((float)(_width - 1) / 2, (float)(_height - 1) / 2, -10f);

		float aspectRatio = (float)Screen.width / (float)Screen.height;
		float verticalSize = (float)_height / 2f + (float)_borderSize;
		float horizontalSize = ((float)_width / 2f + (float)_borderSize) / aspectRatio;

		Camera.main.orthographicSize = (verticalSize > horizontalSize) ? verticalSize : horizontalSize;
	}

	GameObject GetRandomPiece()
	{
		int pieceIndex = Random.Range(0, _gamePiecePrefabs.Length); ;
		while (_gamePiecePrefabs[pieceIndex] == null)
		{
			pieceIndex = Random.Range(0, _gamePiecePrefabs.Length);
		}
		return _gamePiecePrefabs[pieceIndex];
	}

	void PlaceGamePiece(GamePiece gamePiece, int x, int y)
	{
		if (gamePiece == null)
		{
			Debug.LogWarningFormat("Game Piece prefab is null");
			return;
		}
		gamePiece.transform.position = new Vector3(x, y, 0);
		gamePiece.transform.rotation = Quaternion.identity;
		gamePiece.SetCoord(x, y);

	}

	void FillRandom()
    {
		for (int i = 0; i < _width; i++)
        {
			for (int j = 0; j < _height; j++)
            {
				GameObject randomPiece = Instantiate(GetRandomPiece(), Vector3.zero, Quaternion.identity) as GameObject;
				if (randomPiece != null)
                {
					PlaceGamePiece(randomPiece.GetComponent<GamePiece>(), i, j);
                }
            }
        }
    }
	#endregion
}