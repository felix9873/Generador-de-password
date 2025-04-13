
Console.WriteLine("             -----------------------------------administrador de contraseñas-----------------------------------");
Console.WriteLine();

List<string> passwords = new List<string>();

int opcion;

ChoosePanel(out opcion);

if (opcion == 1)
{
    AgregarContrasena(passwords);
}
else if (opcion == 2)
{
    PasswordAletoria();
}
else if (opcion == 3)
{
    return;
}

Console.WriteLine();

void PasswordAletoria()
{
    string[] characters = { "a" ,"A" ,"b","B","c","C","d"
                          ,"D","e","E","f","F","g","G","h"
                          ,"H","i","I","j","J","k","K","l",
                           "L","m","M","n","N","o" ,"O","p","P",
                           "q","Q","r","R","s","S","t","T","u","U",
                           "v", "V" ,"w", "W","x","X","y","Y","z","Z",
                           "-","_","@","*","|","&","#","$","&","/"
    };

    string[] passwordRandom = new string[characters.Length];

    for (int i = 0; i < 15; i++)
    {

        Random r = new Random();
        int numbers = r.Next(0, characters.Length);

        passwordRandom[i] = characters[numbers];


    }

    string result = string.Join("", passwordRandom);


    Console.WriteLine($"password aleatorio: {result}");

}


void AgregarContrasena(List<string> passwords)
{
    bool isValid = false;

    int opcion;

    Console.WriteLine("1: seguir agregando");

    Console.WriteLine("2: regresa al Panel de control");

    Console.WriteLine();

    while (!isValid)
    {
        bool isValidOption = false;

        if (!isValidOption)
        {
            Console.Write("ingresa tu contraseña :");
            string inputUser = Console.ReadLine();

            if (inputUser == "")
            {
                Console.WriteLine("ingresa una constraseña");
            }
            else
            {
                passwords.Add(inputUser);
            }
        }


        Console.WriteLine();
        Console.Write("Por favor, introduzca 1 o 2: ");

        string option = Console.ReadLine();

        if (option == "2")
        {
            isValid = true;
            ChoosePanel(out opcion);

            if (opcion == 1)
            {
                AgregarContrasena(passwords);

            }
            else if (opcion == 2)
            {
                PasswordAletoria();
                return;
            }
            else if (opcion == 4)
            {
                
            }
            else if (opcion == 3)
            {
                return;
            }

        }
        else if (option == "1")
        {
            isValidOption = false;
        }
        else
        {
            isValidOption = true;
            Console.WriteLine("escoje una opcion");
        }

        isValid = false;


    }




}

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