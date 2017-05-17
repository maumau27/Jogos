import java.awt.Color;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.geom.Ellipse2D;

import javax.swing.JPanel;

public class Player extends JPanel{
	
	public Point position = new Point(100, 100);
	public float acelerationY = 0;
	public float acelerationX = 0;
	
	public Player()
	{
		setPos();
	}
	
	public void setPos()
	{
		this.setLayout(null);
		this.setSize(GameController.tileDimension);
		this.setPreferredSize(GameController.tileDimension);
		this.setLocation(position);
		this.setOpaque(false);
	}
	
	public void paintComponent(Graphics g)
	{
		super.paintComponents(g);
		Graphics2D g2d=(Graphics2D) g;
		
		this.setLocation(position);
		
		drawPlayer(g2d);
	} 
	
	private void drawPlayer(Graphics2D g2d)
	{
		// Desenha círculo com o mesmo centro
		double cX=GameController.tileSize/2;
		double cY=GameController.tileSize/2;
		double raio=25.0/2;
		
		Ellipse2D circ = new Ellipse2D.Double();
		circ.setFrameFromCenter(cX,cY,cX+raio,cY+raio);
		g2d.setColor(Color.BLACK);
		g2d.fill(circ);
	}
}
