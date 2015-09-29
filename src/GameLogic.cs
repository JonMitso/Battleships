using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using SwinGameSDK;

/// <summary>
/// The GameLogic is responsible for intialising and 
/// continuing the game loop.
/// Continuing for as long as the graphics window is open
/// or the GameState is quitting.
/// </summary>
static class GameLogic
{
	public static void Main()
	{
		//Opens a new Graphics Window
		SwinGame.OpenGraphicsWindow("Battle Ships", 800, 600);

		//Load Resources
		GameResources.LoadResources();

		SwinGame.PlayMusic(GameResources.GameMusic("Background"));

		//Game Loop
		do {
			GameController.HandleUserInput();
			GameController.DrawScreen();
		} while (!(SwinGame.WindowCloseRequested() == true | GameController.CurrentState == GameState.Quitting));

		SwinGame.StopMusic();

		//Free Resources and Close Audio, to end the program.
		GameResources.FreeResources();
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
