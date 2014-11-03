import java.io.IOException;
import java.util.Date;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


public class DateTimeServlet extends HttpServlet {
	
	DateTimeServlet(){
		System.out.println("Creating a DateTime Servlet");
	}
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException	{
		System.out.println("GET / DateTimeServlet");
        response.setContentType("text/html");
        response.setStatus(HttpServletResponse.SC_OK);
        Date date = new Date();
        response.getWriter().println("<h1>" + date + "</h1>");        
    }
	
}
