using Godot;
using System;

public partial class Game : Node2D
{
	Vector2 dir;
	public int inipoints = 0;
	public int playerpoints = 0;

	// Pontuação
	Label Label1;
	Label Label2;
	//Final kk
	Label Rafa;
	Label Ia;

	Sprite2D KKKK;
	Sprite2D Bot;
	Ball Bola;
	public override void _Ready()
	{
		Bola = GetNode<Ball>("/root/Game/Ball");
		// Pontuação
		Label1 = GetNode<Label>("/root/Game/Pontsplayer");	
		Label2 = GetNode<Label>("/root/Game/PontsIni");
		if (Label1 == null) GD.PrintErr("Not working");
		//Personagens
		KKKK = GetNode<Sprite2D>("/root/Game/OComedorDeNatais");
		if (KKKK == null) GD.PrintErr("Rafa não encntrado");
		Vector2 dir = new Vector2(1,0); // Vel do rafa
		Rafa = GetNode<Label>("/root/Game/OComedorDeNatais/Win");

		Bot = GetNode<Sprite2D>("/root/Game/R");
		Ia = GetNode<Label>("/root/Game/R/Label");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Definindo a pontuação
		Label1.Text = playerpoints.ToString();
		Label2.Text = inipoints.ToString();
		//Saindo do jogo
		if (Input.IsActionJustPressed("ui_cancel")) GetTree().Quit();
		// Evento
		if (Input.IsActionJustPressed("ui_accept") && (inipoints >= 10 || playerpoints >= 10)) GetTree().ChangeSceneToFile("res://Menu.tscn");
		//Evento (Rafa)
		if (playerpoints >= 10 && KKKK.GlobalPosition.X < 340)
		{
			KKKK.GlobalPosition += dir*(float)delta*200;
			dir.X = 1;
			Bola.dir.Y = 0;
		 	Bola.dir.X = 0;
		}
		if (KKKK.GlobalPosition.X >= 340) Rafa.Text = "O Looney venceu!";
		//Evento (Bot)
		if (inipoints >= 10 && Bot.GlobalPosition.X > 800)
		{
			Bot.GlobalPosition += dir*(float)delta*200;
			dir.X = -1;
			Bola.dir.Y = 0;
		 	Bola.dir.X = 0;
		}
		if (Bot.GlobalPosition.X <= 800) Ia.Text = "Ia pronta pra \n dominar o mundo";
	}
}
