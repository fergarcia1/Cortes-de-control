using System;
using System.Collections.Generic;
using System.IO;

namespace Cortes_de_control
{
    class Program
    {
        static void Main()
        {
            int i = 0;
            Persona p = new Persona();
            Persona[] arrayPersona = lecturaPersonal();

            leeControl(arrayPersona, 1);
            arrayPersona[1].mostrarPersona();
            Console.ReadKey();


        }

        public static Persona[] lecturaPersonal()
        {
            int i = 0;
            Persona[] arrayPersona = new Persona[3];
            Persona p = new Persona();

            var reader = new StreamReader(File.OpenRead(@"A:\\Libro1.csv"));
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                p.Legajo = Int32.Parse(values[0]);
                p.NombreApellido = values[1];
                p.HorasTrabajadas = Int32.Parse(values[2]);
                p.SueldosACobrar = Int32.Parse(values[3]);
                p.UltimoProceso = values[4];

                arrayPersona[i] = p;
                arrayPersona[i].mostrarPersona();
                Console.ReadKey();
                i++;
            }
            Console.Clear();
            return arrayPersona;
        }

        public static void leeControl(Persona[] arrayPersona, int i)
        {
            try
            {
                Console.WriteLine("Modifique la fecha de proceso (dd/mm/yy).");
                Console.Write("Dia: ");
                int dia = Int32.Parse(Console.ReadLine());
                if (dia > 30 || dia <= 0)
                {
                    Console.WriteLine("Dia incorrecto, intente de nuevo");
                    leeControl(arrayPersona, i);
                }
                Console.Write("Mes: ");
                int mes = Int32.Parse(Console.ReadLine());
                if (mes > 12 || mes <= 0)
                {
                    Console.WriteLine("Mes incorrecto, intente de nuevo");
                    leeControl(arrayPersona, i);
                }
                Console.Write("Año: ");
                int año = Int32.Parse(Console.ReadLine());
                if (año < 2011 || año > 2013)
                {
                    Console.WriteLine("Año incorrecto, intente de nuevo");
                    leeControl(arrayPersona, i);
                }
                string nuevaFecha = dia + "-" + mes + "-" + año;
                arrayPersona[i].cambiarUltimoProceso(nuevaFecha);
            }
            catch (Exception)
            {
                Console.WriteLine("Dato incorrecto");
                Main();
            }
        }
    }


    class Persona
    {
        //atributos
        private int legajo;
        private string nombreApellido;
        private double valorHora;
        private int horasTrabajadas;
        private int sueldosACobrar;
        private string ultimoProceso;

        //getters & setters
        public int Legajo { get => legajo; set => legajo = value; }
        public string NombreApellido { get => nombreApellido; set => nombreApellido = value; }
        public double ValorHora { get => valorHora; set => valorHora = value; }
        public int HorasTrabajadas { get => horasTrabajadas; set => horasTrabajadas = value; }
        public int SueldosACobrar { get => sueldosACobrar; set => sueldosACobrar = value; }
        public string UltimoProceso { get => ultimoProceso; set => ultimoProceso = value; }

        //constructores
        public Persona()
        {
        }
        public Persona(int legajo, string nombreApellido, int horasTrabajadas, int sueldosACobrar, string ultimoProceso)
        {
            this.Legajo = legajo;
            this.NombreApellido = nombreApellido;
            this.HorasTrabajadas = horasTrabajadas;
            this.SueldosACobrar = sueldosACobrar;
            this.UltimoProceso = ultimoProceso;
        }

        //metodos
        public int sumarHoras(int horas)
        {
            return this.HorasTrabajadas + horas;
        }
        public int agregarSueldo(int sueldo)
        {
            return this.SueldosACobrar + sueldo;
        }

        public void cambiarUltimoProceso(string nuevoProceso)
        {
            this.UltimoProceso = nuevoProceso;
        }

        public void mostrarPersona()
        {
            Console.WriteLine("Nombre y apellido: " + this.NombreApellido);
            Console.WriteLine("Numero de legajo: " + this.Legajo);
            Console.WriteLine("Horas trabajadas: " + this.HorasTrabajadas);
            Console.WriteLine("Numero de sueldos a cobrar: " + this.SueldosACobrar);
            Console.WriteLine("Fecha del ultimo proceso: " + this.UltimoProceso);
        }
    }
}

