using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	int sizeX = 32;
	int sizeY = 32;
	
	
	Vector3 mousePos;
	int xDrawOff1 = 0;
	int yDrawOff1 = 0; 
	int xDrawOff2 = 0;
	int yDrawOff2 = 0; 
	public int playerNumber = 1;
	public int xDraw1 = 0;
	public int yDraw1 = 0;
	public int xDraw2 = 0;
	public int yDraw2 = 0;
	string p_RAX1, p_RAY1;
	string p_RAX2, p_RAY2;
	
	public Texture2D crosshair;
	// Use this for initialization
	void Awake () {

		
		Screen.showCursor = false;
		mousePos = Input.mousePosition;
		xDrawOff1 = Screen.width/2;
		yDrawOff1 = Screen.height*3/4;
		xDrawOff2 = Screen.width/2;
		yDrawOff2 = Screen.height/4;
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if( mousePos.x != Input.mousePosition.x || mousePos.y != Input.mousePosition.y )
		{ mousePos = Input.mousePosition; xDrawOff1 = 0; yDrawOff1 = 0;xDrawOff2 = 0; yDrawOff2 = 0;}
	
		xDrawOff1 += (int)(Input.GetAxis(p_RAX1)*Time.deltaTime*400);
		yDrawOff1 += (int)(Input.GetAxis(p_RAY1)*Time.deltaTime*400);
		xDraw1 = (int)mousePos.x + xDrawOff1;
		yDraw1 = (int)mousePos.y - yDrawOff1;
		
		xDrawOff2 += (int)(Input.GetAxis(p_RAX2)*Time.deltaTime*400);
		yDrawOff2 += (int)(Input.GetAxis(p_RAY2)*Time.deltaTime*400);
		xDraw2 = (int)mousePos.x + xDrawOff2;
		yDraw2 = (int)mousePos.y - yDrawOff2;
		
		if( xDraw1 < 0 ) xDraw1 = 0;
		if( yDraw1 < Screen.height/2 ) yDraw1 = Screen.height/2;
		if( xDraw1 > Screen.width ) xDraw1 = Screen.width;
		if( yDraw1 > Screen.height ) yDraw1 = Screen.height;
		
		if( xDraw2 < 0 ) xDraw2 = 0;
		if( yDraw2 < 0 ) yDraw2 = 0;
		if( xDraw2 > Screen.width ) xDraw2 = Screen.width;
		if( yDraw2 > Screen.height ) yDraw2 = Screen.height;
		//print (xDraw1 + " " + yDraw);
		
	}
	
	public Vector3 getAim(int playerNum)
	{
		if(playerNum == 1)
		{
			return new Vector3( xDraw1, yDraw1, 0.0f );
		}
		else if ( playerNum == 2 )
		{
			return new Vector3( xDraw2, yDraw2, 0.0f );
		}
		else
		{
			return Vector3.zero;
		}
		
		
	}
	
	void OnGUI() 
	{
		GUI.DrawTexture ( new Rect(xDraw1-sizeX/2,Screen.height-(yDraw1+sizeY/2), sizeX , sizeY ),
		                 crosshair, ScaleMode.ScaleToFit, true, 1.0f );
		GUI.DrawTexture ( new Rect(xDraw2-sizeX/2,Screen.height-(yDraw2+sizeY/2), sizeX , sizeY ),
		                 crosshair, ScaleMode.ScaleToFit, true, 1.0f );
	} 
	
}
