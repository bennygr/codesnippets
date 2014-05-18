#include <QApplication>
#include <QPushButton>

int main(int argc, char **argv)
{
	QApplication app (argc, argv);

	QPushButton button ("Quit!");
	button.show();

	QObject::connect(&button, SIGNAL(clicked()), &app, SLOT(quit()));

	return app.exec();
}

