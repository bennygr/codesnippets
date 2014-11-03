import org.eclipse.jetty.server.Server;
import org.eclipse.jetty.servlet.ServletContextHandler;
import org.eclipse.jetty.servlet.ServletHolder;


public class SimpleServletStarter {
	public static void main(String[] args) {
		
			
		try {
			System.out.println("Starting a jetty server hosting some servlets for testing purpose...");
						
			//Creating a servlet-handler containing various servlets each accessible 
			//via it's own hard coded path
			ServletContextHandler ctx = new ServletContextHandler(ServletContextHandler.SESSIONS);
			ctx.setContextPath("/");
			ctx.addServlet(new ServletHolder(new DateTimeServlet()), "/time");
			ctx.addServlet(new ServletHolder(new HelloWorldServlet("MyServlet")), "/*");
			
			//Creating and starting a jetty server
			Server server = new Server(8080);
			//Setting the servlet handler
			server.setHandler(ctx);
			server.start();
			server.join();							
			
		} catch (Exception e) {
			System.out.println(e.getMessage());
			e.printStackTrace();
		}		
	}
}
