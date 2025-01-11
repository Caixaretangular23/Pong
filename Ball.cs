using Godot;
using System;

public partial class Ball : Area2D
{
	float speed = 500;
	float time = 0;
	public Vector2 dir; // Definir a direção
	Random myY = new Random(); // Setar um número randômico
	Random myX = new Random();
	// Números randomicos
	int rY;
	int iniX; // qual o lado pra iniciar
	// Referencia
	Node Room;
	Game master;
	// Componenetes de sons
	AudioStreamPlayer poping;
	AudioStreamPlayer losted;
	AudioStreamPlayer winner;

	bool begin = false;

	public override void _Ready()
	{
		// Cálculo de randomização
		rY = myY.Next(-1,1);
		int rX = myX.Next(0,1);
		if (rX == 0) iniX = -1;
		if (rX == 1) iniX = 1;
		// Direncionamento
		dir = new Vector2(0,0);
		// Configuração de node Com o inimigo
		Node gamenode = GetNode("/root/Game");
		Room = gamenode.GetNode<Node2D>("Inimie");

		//Configurando o node dos sons
		poping = GetNode<AudioStreamPlayer>("Pop");
		losted = GetNode<AudioStreamPlayer>("Lost");
		winner = GetNode<AudioStreamPlayer>("Win");

		// Configuração de Node com o próprio controlador
		master = GetNode<Game>("/root/Game");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// Começando o jogo
		if (Input.IsActionPressed("ui_accept") && begin == false)
		{
			 dir = new Vector2(iniX,rY);
			 begin = true;
		}
		//Perdendo no jogo
		if (GlobalPosition.X < 0 || GlobalPosition.X > 1200)
		{
			// Definindo pontuação
			if (GlobalPosition.X > 1200)
			{
				master.playerpoints++;
				winner.Play();
			}
			if (GlobalPosition.X < 0)
			{
				master.inipoints++;
				losted.Play();
			} 
			// Resetando pos
			rY = myY.Next(-1,1);
			dir.Y = rY;
			dir.X *= -1;
			speed = 500;
			GlobalPosition = new Vector2(500,200);
		}
		// Invertendo movimento vertical
		if (GlobalPosition.Y < 0) dir.Y = 1;
		if (GlobalPosition.Y > 650) dir.Y = -1;
		// Atualização de movimento
		GlobalPosition += speed*dir*(float)delta; 
		// Aumentando velocidade
		if (speed < 1200)
		{
			time++;
			if (time >= 10000*(float)delta)
			{
				speed += 50;
				time = 0;
			}
		}
	}
	// Quando colidiu
	public void _on_body_entered(Node Game)
	{
		poping.Play();
		dir.X *= -1;
		rY = myY.Next(-2,1);
		dir.Y = rY;
	}
}
