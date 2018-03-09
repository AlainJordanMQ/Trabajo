using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoFinal
{
    public class ManejadorDeArchivos2
    {
        public string Archivo { get; set; }
        public ManejadorDeArchivos2(string archivo)
        {
            Archivo = archivo;
        }
        public bool Guardar(string datos)
        {
            try
            {
                StreamWriter file = new StreamWriter(Archivo);
                file.WriteLine();
                file.Write(datos);
                file.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public string Leer()
        {
            try
            {
                StreamReader file = new StreamReader(Archivo);
                string datos = file.ReadToEnd();
                file.Close();
                return datos;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
