Console.WriteLine("05_SISTEMA DE Servomotor");
Console.WriteLine();

// Clases: Servomotor
// Objetos: servo
// Propiedades: posact y posob
// Metodos: EsPosicionValida, CalcularDesplazamiento y ObtenerSentidoMovimiento

Servomotor servo = new Servomotor();

bool movvalido = false;

// INGRESADO DE DATOS DE LOS GRADOS A CALCULAR
do
{
    Console.Write("Ingrese la posición actual (°): ");
    double posact = Convert.ToDouble(Console.ReadLine());

    Console.Write("Ingrese la posición objetivo (°): ");
    double posob = Convert.ToDouble(Console.ReadLine());

    if (servo.EsPosicionValida(posact) && servo.EsPosicionValida(posob))
    {
        servo.posact = posact;
        servo.posob = posob;
        movvalido = true;
    }
    else
    {
        Console.WriteLine("ERROR:UNO O AMBOS VALORES ESTAN FUERA DE RANGO, ESCRIBE BIEN.");
        Console.WriteLine();
    }
} while (!movvalido);

// Solicitar al objeto los cálculos
double despl = servo.CalcularDesplazamiento();
string senmov = servo.ObtenerSentidoMovimiento();

// MOSTRAR RESULTADOS
Console.WriteLine();
Console.WriteLine($"Desplazamiento absoluto: {despl} °");
Console.WriteLine($"Estado del movimiento: {senmov}");


// Definición de la clase
class Servomotor
{
    // Propiedades
    public double posact { get; set; }

    public double posob { get; set; }



    // Método para validar rango seguro
    public bool EsPosicionValida(double pos)
    {
        if (pos >= 0.0 && pos <= 180.0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // DETERMINAR EL DESPALZAMIENTO ABSOLUTO DEL MOTOR
    public double CalcularDesplazamiento()
    {
        double despl;

        despl = Math.Abs(posob - posact);

        return despl;
    }


    // DETERMINAR EL SENTIDO DEL MOVIMIENTO SI ES MAYOR, MENOR O NO SE MOVIO
    public string ObtenerSentidoMovimiento()
    {
        if (posob > posact)
        {
            return "Movimiento hacia una posición mayor";
        }
        else if (posob < posact)
        {
            return "Movimiento hacia una posición menor";
        }
        else
        {
            return "No hay movimiento";
        }
    }
}