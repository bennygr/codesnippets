import org.eclipse.jetty.server.Server;

public class JettyTest {
	
	public static void main (String[] args)
	{				
		//Starting a jetty server		
		try {
			System.out.println("Simple Jetty Example saying \"Hello World\"!");
			Server server = new Server(8080);
			server.setHandler(new HelloWorldHandler());
			server.start();
			server.join();			
		} catch (Exception e) {					
			System.out.println("Error while starting the jetty server: " + e.getMessage());			
			e.printStackTrace();
		}		
	}
}


