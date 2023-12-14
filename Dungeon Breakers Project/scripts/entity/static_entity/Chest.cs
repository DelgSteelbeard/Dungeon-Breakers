using Godot;
using Microsoft.VisualBasic;
using System;
using x;

public partial class Chest : Node2D
{
	private StaticEntityList staticEntityList = StaticEntityList.Instance;
	private int entityID = 1;
	public string name = "chest";
	private int _x;
	private int _y;
	public bool intreactable = true;
	[Export]
	public Openable openable;
	
	[Export]
	public int x
	{
		get => _x;
		set
		{
			_x = value;
			checkReady();
		}
	}
	[Export]
	public int y
	{
		get => _y;
		set
		{
			_y = value;
			checkReady();
		}
	}

	private void checkReady()
	{
		if (_x != 0 && _y != 0)
		{
			SingleEntity chest = new SingleEntity(name, entityID, _x, _y);
			staticEntityList.Entities.Add(chest);
			staticEntityList.ReadAllEntities();
		}
	}
	
	public void interact()
	{
		openable.Open();
	}
	
}

