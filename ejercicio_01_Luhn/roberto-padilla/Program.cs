//Presentado por: Roberto Padilla
int opc;

int totalValidas = 0;
int totalInvalidas = 0;

int totalVisa = 0;
int totalMastercard = 0;
int totalAmerican = 0;
int totalDiscover = 0;

Random random = new Random();

do{
    Console.WriteLine("--------------------------------");
    Console.WriteLine("1. Validar una tarjeta");
    Console.WriteLine("2. Validar desde archivo");
    Console.WriteLine("3. Generar número válido");
    Console.WriteLine("4. Estadísticas");
    Console.WriteLine("5. Salir");
    Console.WriteLine("--------------------------------");

    if (!int.TryParse(Console.ReadLine(), out opc))
    {
        opc = 0;
    }

    switch (opc)
    {
        case 1:
            Console.WriteLine("Digita el número de la tarjeta de que deseas validar:");
            string? numeroTarjeta = Console.ReadLine();
            ResultadoValidacionTarjeta(numeroTarjeta);

            break;
        case 2:
            Console.Write("Ruta del archivo a validar: ");
            string ruta = Console.ReadLine();
            ValidarArchivo(ruta);

            break;
        case 3:
            string? marca;

            do
            {
                Console.WriteLine("¿Qué marca desea generar?");
                Console.WriteLine("Visa, Mastercard, American, Discover o Aleatoria");

                marca = Console.ReadLine()?.Trim().ToLower();

            } while (marca != "visa" &&
                    marca != "mastercard" &&
                    marca != "american" &&
                    marca != "discover" &&
                    marca != "aleatoria");

            string tarjetaGenerada = GenerarTarjeta(marca);
            ResultadoValidacionTarjeta(tarjetaGenerada);

            break;
        case 4:
            MostrarEstadisticas();
            break;
        case 5:
            Console.WriteLine("¡HASTA LA PRÓXIMA!");
            break;
        default:
            Console.WriteLine("Ingrese Opción Válida");
            break;
    }

} while (opc != 5);
 

bool ValidarTarjeta(string numero)
{
    if (numero.Length < 13 || numero.Length > 19)
        return false;

    char[] invertido = numero.Reverse().ToArray();
    int suma = 0;

    for (int i = 0; i < invertido.Length; i++)
    {
        int digito = invertido[i] - '0';

        if ((i + 1) % 2 == 0)
        {
            digito *= 2;

            if (digito >= 10)
            {
                digito = (digito / 10) + (digito % 10);
            }
        }

        suma += digito;
    }

    return suma % 10 == 0;
}

bool EsVisa(string numero)
{
    return numero.StartsWith("4") && (numero.Length == 13 || numero.Length == 16);
}

bool EsMastercard(string numero)
{
    if (numero.Length != 16)
        return false;

    int prefijo = int.Parse(numero.Substring(0, 2));

    return prefijo >= 51 && prefijo <= 55;
}

bool EsAmericanExpress(string numero)
{
    return numero.Length == 15 &&
           (numero.StartsWith("34") || numero.StartsWith("37"));
}

bool EsDiscover(string numero)
{
    if (numero.Length < 16 || numero.Length > 19)
        return false;

    if (numero.StartsWith("6011") || numero.StartsWith("65"))
        return true;

    int prefijo3 = int.Parse(numero.Substring(0, 3));
    if (prefijo3 >= 644 && prefijo3 <= 649)
        return true;

    int prefijo6 = int.Parse(numero.Substring(0, 6));
    if (prefijo6 >= 622126 && prefijo6 <= 622925)
        return true;

    return false;
}

string IdentificarMarca(string numero)
{
    if (EsVisa(numero)){
        totalVisa++;
        return "Visa";
    }

    if (EsMastercard(numero)){
        totalMastercard++;
        return "Mastercard";
    }

    if (EsAmericanExpress(numero)){
        totalAmerican++;
        return "American Express";
    }

    if (EsDiscover(numero)){
        totalDiscover++;
        return "Discover";
    }

    return "No identificada";
}

void ResultadoValidacionTarjeta(string numeroTarjeta)
{
    string estado = ValidarTarjeta(numeroTarjeta) ? "VÁLIDA" : "INVÁLIDA";
    if(estado == "VÁLIDA")
        totalValidas++;
    else
        totalInvalidas++;

    Console.WriteLine("--------------------------------");    
    Console.WriteLine($"Número: {numeroTarjeta}");
    Console.WriteLine($"Marca: {IdentificarMarca(numeroTarjeta)}");
    Console.WriteLine($"Estado: {estado}");
}

void ValidarArchivo(string ruta)
{
    if (!File.Exists(ruta))
    {
        Console.WriteLine("Archivo no encontrado.");
        return;
    }

    string[] lineas = File.ReadAllLines(ruta);

    int validas = 0;
    int invalidas = 0;

    Console.WriteLine("--------------------------------");
    
    foreach (string numero in lineas)
    {
        bool esValida = ValidarTarjeta(numero);

        string marca = esValida
            ? IdentificarMarca(numero)
            : "Desconocida";

        Console.WriteLine($"Número: {numero}");
        Console.WriteLine($"Marca: {marca}");
        Console.WriteLine($"Estado: {(esValida ? "VÁLIDA" : "INVÁLIDA")}");
        Console.WriteLine();

        if (esValida)
            validas++;
        else
            invalidas++;
    }

    Console.WriteLine("=== RESUMEN ===");
    Console.WriteLine($"Válidas: {validas}");
    Console.WriteLine($"Inválidas: {invalidas}");

    totalInvalidas += invalidas;
    totalValidas += validas;
}

string GenerarVisa()
{
    string numero = "4";

    while (numero.Length < 15)
    {
        numero += random.Next(10);
    }

    for (int digito = 0; digito <= 9; digito++)
    {
        string posible = numero + digito;

        if (ValidarTarjeta(posible))
        {
            return posible;
        }
    }

    return "";
}

string GenerarMastercard()
{
    string numero = random.Next(51, 56).ToString();

    while (numero.Length < 15)
    {
        numero += random.Next(10);
    }

    for (int digito = 0; digito <= 9; digito++)
    {
        string posible = numero + digito;

        if (ValidarTarjeta(posible))
        {
            return posible;
        }
    }

    return "";
}

string GenerarAmericanExpress()
{
    string numero = random.Next(0, 2) == 0 ? "34" : "37";

    while (numero.Length < 14)
    {
        numero += random.Next(10);
    }

    for (int digito = 0; digito <= 9; digito++)
    {
        string posible = numero + digito;

        if (ValidarTarjeta(posible))
        {
            return posible;
        }
    }

    return "";
}

string GenerarDiscover()
{
    string numero = "6011";

    while (numero.Length < 15)
    {
        numero += random.Next(10);
    }

    for (int digito = 0; digito <= 9; digito++)
    {
        string posible = numero + digito;

        if (ValidarTarjeta(posible))
        {
            return posible;
        }
    }

    return "";
}

string GenerarTarjeta(string marca)
{
    if (marca == "aleatoria")
    {
        string[] marcas =
        {
            "visa",
            "mastercard",
            "american",
            "discover"
        };

        marca = marcas[random.Next(marcas.Length)];
    }

    return marca switch
    {
        "visa" => GenerarVisa(),
        "mastercard" => GenerarMastercard(),
        "american express" => GenerarAmericanExpress(),
        "discover" => GenerarDiscover(),
        _ => ""
    };
}

void MostrarEstadisticas()
{
    Console.WriteLine("=== ESTADÍSTICAS ===");

    Console.WriteLine($"Válidas: {totalValidas}");
    Console.WriteLine($"Inválidas: {totalInvalidas}");

    Console.WriteLine();
    Console.WriteLine("Por marca:");

    Console.WriteLine($"Visa: {totalVisa}");
    Console.WriteLine($"Mastercard: {totalMastercard}");
    Console.WriteLine($"American Express: {totalAmerican}");
    Console.WriteLine($"Discover: {totalDiscover}");
}