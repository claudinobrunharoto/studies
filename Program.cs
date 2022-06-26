﻿using Course;

// See https://aka.ms/new-console-template for more information

string userOption, devOption;
bool menuReturn;

do {
    devOption = "3"; // use a number to automaticaly enter a menu option!
    menuReturn = true;
    userOption = devOption;

    Console.Clear();
    Console.WriteLine("1 - Employee (Heritage)");
    Console.WriteLine("2 - Shape Area (Abstract)");
    Console.WriteLine("3 - Chess Project");
    Console.WriteLine("4 - Outros Testes"); // para usar para várias coisas... pode apagar, modificar, etc...
    Console.WriteLine("X - Exit\n");

    if (String.IsNullOrEmpty(devOption)) {
        userOption = Console.ReadLine() ?? string.Empty;
    }

    Console.Clear();

    switch (userOption) {
        case "1": HeritageMain x = new HeritageMain(); break;
        case "2": AbstractMain w = new AbstractMain(); break;
        case "3": ChessMain y = new ChessMain(); break;
        case "4": OtherMain z = new OtherMain(); break;
        default:
            menuReturn = false;
            if (userOption.ToUpper() != "X") {
                Console.WriteLine("Invalid option!");
                if (String.IsNullOrEmpty(devOption)) {
                    Console.ReadLine();
                }
            }
            break;
    }

    if (!String.IsNullOrEmpty(devOption)) {
        System.Console.WriteLine("\n... finishing execution (DevOption '" + devOption + "' used)!\n");
        break;
    }

    if (menuReturn) {
        Console.WriteLine("\n... back to main menu!");
        Console.ReadLine();
    }

} while (userOption.ToUpper() != "X");