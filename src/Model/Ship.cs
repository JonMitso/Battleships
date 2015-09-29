using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

/// <summary>
/// A Ship has all the details about itself. For example the shipname,
/// size, number of hits taken and the location. Its able to add tiles,
/// remove, hits taken and if its deployed and destroyed.
/// </summary>
/// <remarks>
/// Deployment information is supplied to allow ships to be drawn.
/// </remarks>
public class Ship
{
	/// <summary>
	/// The type of ship.
	/// </summary>
	private ShipName _shipName;

	/// <summary>
	/// The number of tiles ship uses.
	/// </summary>
	private int _sizeOfShip;

	/// <summary>
	/// The number of hits taken by the ship; initialised to 0.
	/// </summary>
	private int _hitsTaken = 0;

	/// <summary>
	/// The array of tiles.
	/// </summary>
	private List<Tile> _tiles;

	/// <summary>
	/// The row location of the ship.
	/// The topmost location of the ship.
	/// </summary>
	private int _row;

	/// <summary>
	/// The column location of the ship.
	/// The leftmost location of the ship.
	/// </summary>
	private int _col;

	/// <summary>
	/// The direction of the ship in relation to its location.
	/// </summary>
	private Direction _direction;

	/// <summary>
	/// The type of ship
	/// </summary>
	/// <value>The type of ship</value>
	/// <returns>The type of ship</returns>
	public string Name {
		get {
			if (_shipName == ShipName.AircraftCarrier) {
				return "Aircraft Carrier";
			}

			return _shipName.ToString();
		}
	}

	/// <summary>
	/// The number of cells that this ship occupies.
	/// </summary>
	/// <value>The number of hits the ship can take</value>
	/// <returns>The number of hits the ship can take</returns>
	public int Size {
		get { return _sizeOfShip; }
	}

	/// <summary>
	/// The number of hits that the ship has taken.
	/// </summary>
	/// <value>The number of hits the ship has taken.</value>
	/// <returns>The number of hits the ship has taken</returns>
	/// <remarks>When this equals Size the ship is sunk</remarks>
	public int Hits {
		get { return _hitsTaken; }
	}

	/// <summary>
	/// The row location of the ship
	/// </summary>
	/// <value>The topmost location of the ship</value>
	/// <returns>the row of the ship</returns>
	public int Row {
		get { return _row; }
	}

	/// <summary>
	/// The column location of the ship
	/// </summary>
	/// <value>The leftmost location of the ship</value>
	/// <returns>the column of the ship</returns>
	public int Column {
		get { return _col; }
	}

	/// <summary>
	/// The direction of the ship
	/// </summary>
	/// <value>The direction of the ship in relation to its location.</value>
	/// <returns>the direction of the ship</returns>
	public Direction Direction {
		get { return _direction; }
	}

	/// <summary>
	/// Adds a new ship
	/// </summary>
	/// <param name="ship">Ship.</param>
	public Ship(ShipName ship)
	{
		_shipName = ship;
		_tiles = new List<Tile>();

		//gets the ship size from the enumarator
		_sizeOfShip = (int)_shipName;
	}

	/// <summary>
	/// Add tile adds the ship tile
	/// </summary>
	/// <param name="tile">one of the tiles the ship is on</param>
	public void AddTile(Tile tile)
	{
		_tiles.Add(tile);
	}

	/// <summary>
	/// Remove clears the tile back to a sea tile
	/// </summary>
	public void Remove()
	{
		foreach (Tile tile in _tiles) {
			tile.ClearShip();
		}
		_tiles.Clear();
	}

	/// <summary>
	/// Adds to the number of hits taken by the ship
	/// simple counter that works in conjunction with IsDestroyed
	/// </summary>
	public void Hit()
	{
		_hitsTaken = _hitsTaken + 1;
	}

	/// <summary>
	/// IsDeployed returns if the ships is deployed, if its deplyed it has more than
	/// 0 tiles
	/// </summary>
	public bool IsDeployed {
		get { return _tiles.Count > 0; }
	}

	/// <summary>
	/// Gets a value indicating whether the ship is destroyed.
	/// </summary>
	/// <value>if the number of hits is equal to the ship size then true</value>
	public bool IsDestroyed {
		get { return Hits == Size; }
	}

	/// <summary>
	/// Record that the ship is now deployed.
	/// </summary>
	/// <param name="direction"></param>
	/// <param name="row"></param>
	/// <param name="col"></param>
	internal void Deployed(Direction direction, int row, int col)
	{
		_row = row;
		_col = col;
		_direction = direction;
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
