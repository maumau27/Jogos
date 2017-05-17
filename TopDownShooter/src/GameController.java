import java.awt.Dimension;

public class GameController {
	
	public static Frame frame;
	public static boolean isRunning = true;
	public static int tileSize = 50;
	public static Dimension tileDimension = new Dimension(tileSize, tileSize);
	public final static int FRAME_RATE = 60;
	public final static long OPTMAL_FRAME_RATE = 1000000000 / FRAME_RATE;
	
	public static Player player = new Player();

	public static void main(String[] args)
	{
		gameLoop();
	}
	
	public static void gameLoop()
	{
		long lastLoopTime = System.nanoTime();
		long lastFpsTime = 0;
		int fps = 0;
		
		initialize();
		
		while(isRunning)
		{
			long now = System.nanoTime();
			long updateLength = now - lastLoopTime;
			lastLoopTime = now;
			double delta = updateLength / ((double)OPTMAL_FRAME_RATE);
			
			lastFpsTime += updateLength;
			fps++;
			
			
			if (lastFpsTime >= 1000000000)
			{
				//System.out.println("(FPS: "+fps+")");
				lastFpsTime = 0;
				fps = 0;
			}
			
			gameUpdates(delta);
			
			render();
			
			try{Thread.sleep( (lastLoopTime-System.nanoTime() + OPTMAL_FRAME_RATE) / 1000000 );}
			catch (Exception e) {} 
		}
	}
	
	public static void gameUpdates(double delta)
	{
		player.position.x += player.acelerationX;
		player.position.y += player.acelerationY;
	}
	
	public static void render()
	{
		frame.reDraw();
	}
	
	public static void initialize()
	{
		frame = new Frame("Top Down Shooter");
		frame.setVisible(true);
		frame.addComponent(player);
	}
}
