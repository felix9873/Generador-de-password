
Console.WriteLine("             -----------------------------------administrador de contraseñas-----------------------------------");
Console.WriteLine();

List<string> passwords = new List<string>();

int opcion;

ChoosePanel(out opcion);

void ChoosePanel(out int opcion)
{
    Console.WriteLine("Panel de control");

    Console.WriteLine();

    Console.WriteLine("1: ingresar contraseña");
    Console.WriteLine("2: generar contraseña de manera aleatoria");
    Console.WriteLine("3: salir del programa");
    Console.WriteLine("4: administrar password");
    Console.WriteLine();

    Console.Write("opcion: ");

    while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2
        && opcion != 3 && opcion != 4))
    {
        Console.Write(" introduzca 1 o 2 o 3 o 4: ");
    }
}