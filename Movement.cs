using Godot;
using System;

public partial class Movement : CharacterBody2D
{

	float speed = 500;
	public override void _Ready()
	{
	}

	public override void _PhysicsProcess(double delta)
	{
		// Configuração de movimento
		Vector2 dir = new Vector2(0,0);
		GlobalPosition += speed*(float)delta*dir;
		// Input
		if (Input.IsActionPressed("ui_up")) dir.Y = -1;
		if (Input.IsActionPressed("ui_down")) dir.Y = 1;
	}
}
