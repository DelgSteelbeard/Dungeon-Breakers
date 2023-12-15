using Godot;
using System;
using System.Collections.Generic;
using game;
//class like a grid class for testing
public partial class FirstLevel : Node2D
{
	Chest chest;
	Barrel barrel;
	IOpen interafcee;
	StaticEntityList staticEntityList;
    Grid grid = Grid.Instance;
	public override void _Ready()
	{
		//tests for the openable interface
		chest = GetNode<Chest>("chest1");
		barrel = GetNode<Barrel>("barrel");
        interafcee = chest.open;
		interafcee.Open();
		interafcee = barrel.open;
		interafcee.Open();

		//tests for the static entity list
		int[,,] mygrid = new int[64, 64, 7];
		staticEntityList = StaticEntityList.Instance;
		List<SingleEntity> entities = staticEntityList.Entities;
		for(int i = 0; i < entities.Count; i++)
		{
			int x = entities[i].x;
			int y = entities[i].y;
			mygrid[x, y, 6] = i + 1;
            GD.Print($"Entity Name: {entities[i].name}, ID: {entities[i].entityID}, X: {entities[i].x}, Y: {entities[i].y} Interactable: {entities[i].interactable} i = {i}");
		}
        grid.grid = mygrid;
		//test for getting the parameter from the grid
		string name = entities[mygrid[11, 4, 6]].name;
		GD.Print(mygrid[11, 4, 6]);
	}
}