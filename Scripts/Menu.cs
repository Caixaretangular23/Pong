using Godot;
using System;

public partial class Menu : Node2D
{

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("ui_cancel")) GetTree().Quit();
	}
}
