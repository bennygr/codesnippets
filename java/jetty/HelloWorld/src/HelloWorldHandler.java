import java.io.IOException;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.eclipse.jetty.server.Request;
import org.eclipse.jetty.server.handler.AbstractHandler;


public class HelloWorldHandler extends AbstractHandler {

	private int counter;
	
	HelloWorldHandler()
	{
		counter = 0;
	}
	
	@Override
	public void handle(String target, 
					   Request baseRequest, 
					   HttpServletRequest request,
					   HttpServletResponse response) throws IOException, ServletException {
		
		String requestTarget = "[" + target + "]";
		System.out.println("Handling a request " + requestTarget +"...");
		int c = getCounter();
		
		//Setting the Charset
		response.setContentType("text/html;charset=utf-8");
		//Setting the status of the response 
        response.setStatus(HttpServletResponse.SC_OK);
        //Mark the request as handled
        baseRequest.setHandled(true);
        
        //Write a response to the client 
        Date date = new Date();
        response.getWriter().println("<h1>Hello World<small>, request #" + c + "</small></h1>");       
        response.getWriter().println("The current local time is: " + date);        
        System.out.println("Handled request #" + c + " " + requestTarget + " at " + date);
	}
	
	private synchronized int getCounter()
	{		
		return counter++;
	}
}
