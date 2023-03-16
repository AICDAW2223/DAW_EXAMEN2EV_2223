using System;

namespace LotoClassNS
{

    // Clase que almacena una combinación de la lotería
    public class loto
    {
        // definición de constantes
        private const int mAX_NUMEROS = 6;
        private const int nUMERO_MENOR = 1;
        private const int nUMERO_MAYOR = 49;

        // numeros de la combinación
        private int[] numeros = new int[MAX_NUMEROS];
        // combinación válida (si es aleatoria, siempre es válida, si no, no tiene porqué)
        private bool ok = false;

        public int[] Numeros { 
            get => numeros; 
            set => numeros = value; 
        }

        public static int MAX_NUMEROS => mAX_NUMEROS;

        public static int NUMERO_MENOR => nUMERO_MENOR;

        public static int NUMERO_MAYOR => nUMERO_MAYOR;

        public bool Ok { get => ok; set => ok = value; }



        /// <summary>
        /// Constructor vacío, que genera una combinación aleatoria correcta.
        /// </summary>
        public loto()
        {
            // clase generadora de números aleatorios
            Random aleatorio = new Random();    

            int i=0, j, numero;

            // generamos la combinación
            do
            {   
                // generamos un número aleatorio del 1 al 49                 
                numero = aleatorio.Next(NUMERO_MENOR, NUMERO_MAYOR + 1);
                // comprobamos que el número no está
                for (j = 0; j<i; j++)    
                    if (Numeros[j]==numero)
                        break;
                // Si i==j, el número no se ha encontrado en la lista, lo añadimos
                if (i==j)               
                {
                    Numeros[i]=numero;
                    i++;
                }
            } while (i<MAX_NUMEROS);

            Ok=true;
        }

      
        /// <summary>
        /// Constructor de un objeto loto con parámetros, este constructor recibe un vector con seis números,
        /// Dicho vector puede ser o no en un inicio, pero se comprueba si es válido dentro del constructor.
        /// </summary>
        /// <param name="misNumeros"> Es el vector en cuestión con seis números.</param>
        public loto(int[] misNumeros)  
        {
            for (int i=0; i<MAX_NUMEROS; i++)
                if (misNumeros[i]>=NUMERO_MENOR && misNumeros[i]<=NUMERO_MAYOR) {
                    int j;
                    for (j=0; j<i; j++) 
                        if (misNumeros[i]==Numeros[j])
                            break;
                    // validamos la combinación
                    if (i==j)
                        Numeros[i]=misNumeros[i]; 
                    else {
                        Ok=false;
                        return;
                    }
                }
                else
                {
                    // La combinación no es válida, terminamos
                    Ok = false;     
                    return;
                }
	    Ok=true;
        }

        
        /// <summary>
        /// Método que comprueba el número de aciertos del vector pasado por parámetro
        /// </summary>
        /// <param name="premio"> Vector que recibe con parámetro, el cual contiene seis números</param>
        /// <returns> Devuelve un valor numérico entero en función de los aciertos</returns>
        public int comprobar(int[] premio)
        {
            // número de aciertos
            int boleto =0;                    
            for (int i=0; i<MAX_NUMEROS; i++)
                for (int j=0; j<MAX_NUMEROS; j++)
                    if (premio[i]==Numeros[j]) boleto++;
            return boleto;
        }
    }

}
