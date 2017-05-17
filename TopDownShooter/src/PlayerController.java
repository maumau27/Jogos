import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class PlayerController implements KeyListener {
	
	@Override
	public void keyTyped(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}
	
	@Override
	public void keyReleased(KeyEvent e) {
		// TODO Auto-generated method stub
		switch (e.getKeyChar()) {
		case 'w':
			GameController.player.acelerationY = 0;
		break;
		case 's':
			GameController.player.acelerationY = 0;
			break;
		case 'a':
			GameController.player.acelerationX = 0;
			break;
		case 'd':
			GameController.player.acelerationX = 0;
			break;

		default:
			break;
		}
	}
	
	@Override
	public void keyPressed(KeyEvent e) {
		// TODO Auto-generated method stub
		switch (e.getKeyChar()) {
		case 'w':
				GameController.player.acelerationY = -2;
			break;
		case 's':
			GameController.player.acelerationY = -2;
			break;
		case 'a':
			GameController.player.acelerationX = -2;
			break;
		case 'd':
			GameController.player.acelerationX = -2;
			break;

		default:
			break;
		}
	}
}
