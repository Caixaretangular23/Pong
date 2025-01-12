using Godot;
using System;

public partial class Play : Button
{

	public void _on_pressed()
	{
		GetTree().ChangeSceneToFile("res://game.tscn");
	}
}
