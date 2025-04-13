
using System.Text;
using XSystem.Security.Cryptography;


Console.WriteLine("             -----------------------------------administrador de contraseñas-----------------------------------");
Console.WriteLine();

List<string> passwords = new List<string>();

PanelControl();

void PanelAdministrarPassword()
{
    Console.WriteLine();

    Console.WriteLine("Panel administrar");
    Console.WriteLine("1: mostrar password");
    Console.WriteLine("2: eliminar password por id");
    Console.WriteLine("3: buscar password por id");
    Console.WriteLine("4: regresar al panel de control");
    Console.WriteLine();

    Console.Write("opcion: ");

    int opcionAdm;

    while (!int.TryParse(Console.ReadLine(), out opcionAdm) || 
        (opcionAdm != 1 && opcionAdm != 2
        && opcionAdm != 3 && opcionAdm !=4) )
    {
        Console.Write(" introduzca 1 o 2 o 3: 4");
    }

    if(opcionAdm == 1)
    {
        
        MostrarPassword(passwords);
        PanelAdministrarPassword();
    }
    else if (opcionAdm == 2) 
    {
        Console.Write("ingresa el id para eliminar el password: ");

        int id = Convert.ToInt32(Console.ReadLine());

        EliminarPasswordPorId(passwords, id);
        PanelAdministrarPassword();
    }
    else if(opcionAdm == 3)
    {
        Console.Write("ingresa el id para buscar el password: ");

        int id = Convert.ToInt32(Console.ReadLine());

        BuscarPorId(passwords, id);
        PanelAdministrarPassword();
    }
    else if(opcionAdm == 4)
    {
        PanelControl();
    }
}

void BuscarPorId(List<string> passwords, int id)
{
    if(id > 0 )
    {
        byte[] tmpSource;

        tmpSource = Encoding.UTF8.GetBytes(passwords[id - 1]);

        byte[] tmpHash;

        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        Console.WriteLine($"el password encontrado: {ByteArrayToString(tmpHash)} con id {id}");
    }
    else
    {
        Console.WriteLine("ingresa un id mayor a 0");
    }
}
void PanelControl()
{
    
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
        if (passwords.Count > 0)
        {
            PanelAdministrarPassword();
        }
        else
        {
            Console.WriteLine();

            Console.WriteLine("para ingresar al administrador de password necesita ingresar un password");

            Console.WriteLine();

            PanelControl();

        }

    }
    else if (opcion == 4)
    {
        return;
    }

    Console.WriteLine();

}
void EliminarPasswordPorId(List<string> password,int id)
{
   if(id > 0)
    {
        password.RemoveAt(id - 1);

        Console.WriteLine($"password eliminado con : {id}");
    }
    else
    {
        Console.WriteLine("ingresa un id mayor a 0");
    }
   
}

void MostrarPassword(List<string> passwords)
{
    
    Console.WriteLine("--------------------------------------------------------------");

    Console.WriteLine("passwords");

    Console.WriteLine("id");

    for (int i = 0; i < passwords.Count; i++) 
    {
        byte[] tmpSource;

        tmpSource = Encoding.UTF8.GetBytes(passwords[i]);

        byte[] tmpHash;

        tmpHash = new MD5CryptoServiceProvider().ComputeHash(tmpSource);

        Console.WriteLine($"{i + 1}  : {ByteArrayToString(tmpHash)}");
    }

}

string ByteArrayToString(byte[] arrInput)
{
    int i;
    StringBuilder sOutput = new StringBuilder(arrInput.Length);

    for (i = 0; i < arrInput.Length; i++)
    {
        sOutput.Append(arrInput[i].ToString("X2"));
    }
    return sOutput.ToString();
}


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
            
            {
                passwords.Add(inputUser);
            }
        }


        Console.WriteLine();
        Console.Write("introduzca 1 o 2: ");

        string option = Console.ReadLine();
        Console.WriteLine();

        if (option == "2")
        {
            isValid = true;

            PanelControl();
            return;

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
    Console.WriteLine("3: administrar password");
    Console.WriteLine("4: salir del programa");
   
    Console.WriteLine();

    Console.Write("opcion: ");

    while (!int.TryParse(Console.ReadLine(), out opcion) || (opcion != 1 && opcion != 2
        && opcion != 3 && opcion != 4))
    {
        Console.Write(" introduzca 1 o 2 o 3 o 4: ");
    }
}