import java.awt.Color;
import java.awt.Component;
import java.awt.Dimension;
import java.awt.Toolkit;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class Frame extends JFrame{
	
	public static final int LARG_DEFAULT = 800;
	public static final int ALT_DEFAULT = 600;
	
	private JPanel panel = new JPanel();
	
	public Frame(String s)
	{
		super(s);
		
		Toolkit tk=Toolkit.getDefaultToolkit();
		Dimension screenSize=tk.getScreenSize();
		int sl=screenSize.width;
		int sa=screenSize.height;
		int x=sl/2-LARG_DEFAULT/2;
		int y=sa/2-ALT_DEFAULT/2;
		
		panel.setLayout(null);
		
		panel.setBackground(Color.WHITE);
		
		addKeyListener(new PlayerController());
		
		add(panel);
		
		setBounds(x, y, LARG_DEFAULT, ALT_DEFAULT);
		setDefaultCloseOperation(EXIT_ON_CLOSE);
	}
	
	public void reDraw()
	{
		panel.repaint();
	}
	
	public void addComponent(Component c)
	{
		panel.add(c);
	}
	
	public void clearPanel()
	{
		panel.removeAll();
	}
}
