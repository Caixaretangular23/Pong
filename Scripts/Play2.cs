using Godot;
using System;

public partial class Play2 : Button
{
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
	}

	void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://Multiplayer.tscn");
	}
}
