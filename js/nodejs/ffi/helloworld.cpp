#include <iostream>
#include <string>
#include <vector>
#include <algorithm>

std::vector<void(*)(const char*)> clbs;
int i = 0;

extern "C" {

	void inc()
	{
		std::cout << ++i << std::endl;
	}

	void dosomething(void (*clb)(const char*))
	{
		std::cout << "calling callback:" << std::endl;	
		std::string data = "testdataforcallback";
		clb(data.c_str());
	}

	void dosomething2()
	{
		std::cout << "calling callback:" << std::endl;	
		std::string data = "testdataforcallback";
		for(int i=0; i<clbs.size(); i++)
		{
			clbs[i](data.c_str());
		}
	}

	const char* getstdstring(void)
	{
		std::string test = "getstdstring";
		return test.c_str();
	}

	const char* getstring(void)
	{
		return "getstring";
	}

	void hello(void)
	{
		std::cout << "hello world" << std::endl;
	}

	int add(int a, int b)
	{
		return a + b;
	}

	void registerclb(void (*clb)(const char*))
	{
		clbs.push_back(clb);
		std::cout << "callback registered" << std::endl;
	}

	void unregisterclb(void (*clb)(const char*))
	{
		std::cout << "callback unregistered" << std::endl;
		clbs.erase(std::remove(clbs.begin(), clbs.end(), clb), clbs.end());
	}
}
