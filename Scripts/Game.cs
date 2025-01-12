using Godot;
using System;

public partial class Game : Node2D
{
	public bool multiplayer = false;
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

	// Vars de som de pasos
	AudioStreamPlayer steps;
	bool audioactivade = false;
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

		// Sons
		steps = GetNode<AudioStreamPlayer>("/root/Game/OComedorDeNatais/Steps");

	}

	public override void _Process(double delta)
	{
		// Definindo a pontuação
		Label1.Text = playerpoints.ToString();
		Label2.Text = inipoints.ToString();
		//Saindo do jogo
		if (Input.IsActionJustPressed("ui_cancel")) GetTree().ChangeSceneToFile("res://Menu.tscn");
		// Evento
		if (Input.IsActionJustPressed("ui_accept") && (inipoints >= 10 || playerpoints >= 10)) GetTree().ChangeSceneToFile("res://Menu.tscn");
		//Evento (Rafa)
		if (playerpoints >= 10 && KKKK.GlobalPosition.X < 340)
		{
			// Manejo de sons
			if (audioactivade == false)
			{
				 steps.Play();
				 audioactivade = true;
			}
			// Manipulação de movimento
			KKKK.GlobalPosition += dir*(float)delta*50;
			dir.X = 1;
			Bola.dir.Y = 0;
		 	Bola.dir.X = 0;
		}
		if (KKKK.GlobalPosition.X >= 340)
		{
			Rafa.Text = "O Looney venceu!";
			audioactivade = false;
		}
		//Evento (Bot)
		if (inipoints >= 10 && Bot.GlobalPosition.X > 800)
		{
			// Manejo de sons
			if (audioactivade == false)
			{
				 steps.Play();
				 audioactivade = true;
			}
			Bot.GlobalPosition += dir*(float)delta*50;
			dir.X = -1;
			Bola.dir.Y = 0;
		 	Bola.dir.X = 0;
		}
		if (Bot.GlobalPosition.X <= 800)
		{
			audioactivade = false;
			 if (multiplayer == false) Ia.Text = "Ia pronta pra \n dominar o mundo";
			 if (multiplayer == true) Ia.Text = "...Eeeh,\n ele ganhou";
		}
	}

	// Quando o som step acabar
	void _on_steps_finished()
	{
		if (audioactivade == true) steps.Play();
	}
}
