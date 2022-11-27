using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Public
    //public members go here
    public int xIndex;
	public int yIndex;
    #endregion

    #region Private
    //private members go here
    private Board _board;
	#endregion
	#region DebugVariables
	// debug variables go here

	#endregion
	// Place all unity Message Methods here like OnCollision, Update, Start ect. 
	#region Unity Messages 
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	#endregion
	#region Public Methods
	//Place your public methods here
	public void Init(int x, int y, Board board)
	{
		xIndex = x;
		yIndex = y;
		_board = board;
	}
	#endregion
	#region Private Methods
	//Place your private methods here

	#endregion
}
