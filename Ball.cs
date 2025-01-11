using Godot;
using System;

public partial class Ball : Area2D
{
	float speed = 700;
	float time = 0;
	public Vector2 dir; // Definir a direção
	Random myY = new Random(); // Setar um número randômico
	// Números randomicos
	int rY;
	// Referencia
	Node Room;
	public override void _Ready()
	{
		rY = myY.Next(-1,1);
		dir = new Vector2(-1,rY);
		// Configuração de node
		Node gamenode = GetNode("/root/Game");
		Room = gamenode.GetNode<Node2D>("Inimie");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//Perdendo no jogo
		if (GlobalPosition.X < 0 || GlobalPosition.X > 1200) GetTree().ReloadCurrentScene();
		// Invertendo movimento vertical
		if (GlobalPosition.Y < 0) dir.Y = 1;
		if (GlobalPosition.Y > 700) dir.Y = -1;
		// Atualização de movimento
		GlobalPosition += speed*dir*(float)delta; 
		// Aumentando velocidade
		time++;
		if (time >= 10000*(float)delta)
		{
			speed += 50;
			time = 0;
		}
	}
	// Quando colidiu
	public void _on_body_entered(Node Game)
	{
		dir.X *= -1;
		rY = myY.Next(-1,1);
		dir.Y = rY;
	}
}
