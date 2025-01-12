using Godot;
using System;

public partial class Player2 : CharacterBody2D
{
	float speed = 500;
	Game Controll;
	public override void _Ready()
	{
		Controll = GetNode<Game>("/root/Game");
		Controll.multiplayer = true;
	}
	public override void _Process(double delta)
	{
		Vector2 dir = new Vector2(0,0);
		// Inputs
		if (Input.IsActionPressed("ui_second_up") && GlobalPosition.Y > 50) dir.Y = -1;
		if (Input.IsActionPressed("ui_second_down") && GlobalPosition.Y < 550) dir.Y = 1;
		//Atualização de movimento
		 GlobalPosition += dir*(float)delta*speed;
	}
}
