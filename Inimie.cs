using Godot;
using System;

public partial class Inimie : CharacterBody2D
{
	Vector2 dir;
	float speed = 300;
	public override void _Ready()
	{
		dir = new Vector2(0, 1);
	}
	public override void _Process(double delta)
	{
		GlobalPosition += (float)delta*dir*speed;
		// Limitações
		if (GlobalPosition.Y < 0) dir.Y = 1;
		if (GlobalPosition.Y > 550) dir.Y = -1;
	}
}
